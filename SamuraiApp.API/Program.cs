using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyIdentityServer.Helpers;
using SamuraiApp.Data;
using SamuraiApp.Data.Interface;
using System.Text;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
     x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//ef core
builder.Services.AddDbContext<SamuraiContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SamuraiConnection")).EnableSensitiveDataLogging());


//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
//    .AddEntityFrameworkStores<SamuraiContext>();

//injection
builder.Services.AddTransient<ISamurai, SamuraiRepo>();
builder.Services.AddTransient<ISamuraiPedang, SamuraiPedangRepo>();
builder.Services.AddTransient<ISamuraiPedangElemen, SamuraiPedangElemenRepo>();
builder.Services.AddTransient<IPedang, PedangRepo>();
builder.Services.AddTransient<IPedangElemen, PedangElemenRepo>();
builder.Services.AddTransient<IBattleSamurai, BattleSamuraiRepo>();

//konfigurasi jwt token
var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);
var appSetings = appSettingSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSetings.secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters =
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
