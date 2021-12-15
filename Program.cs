using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

static class Program {
    [STAThread]
    static void Main() {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        using IHost host = CreateHostBuilder().Build();

        Services = host.Services;
        var mainForm = Services.GetRequiredService<Forms.ZendeskSellClient>();

        Application.Run(mainForm);
    }

    public static IServiceProvider Services;

    static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            services.AddSingleton<Forms.ZendeskSellClient>() // Main form
                    .AddSingleton<Forms.Settings>()          // Settings
        );
}
