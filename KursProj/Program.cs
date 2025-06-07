using KursProj.Data;
using KursProj.Extentions;
using KursProj.IRepository;
using KursProj.IServices.Auth;
using KursProj.Repository;
using KursProj.Services.Auth;
using KursProj.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using KursProj.IServices.IAdminServices;
using KursProj.Services.AdminServices;
using KursProj.IServices;
using KursProj.Services.UserService;
using KursProj.IServices.IUserServices;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy
          .WithOrigins("http://localhost:5173")  // <-- Ваш фронтенд
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();                   // <-- Разрешаем куки и креденшелы
    });
});


builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
builder.Services.AddApiAuthentication(Options.Create(jwtOptions));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContextService, UserContextService>();

builder.Services.AddScoped<UploadFileService>();

builder.Services.AddScoped<IAuthRepository, AuthRepositoy>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJWTProvider, JWTProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IAdminCourseService, AdminCourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();


builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IAdminLessonService, AdminLessonService>();

builder.Services.AddScoped<IUserCourseService, UserCourseService>();

builder.Services.AddScoped<IUserLessonService, UserLessonService>();


builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IAdminTestService, AdminTestService>();
builder.Services.AddScoped<IUserTestService, UserTestService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
