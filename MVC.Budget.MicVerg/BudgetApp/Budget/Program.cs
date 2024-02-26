using Budget.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BudgetContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString")));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();