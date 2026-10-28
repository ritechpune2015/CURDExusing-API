using CURDEx.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddDbContext<CompanyContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("scon")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => {
    opt.AddDefaultPolicy(p => {
        //p.WithOrigins("https://www.revolutioninfosystems.com","https://www.ritechpune.com");

        p.AllowAnyOrigin();
        //p.WithHeaders("accept-demo");
        p.AllowAnyHeader();
        //p.WithMethods("Post","Put");
        p.AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
