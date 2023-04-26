global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using Microsoft.AspNetCore.Identity.UI.Services;
global using Flash_products.Data.JWT;
global using Flash_products.Data;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Options;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Net.Mail;
global using System.Net;
global using System.Diagnostics.CodeAnalysis;
global using Flash_products.Models;
global using Microsoft.AspNetCore.Authorization;
global using Flash_products.Repository;
global using Flash_products.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepCategory, RepCategory>();
builder.Services.AddScoped<IRepProduct, RepProduct>();
builder.Services.AddScoped<IRepEmployee, RepEmployee>();
//jwt code
builder.Services.Configure<JWTValues>(builder.Configuration.GetSection("JWT"));
builder.Services.AddDbContext<ApplicationDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt => {
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
    };
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
{
    //SingIn
    opt.SignIn.RequireConfirmedEmail = false;
    opt.SignIn.RequireConfirmedPhoneNumber = false;
    opt.SignIn.RequireConfirmedAccount = false;
    //Password
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 6;
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddTransient<IAuthServies, AuthServies>();
builder.Services.AddTransient<IEmailSender, EmailSender>(a =>
              new EmailSender(
                  builder.Configuration["EmailSender:Host"]!,
                  builder.Configuration.GetValue<int>("EmailSender:Port"),
                  builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                  builder.Configuration["EmailSender:UserName"]!,
                  builder.Configuration["EmailSender:Password"]!
              )
          );
//jwt code
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
//JWT Add defulte role and user admin
await AddDatabaseItem.AddRoll(app.Services, new List<string> { "User", "Admin", "Employee" });
await AddDatabaseItem.AddAdmin(app.Services, builder.Configuration["EmailSender:UserName"]!);
await AddDatabaseItem.AddCategories(app.Services);
//JWTs
app.Run();
