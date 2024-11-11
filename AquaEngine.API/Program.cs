using AquaEngine.API.Invoice.Application.Internal.CommandServices;
using AquaEngine.API.Invoice.Application.Internal.QueryServices;
using AquaEngine.API.Invoice.Domain.Repositories;
using AquaEngine.API.Invoice.Domain.Services;
using AquaEngine.API.Invoice.Infrastructure.Persistence.EFC.Repositories;

using AquaEngine.API.Planning.Application.Internal.CommandServices;
using AquaEngine.API.Planning.Application.Internal.QueryServices;
using AquaEngine.API.Planning.Domain.Repositories;
using AquaEngine.API.Planning.Domain.Services;
using AquaEngine.API.Planning.Infrastructure.Persistence.EFC.Repositories;

using AquaEngine.API.Control.Application.Internal.CommandServices;
using AquaEngine.API.Control.Application.Internal.QueryServices;
using AquaEngine.API.Control.Domain.Repositories;
using AquaEngine.API.Control.Domain.Services;
using AquaEngine.API.Control.Infrastructure.Persistence.EFC.Repositories;

using AquaEngine.API.Analytics.Application.Internal.CommandServices;
using AquaEngine.API.Analytics.Application.Internal.QueryServices;
using AquaEngine.API.Analytics.Domain.Repositories;
using AquaEngine.API.Analytics.Domain.Services;
using AquaEngine.API.Analytics.Infrastructure.Persistence.EFC.Repositories;

using AquaEngine.API.Shared.Domain.Repositories;

using AquaEngine.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options=>options.LowercaseUrls = true);
builder.Services.AddControllers(options=> options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "ACME.LearningCenterPlatform.API",
        Version = "v1",
        Description = "ACME Learning Center Platform API",
        TermsOfService = new Uri("https://acme-learning.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "ACME Studios",
            Email = "contact@acme.com"
        },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("https://apache.org/licenses/LICENSE-2.0.html")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token into field",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
    options.EnableAnnotations();
});

// Add CORS policy
builder.Services.AddCors(options =>
    options.AddPolicy(
        "AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

// Add Database Connection String

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection is not set.");

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
else if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
    });

 

// Configure Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

}

// Configure Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Dependency Injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

// Analytics Bounded Context Dependency Injection
builder.Services.AddScoped<IMonitoredMachineRepository,MonitoredMachineRepository > ();
builder.Services.AddScoped<IMonitoredMachineCommandService, MonitoredMachineCommandService>();
builder.Services.AddScoped<IMonitoredMachineQueryService, MonitoredMachineQueryService>();

builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
builder.Services.AddScoped<IMaintenanceCommandService, MaintenanceCommandService>();
builder.Services.AddScoped<IMaintenanceQueryService, MaintenanceQueryService>();


// Invoice Bounded Context Dependency Injection
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceCommandService, InvoiceCommandService>();
builder.Services.AddScoped<IInvoiceQueryService, InvoiceQueryService>();
// Control Bounded Context Dependency Injection

// Planning Bounded Context Dependency Injection
builder.Services.AddScoped<IOrderingMachineryRepository, OrderingMachineryRepository>();
builder.Services.AddScoped<IOrderingMachineryCommandService, OrderingMachineryCommandService>();
builder.Services.AddScoped<IOrderingMachineryQueryService, OrderingMachineryQueryService>();

// Etc...

var app = builder.Build();

// No va a dar si no modificamos el appdbcontext dependiendo del bounded context
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


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