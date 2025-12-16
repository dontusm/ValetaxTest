using ValetaxTest.Api;
using ValetaxTest.Application;
using ValetaxTest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()              
    .AddInfrastructure(builder.Configuration)
    .AddApi(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseExceptionHandler("/error"); 
app.UseMiddleware<ExceptionHandlingMiddleware>(); 

app.MapControllers();
app.Run();