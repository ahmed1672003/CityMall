using CityMall.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAPIDependencies(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
