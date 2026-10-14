using CURDEx.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("scon")));

var app = builder.Build();
app.MapControllers();
app.Run();
