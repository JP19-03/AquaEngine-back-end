using AquaEngine.API.Sales.Application.Internal.CommandServices;
using AquaEngine.API.Sales.Application.Internal.QueryServices;
using AquaEngine.API.Sales.Domain.Repositories;
using AquaEngine.API.Sales.Domain.Services;
using AquaEngine.API.Sales.Infrastructure.Persistence.EFC.Repositories;

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
using AquaEngine.API.IAM.Application.Internal.CommandServices;
using AquaEngine.API.IAM.Application.Internal.OutboundServices;
using AquaEngine.API.IAM.Domain.Repositories;
using AquaEngine.API.IAM.Domain.Services;
using AquaEngine.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using AquaEngine.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using AquaEngine.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using AquaEngine.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using AquaEngine.API.IAM.Infrastructure.Tokens.JWT.Services;
using AquaEngine.API.Shared.Domain.Repositories;
using AquaEngine.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AquaEngine.API.Shared.Infrastructure.Pipeline.Middleware.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null)
{
    throw new InvalidOperationException("Connection string not found.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AquaEngine.API",
        Version = "v1",
        Description = "AquaEngine API",
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

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Control Bounded Context Dependency Injection
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

// Planning Bounded Context Dependency Injection
builder.Services.AddScoped<IOrderingMachineryRepository, OrderingMachineryRepository>();
builder.Services.AddScoped<IOrderingMachineryCommandService, OrderingMachineryCommandService>();
builder.Services.AddScoped<IOrderingMachineryQueryService, OrderingMachineryQueryService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartCommandService, CartCommandService>();
builder.Services.AddScoped<ICartQueryService, CartQueryService>();

// IAM Bounded Context Dependency Injection Configuration

// TokenSettings Configuration

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();

// Common Exception Handling Middleware
builder.Services.AddExceptionHandler<CommonExceptionHandler>();
builder.Services.AddExceptionHandler<CommonExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

// Enable Documentation Generation
app.UseSwagger();
app.UseSwaggerUI();

// Enable CORS
app.UseCors("AllowAllPolicy");

// Enable Request Authorization Middleware
app.UseRequestAuthorization();

// Enable Exception Handling Middleware
app.UseExceptionHandler();

// Other Middleware
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();