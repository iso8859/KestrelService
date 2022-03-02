using KestrelService.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Topshelf;

public class Runservice : Topshelf.ServiceControl
{
    WebApplication _webApp;
    CancellationTokenSource m_exit = new CancellationTokenSource();
    Task m_main;

    public Runservice(WebApplication app)
    {
        _webApp = app;
    }
    public bool Start(Topshelf.HostControl hostControl)
    {
        _webApp.Logger.LogInformation("App version a.b.c.d");
        m_exit.Token.Register(() => { _webApp.Logger.LogInformation("The app is exiting"); });

        m_main = Task.Run(async () =>
        {
            try // m_exit cancel throw an exception, this is normal
            {
                await _webApp.StartAsync(m_exit.Token);
                _webApp.Logger.LogInformation("App started");
            }
            catch { }
        });
        return true;
    }

    public bool Stop(Topshelf.HostControl hostControl)
    {
        m_exit.Cancel();
        Task.WaitAll(m_main);
        m_main.Dispose();
        _webApp.Logger.LogInformation("App stopped");
        return true;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Directory.SetCurrentDirectory(AppContext.BaseDirectory);

        var rc = Topshelf.HostFactory.Run(x =>
        {
            x.Service<Runservice>(hostSettings => new Runservice(CreateWebApp(args)));
            x.SetDescription("Here the service description");
            x.SetDisplayName("Here how the service display");
            x.SetServiceName("theName");
        });
    }

    public static WebApplication CreateWebApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Startup s = new Startup(builder.Configuration);
        s.ConfigureServices(builder.Services);
        var app = builder.Build();
        s.Configure(app);
        return app;
    }
}