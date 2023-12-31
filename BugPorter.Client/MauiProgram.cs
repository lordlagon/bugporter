﻿using BugPorter.Client.Entities;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using System.Reflection;

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
            .RegisterAppServicesAuth()
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
        builder.Services.AddSingleton<CurrentUserStore>();
        builder.Services.AddSingleton<CurrentUserAuthHttpMessageHandler>();
        return builder;
    }

    public static MauiAppBuilder RegisterViewModelsViews(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<ReportBugViewModel>();
        builder.Services.AddTransient<ReportBugFormViewModel>();
        builder.Services.AddTransient(s => new ReportBugView(s.GetRequiredService<ReportBugViewModel>()));

        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<SignInFormViewModel>();
        builder.Services.AddTransient(s => new SignInView(s.GetRequiredService<SignInViewModel>()));

        builder.Services.AddTransient<SignUpViewModel>();
        builder.Services.AddTransient<SignUpFormViewModel>();
        builder.Services.AddTransient(s => new SignUpView(s.GetRequiredService<SignUpViewModel>()));

        return builder;
    }
    public static MauiAppBuilder RegisterAppServicesAuth(this MauiAppBuilder builder)
    {
        builder.AddAppSettings();

        string bugporterApiBaseUrl = builder.Configuration.GetValue<string>("BUGPORTER_API_BASE_URL");
        string firebaseApiKey = builder.Configuration.GetValue<string>("FIREBASE_API_KEY");
        string firebaseAuthDomain = builder.Configuration.GetValue<string>("FIREBASE_AUTH_DOMAIN");

        builder.Services
           .AddRefitClient<IReportBugApiCommand>()
           .ConfigureHttpClient(c => c.BaseAddress = new Uri(bugporterApiBaseUrl))
           .AddHttpMessageHandler<CurrentUserAuthHttpMessageHandler>();

        builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            ApiKey = firebaseApiKey,
            AuthDomain = firebaseAuthDomain,
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        }));

        return builder;
    }
    private static void AddAppSettings(this MauiAppBuilder builder)
    {
        builder.AddJsonSettings("appsettings.json");

#if DEBUG
        builder.AddJsonSettings("appsettings.development.json");
#endif

#if !DEBUG
        builder.AddJsonSettings("appsettings.production.json");
#endif
    }

    private static void AddJsonSettings(this MauiAppBuilder builder, string filename)
    {
        using Stream stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream($"BugPorter.Client.{filename}");

        if (stream != null)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            builder.Configuration.AddConfiguration(config);
        }
    }
}
