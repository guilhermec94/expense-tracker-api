using ExpenseTracker.API.Auth0;
using ExpenseTracker.Application.Services;
using ExpenseTracker.Domain.Abstractions;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AbstractionsApplication = ExpenseTracker.Application.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddDbContext<ExpenseTrackerContext>(opt =>
    opt.UseNpgsql(builder.Configuration["ExpenseTrackerConnectionString:expensetrackerdb"])
    .UseSnakeCaseNamingConvention());


services.AddLogging();
services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<IExpenseRepository, ExpenseRepository>();
services.AddScoped<AbstractionsApplication.ICategoryService, CategoryService>();
services.AddScoped<AbstractionsApplication.IExpenseService, ExpenseService>();
services.AddScoped<AbstractionsApplication.ICategoryService, CategoryService>();
services.AddScoped<AbstractionsApplication.IExpenseService, ExpenseService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Auth0:Authority"];
    options.Audience = builder.Configuration["Auth0:Audience"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };
});

services.AddAuthorization(options =>
{
    options.AddPolicy("read:category", policy =>
    policy.Requirements.Add(new RbacRequirement("read:category")));
    options.AddPolicy("create:category", policy =>
    policy.Requirements.Add(new RbacRequirement("create:category")));
    options.AddPolicy("update:category", policy =>
    policy.Requirements.Add(new RbacRequirement("update:category")));
    options.AddPolicy("delete:category", policy =>
    policy.Requirements.Add(new RbacRequirement("delete:category")));

    options.AddPolicy("read:expense", policy =>
    policy.Requirements.Add(new RbacRequirement("read:expense")));
    options.AddPolicy("create:expense", policy =>
    policy.Requirements.Add(new RbacRequirement("create:expense")));
    options.AddPolicy("update:category", policy =>
    policy.Requirements.Add(new RbacRequirement("update:expense")));
    options.AddPolicy("delete:expense", policy =>
    policy.Requirements.Add(new RbacRequirement("delete:expense")));
});

services.AddSingleton<IAuthorizationHandler, RbacService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.Run();
