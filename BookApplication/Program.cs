using BookApplication.Infrastructure.Context;
using BookApplication.Service.Implementations;
using BookApplication.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextPool<BookDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
    options.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
});
builder.Services.AddTransient<BookDbContext>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddCors(options => options.AddPolicy("corspolicy",builder => 
{
    builder.WithOrigins( "http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});

//builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddServices();
builder.Services.AddCustomConfiguredAutoMapper();

var app = builder.Build();
app.UseCors("corspolicy");
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
