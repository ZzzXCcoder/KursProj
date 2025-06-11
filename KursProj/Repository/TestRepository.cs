using KursProj.Data;
using KursProj.Dtos;
using KursProj.Entities;
using KursProj.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KursProj.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TestRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid?> CreateTestAsync(CreateTestDto dto, Guid courseId, Guid userId)
        {
            var course = await _dbContext.Courses
                                        .FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null)
                throw new ArgumentException("Course not found");

            // Проверяем, что текущий пользователь — админ курса
            if (course.InstructorId != userId)
                return null; // или throw new UnauthorizedAccessException("Not course admin");

            var test = new Test
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                Questions = dto.Questions.Select(q => new Question
                {
                    Id = Guid.NewGuid(),
                    QuestionText = q.QuestionText,
                    QuestionType = q.QuestionType,
                    Answers = q.Answers.Select(a => new Answer
                    {
                        AnswerText = a.AnswerText,
                        IsCorrect = a.IsCorrect
                    }).ToList()
                }).ToList()
            };

            await _dbContext.Tests.AddAsync(test);

            var courseTestAvailability = new CourseTestAvailability
            {
                CourseId = courseId,
                TestId = test.Id,
                LessonsRequired = dto.LessonsRequired
            };
            await _dbContext.CourseTestAvailabilities.AddAsync(courseTestAvailability);

            await _dbContext.SaveChangesAsync();

            return test.Id;
        }
        public async Task<List<Test>> GetAvailableTestsForUserAsync(Guid userId, Guid courseId)
        {
            // Сколько уроков пользователь завершил в курсе
            var completedLessonsCount = await _dbContext.UserLessonStatuses
                .Where(uls => uls.UserId == userId && uls.Status == "completed")
                .Join(_dbContext.Lessons.Where(l => l.CourseId == courseId),
                      uls => uls.LessonId,
                      l => l.Id,
                      (uls, l) => uls)
                .CountAsync();

            // Тесты для курса с требуемым количеством уроков, которое пользователь уже прошёл
            var tests = await _dbContext.CourseTestAvailabilities
                .Include(cta => cta.Test)
                .Where(cta => cta.CourseId == courseId && cta.LessonsRequired <= completedLessonsCount)
                .Select(cta => cta.Test)
                .ToListAsync();

            return tests;
        }
        public async Task<ShowTestDto> GetTestByCourseId(Guid courseId, Guid userId)
        {
            // Получаем доступный тест для курса
            var testAvailability = await _dbContext.CourseTestAvailabilities
                .Include(cta => cta.Test)
                    .ThenInclude(t => t.Questions)
                        .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(cta => cta.CourseId == courseId);

            if (testAvailability == null)
                return null;

            // Считаем завершённые уроки
            var completedLessonsCount = await _dbContext.UserLessonStatuses
                .CountAsync(uls => uls.UserId == userId
                                && uls.Lesson.CourseId == courseId
                                && uls.Status == "completed");

            // Проверка доступа по количеству завершённых уроков
            if (completedLessonsCount < testAvailability.LessonsRequired)
                return null;

            // 🔒 Запретить показ, если тест уже был сдан
            var alreadySubmitted = await _dbContext.TestResults
                .AnyAsync(r => r.UserId == userId && r.TestId == testAvailability.TestId);

            if (alreadySubmitted)
                return null;

            var test = testAvailability.Test;

            return new ShowTestDto
            {
                Id = test.Id,
                Title = test.Title,
                Description = test.Description,
                Questions = test.Questions.Select(q => new ShowQuestionDto
                {
                    Id = q.Id,
                    QuestionText = q.QuestionText,
                    QuestionType = q.QuestionType,
                    Answers = q.Answers.Select(a => new ShowAnswerDto
                    {
                        Id = a.Id,
                        AnswerText = a.AnswerText
                    }).ToList()
                }).ToList()
            };
        }

        public async Task<bool> SubmitTestAsync(Guid userId, Guid testId, List<UserAnswerDto> userAnswers)
        {
            var test = await _dbContext.Tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(t => t.Id == testId);

            if (test == null) return false;

            // Проверка: уже проходил ли пользователь этот тест
            var alreadySubmitted = await _dbContext.TestResults
                .AnyAsync(tr => tr.UserId == userId && tr.TestId == testId);

            if (alreadySubmitted)
                return false; // Тест уже пройден — нельзя отправить заново

            var result = new TestResult
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                TestId = testId,
                DateCompleted = DateTime.UtcNow
            };

            double total = 0;
            double correct = 0;

            foreach (var question in test.Questions)
            {
                var userAnswer = userAnswers.FirstOrDefault(ua => ua.QuestionId == question.Id);
                if (userAnswer == null) continue;

                result.UserAnswers.Add(new UserAnswer
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id,
                    SelectedAnswer = userAnswer.SelectedAnswer,
                    TestResultId = result.Id
                });

                if (question.QuestionType == "multiple choice")
                {
                    var correctAnswers = question.Answers.Where(a => a.IsCorrect).ToList();

                    // Разбиваем выбранные ответы пользователя по запятой, убираем пустые и пробелы
                    var selectedAnswersRaw = userAnswer.SelectedAnswer
                        .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    var selectedAnswerIds = new List<int>();
                    var selectedAnswerTexts = new List<string>();

                    foreach (var ans in selectedAnswersRaw)
                    {
                        if (int.TryParse(ans, out int id))
                            selectedAnswerIds.Add(id);
                        else
                            selectedAnswerTexts.Add(ans);
                    }

                    // Проверяем, что все выбранные Id правильные
                    bool allIdsCorrect = selectedAnswerIds.All(id => correctAnswers.Any(ca => ca.Id == id));
                    // Проверяем, что все правильные Id выбраны (не пропущено ни одного)
                    bool allCorrectIdsSelected = correctAnswers.All(ca => selectedAnswerIds.Contains(ca.Id));

                    // Аналогично для текстовых ответов
                    bool allTextsCorrect = selectedAnswerTexts.All(text => correctAnswers.Any(ca => ca.AnswerText == text));
                    bool allCorrectTextsSelected = correctAnswers.All(ca => selectedAnswerTexts.Contains(ca.AnswerText));

                    // Итоговая проверка: все выбранные правильные и выбраны все правильные
                    if ((allIdsCorrect && allCorrectIdsSelected) || (allTextsCorrect && allCorrectTextsSelected))
                    {
                        correct++;
                    }
                    total++;
                }
                else if (question.QuestionType == "single choice")
                {
                    // Если у вас есть single choice, можно сделать проверку по аналогии:
                    var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);

                    if (correctAnswer != null)
                    {
                        if (int.TryParse(userAnswer.SelectedAnswer, out int selectedAnswerId))
                        {
                            if (correctAnswer.Id == selectedAnswerId)
                            {
                                correct++;
                            }
                        }
                        else if (correctAnswer.AnswerText == userAnswer.SelectedAnswer)
                        {
                            correct++;
                        }
                    }
                    total++;
                }
                else if (question.QuestionType == "text input")
                {
                    var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
                    if (correctAnswer != null && !string.IsNullOrWhiteSpace(userAnswer.SelectedAnswer))
                    {
                     
                        if (string.Equals(
                        correctAnswer.AnswerText?.Trim(),
                        userAnswer.SelectedAnswer?.Trim(),
                        StringComparison.OrdinalIgnoreCase))
                        {
                            correct++;
                        }
                    }
                 total++;
                }
            }

            result.Score = total > 0 ? (correct / total) * 100 : 0;
            
            await _dbContext.TestResults.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ShowTestResultDto?> GetTestResultAsync(Guid userId, Guid testId)
        {
            var result = await _dbContext.TestResults
                .Include(r => r.UserAnswers)
                .ThenInclude(ua => ua.Question)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(r => r.UserId == userId && r.TestId == testId);

            if (result == null) return null;

            var wrongAnswers = result.UserAnswers
                .Where(ua =>
                    ua.Question.Answers.FirstOrDefault(a => a.IsCorrect)?.Id.ToString() != ua.SelectedAnswer)
                .Select(ua => new WrongAnswerDto
                {
                    QuestionText = ua.Question.QuestionText,
                    SelectedAnswer = ua.SelectedAnswer,
                    CorrectAnswer = ua.Question.Answers.FirstOrDefault(a => a.IsCorrect)?.AnswerText
                }).ToList();

            return new ShowTestResultDto
            {
                Score = result.Score,
                DateCompleted = result.DateCompleted,
                WrongAnswers = wrongAnswers
            };
        }
        public async Task<List<TestResult>> GetTestResultsForUserAsync(Guid userId)
        {
            return await _dbContext.TestResults
                .Where(r => r.UserId == userId)
                .Include(r => r.Test)
                .OrderByDescending(r => r.DateCompleted)
                .ToListAsync();
        }
        public async Task<ShowTestDto?> GetTestByIdAsync(Guid testId)
        {
            var test = await _dbContext.Tests
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(t => t.Id == testId);

            if (test == null) return null;

            return new ShowTestDto
            {
                Id = test.Id,
                Title = test.Title,
                Description = test.Description,
                Questions = test.Questions.Select(q => new ShowQuestionDto
                {
                    Id = q.Id,
                    QuestionText = q.QuestionText,
                    QuestionType = q.QuestionType,
                    Answers = q.Answers.Select(a => new ShowAnswerDto
                    {
                        Id = a.Id,
                        AnswerText = a.AnswerText
                    }).ToList()
                }).ToList()
            };
        }
    }
}
