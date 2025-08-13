using EscolaDeIdiomasApp.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(configureOptions =>
{
    configureOptions.LowercaseUrls = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
