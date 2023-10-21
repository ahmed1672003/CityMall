using CityMall.API;
using CityMall.Application.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAPIDependencies(builder.Configuration);

var app = builder.Build();
app
    .UseSwagger()
    .UseSwaggerUI()
    .UseCors("CityMall")
    .UseMiddleware<ErrorHandlerMiddleWare>()
    .UseHttpsRedirection()
    .UseAuthorization()
    .UseAuthentication()
    .UseHttpsRedirection();

app.MapControllers();
app.Run();
