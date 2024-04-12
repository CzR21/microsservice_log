using Microsoft.OpenApi.Models;
using SimpleEnergy_Log_CrossCutting.Bindings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Bindings.Configure(builder.Services, builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microsservice-Log-Service", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                        policy =>
                        {
                            policy.AllowAnyOrigin();
                            policy.AllowAnyMethod();
                            policy.AllowAnyHeader();
                        }
                            );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
