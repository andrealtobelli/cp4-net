using cp4_net.Interfaces;
using cp4_net.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSwaggerUI", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configuração do Swagger/OpenAPI
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { 
        Title = "GeoMaster API", 
        Version = "v1",
        Description = "API de Cálculos Geométricos - EduMath",
        Contact = new() { Name = "EduMath", Email = "contato@edumath.com" }
    });
    
    // Incluir comentários XML
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Injeção de dependência
builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();


builder.Services.AddLogging();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoMaster API v1");
        c.RoutePrefix = "swagger-ui"; 
        c.DisplayRequestDuration();
    });
}

app.UseCors("AllowSwaggerUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
