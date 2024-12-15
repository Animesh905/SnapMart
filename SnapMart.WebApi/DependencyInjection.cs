using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace SnapMart.WebApi;

public static class ServiceCollectionExtensions
{
    // Configures the database, typically used to set up DbContext
    //public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    //{
    //    // Configure DbContext for SnapMart with connection string from configuration
    //    services.AddDbContext<AppDbContext>(options =>
    //        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    //    return services;
    //}

    //// Configures repository pattern, registering repositories to be injected where needed
    //public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    //{
    //    // Register repositories here, e.g., services.AddScoped<IProductRepository, ProductRepository>();
    //    return services;
    //}

    //// Configures HttpClient for making external API calls
    //public static IServiceCollection ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
    //{
    //    // Example HttpClient configuration for an external API
    //    services.AddHttpClient("ExternalApiClient", client =>
    //    {
    //        client.BaseAddress = new Uri(configuration["ExternalApi:BaseUrl"]);
    //        client.DefaultRequestHeaders.Add("Accept", "application/json");
    //        // Additional client settings, such as timeouts, can be added here
    //    });

    //    // Another example if you need multiple HttpClient instances
    //    services.AddHttpClient<IOtherApiClient, OtherApiClient>(client =>
    //    {
    //        client.BaseAddress = new Uri(configuration["OtherApi:BaseUrl"]);
    //    });

    //    return services;
    //}

    //// Configures core application services, such as custom services, repositories, and business logic
    //public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    //{
    //    // Register application services here, e.g., services.AddScoped<IProductService, ProductService>();
    //    return services;
    //}

    //// Configures authentication and authorization, such as JWT or identity providers
    //public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
    //{
    //    // Add authentication configurations here, e.g., services.AddAuthentication(...)
    //    return services;
    //}

    // Configures Swagger/OpenAPI for API documentation
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            // Define Swagger documents for different API versions
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "SnapMart API",
                Version = "v1",
                Description = "API for SnapMart application, version 1",
                Contact = new OpenApiContact
                {
                    Name = "SnapMart Support",
                    Email = "support@snapmart.com",
                    Url = new Uri("https://snapmart.com/support")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });
            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "SnapMart API",
                Version = "v2",
                Description = "API for SnapMart application, version 2",
                Contact = new OpenApiContact
                {
                    Name = "SnapMart Support",
                    Email = "support@snapmart.com",
                    Url = new Uri("https://snapmart.com/support")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });

            // JWT Bearer Authentication Configuration
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
            });

            // Apply the Bearer scheme globally to all operations
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            // Operation filters can be used to add additional metadata or headers
            options.OperationFilter<SwaggerDefaultValues>();

            // Enable XML comments if using XML documentation
            //var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //if (File.Exists(xmlPath))
            //{
            //    options.IncludeXmlComments(xmlPath);
            //}
        });
        return services;
    }

    // Configures API versioning
    public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddMvc()
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";                // Format version as "v1", "v2", etc.
            options.SubstituteApiVersionInUrl = true;          // Replace URL template version with actual version
        });

        return services;
    }
}
