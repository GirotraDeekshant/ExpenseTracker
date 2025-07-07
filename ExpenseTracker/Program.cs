//using ExpenseTracker.Common.DbContext;
using ExpenseTracker.Business.DBContext;
using ExpenseTracker.Model;
using ExpenseTracker.Repository.UserRepository;
using ExpenseTracker.Services.UserServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserServices, UserServices>();
var connectionString = builder.Configuration.GetSection("ConnectionStrings");
var appConfig = connectionString.Get<Connection>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true; // Cookie is HTTP-only
    options.Cookie.IsEssential = true; // Required for GDPR compliance
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Index"; // Path to your login page
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/Index"; // Path to access denied page
            });
builder.Services.AddAuthorization(SessionOptions =>
{
    SessionOptions.AddPolicy("SessionCheckPolicy", policy =>
        policy.Requirements.Add(new SessionRequirement("UserName")));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Cookies["AccessToken"];
                if (!string.IsNullOrEmpty(accessToken))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });
var email = builder.Configuration.GetSection("EmailSetting");
var emalsetting = email.Get<Common.EmailModel>();
Common.Mail.InitialEmail(emalsetting);
var encrypt = builder.Configuration.GetSection("EncryptSetting");
var encryptsetting = encrypt.Get<Common.EncryptModel>();
Common.Encryption.InitialLog(encryptsetting);
var log = builder.Configuration.GetSection("logger");
var loggerSetting = log.Get<Common.LoggerModel>();
Common.Logger.InitialLog(loggerSetting);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
