namespace KursProj.Dtos
{
    public class ShowTestResultDto
    {
        public double? Score { get; set; }
        public DateTime DateCompleted { get; set; }
        public List<WrongAnswerDto> WrongAnswers { get; set; }
    }

}
