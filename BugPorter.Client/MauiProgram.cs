namespace BugPorter.Client;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterViewModelsViews()
            .RegisterAppServices()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });      

        return builder.Build();
    }
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
        // builder.Services.AddScoped<TransacaoService>();
        return builder;
    }
    public static MauiAppBuilder RegisterViewModelsViews(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<ReportBugViewModel>();
        builder.Services.AddTransient(s => new ReportBugView(s.GetRequiredService<ReportBugViewModel>()));
        return builder;
    }
}
