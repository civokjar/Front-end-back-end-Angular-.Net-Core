using BinocsTest.Infrastructure;
using BinocsTest.Infrastructure.Configuration;
using MediatR;
using BinocsTest.Core.Handlers.RequestHandlers.Requests;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Configuration.GetValue<bool>(InfrastructureConstants.UseEFDataProviderName))
{
    builder.Services.AddEFRepositories((IConfigurationRoot)builder.Configuration);
}
else
{
    builder.Services.AddSqlRepositories((IConfigurationRoot)builder.Configuration);
}

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "My API - V1",
            Version = "v1"
        }
     );

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "BinocsTest.Api.xml");
    c.IncludeXmlComments(filePath);
});

builder.Services.AddMediatR(typeof(GetAllListsRequest).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(options => {
    options.AddPolicy(InfrastructureConstants.CorsPolicyName, builder => {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(InfrastructureConstants.CorsPolicyName);
app.MapControllers();
app.Run();
