public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        app.UseMiddleware<CustomMiddleware.RequestResponseLoggingMiddleware>();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("Content-Security-Policy", 
              "default-src 'self'; script-src 'self'; style-src 'self';");
            await next();
        });

        app.UseExceptionHandler("/error.html");

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to Middleware Demo!");
            });
        });
    }
}
