using ExpenseTrackerAPI.Handlers;
using ExpenseTrackerAPI.Model;
using ExpenseTrackerAPI.Repositories;
using ExpenseTrackerAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddDbContext<ExpenseTrackerContext>(opt =>
    opt.UseNpgsql(builder.Configuration["ExpenseTrackerConnectionString:expensetrackerdb"])
    .UseSnakeCaseNamingConvention());


services.AddLogging();
services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<IExpenseRepository, ExpenseRepository>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddScoped<IExpenseService, ExpenseService>();
services.AddScoped<ICategoryHandler, CategoryHandler>();
services.AddScoped<IExpenseHandler, ExpenseHandler>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.Run();
