using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.RateLimiting;
using SnapMart.Application.Behavior;
using SnapMart.WebApi;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddMediatR(cfg => 
       cfg.RegisterServicesFromAssembly(SnapMart.Application.AssemblyReference.Assembly));

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

builder.Services.AddValidatorsFromAssembly(SnapMart.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);


// Swagger configuration for API documentation
builder.Services.ConfigureSwagger();

// API Versioning
builder.Services.ConfigureApiVersioning();

int successfulRequestCount = 0;
int rejectedRequestCount = 0;


// Rate limiter configuration
builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy("TokenBucketPolicy", context =>
            RateLimitPartition.GetTokenBucketLimiter(context.Connection.RemoteIpAddress.ToString(), _ =>
                new TokenBucketRateLimiterOptions
                {
                    TokenLimit = 5, // Max tokens in the bucket
                    QueueLimit = 0, // Reject requests that exceed the limit (no queuing)
                    ReplenishmentPeriod = TimeSpan.FromSeconds(40), // Tokens replenished every 100 seconds
                    TokensPerPeriod = 5, // Tokens added per period
                    AutoReplenishment = true // Enable token replenishment
                })
        );

    // Global rejection status code
    options.RejectionStatusCode = 429;

    // Customize rejection behavior
    options.OnRejected = async (context, cancellationToken) =>
    {
        // Log the rejection (status code 429)
        Console.WriteLine($"Request rejected at {DateTime.Now}: {context.HttpContext.Request.Path}");

        // Send rejection response
        context.HttpContext.Response.StatusCode = 429;
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsync(
            "{\"error\": \"Rate limit exceeded. Please try again later.\"}",
            cancellationToken
        );

        // Increment the rejected count
        Interlocked.Increment(ref rejectedRequestCount);
        Console.WriteLine($"Rejected Response Status Code: {context.HttpContext.Response.StatusCode}");
    };
});






var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development only
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SnapMart API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "SnapMart API v2");
    });
}

app.UseHttpsRedirection();
//app.UseAuthentication(); // Use authentication middleware
//app.UseAuthorization();



app.Use(async (context, next) =>
{
    // Process the request
    await next();

    // Check if the request was successful (status code 2xx)
    if (context.Response.StatusCode == 200)
    {
        Interlocked.Increment(ref successfulRequestCount); // Thread-safe increment for success
    }
    else if (context.Response.StatusCode == 429)
    {
        // Increment the rejected count if rate-limited (HTTP 429)
        Interlocked.Increment(ref rejectedRequestCount);
    }

    // Log the status code for this specific request
    Console.WriteLine($"Request {context.Request.Path} completed with Status Code: {context.Response.StatusCode}");

    // Log the total counts of successful and rejected requests separately
    Console.WriteLine($"Successful Requests Count: {successfulRequestCount}");
    Console.WriteLine($"Rejected Requests Count: {rejectedRequestCount}");
});


app.UseRateLimiter();

app.MapControllers();

app.Run();

