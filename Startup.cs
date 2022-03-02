using Microsoft.AspNetCore.Builder;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        var builder = new ConfigurationBuilder()
            .AddConfiguration(configuration)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging((l) =>
        {
            var loggingSection = Configuration.GetSection("Logging");
            l.AddFile(loggingSection);
        });

        // Add services to the container.
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddControllers();
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }

}