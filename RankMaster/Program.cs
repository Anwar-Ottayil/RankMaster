using Application.Interface.RepositoryInterface;
using Application.Interface.ServiceInterface;
using Application.Interfaces.NotificationInterface;
using Application.Interfaces.RepositoryInterface;
using Application.Interfaces.ServiceInterface;
using Application.Mapper;
using Application.Service;
using Application.Services;
using Application.Settings;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Add Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();
builder.Services.AddScoped<ICoordinatorCategoryRepository, CoordinatorCategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReadQuestionRepository, ReadQuestionRepository>();
builder.Services.AddScoped<ICurrentAffairsRepository, CurrentAffairsRepository>();

builder.Services.AddScoped<IExamScheduleRepository, ExamScheduleRepository>();
builder.Services.AddScoped<IExamAttemptRepository, ExamAttemptRepository>();


builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<CsvImportService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<ICoordinatorManagementService, CoordinatorManagementService>();
builder.Services.AddScoped<IReadQuestionService, ReadQuestionService>();
builder.Services.AddScoped<ICurrentAffairsService, CurrentAffairsService>();
builder.Services.AddScoped<IExamScheduleService, ExamScheduleService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IExamAttemptService, ExamAttemptService>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();


builder.Services.AddScoped<IExamServiceIspaid, ExamServiceIspaid>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IWalletService, WalletService>();


builder.Services.Configure<RazorpaySettings>(builder.Configuration.GetSection("Razorpay"));


// Add SignalR
builder.Services.AddSignalR();

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var key = builder.Configuration["Jwt:Key"];
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

// Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
    // options.AddPolicy("Coordinator", policy => policy.RequireRole("Coordinator"));
});

// Add Controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RankMaster API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter a valid JWT token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Build app
var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Map controllers and SignalR hubs
app.MapControllers();
app.MapHub<NotificationHub>("/notificationHub");

app.Run();

