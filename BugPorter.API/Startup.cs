using BugPorter.API.Features.ReportBug.GitHub;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Octokit;
using System.IO;

[assembly: FunctionsStartup(typeof(BugPorter.API.Startup))]
namespace BugPorter.API
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();

            builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "host.json"), optional: true, reloadOnChange: false)
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"{context.EnvironmentName}.settings.json"), optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
        }
        public override void Configure(IFunctionsHostBuilder builder)
        {

            IConfiguration configuration = builder.GetContext().Configuration;
            builder.Services.AddFirebaseAuthentication();
            builder.Services.AddSingleton<GoogleCredential>();
            builder.Services.AddSingleton<Credentials>();
            builder.Services.AddSingleton<GitHubRepositoryOptions>();

            builder.Services.Configure<GitHubRepositoryOptions>(options =>
            {
                options.Owner = configuration.GetValue<string>("GITHUB_REPOSITORY_OWNER");
                options.Name = configuration.GetValue<string>("GITHUB_REPOSITORY_NAME");
            });
            string gitHubToken = configuration.GetValue<string>("GITHUB_TOKEN");
            builder.Services.AddSingleton(new GitHubClient(new ProductHeaderValue("bugporter-api"))
            {
                Credentials = new Credentials(gitHubToken)
            });
            builder.Services.AddSingleton<CreateGitHubIssueCommand>();

            string firebaseConfig = configuration.GetValue<string>("FIREBASE_CONFIG");

            var gCredential = GoogleCredential.FromJson(firebaseConfig).CreateScoped(new[] {"FIREBASE_CONFIG"});

            FirebaseApp firebaseApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = gCredential
            });
            builder.Services.AddSingleton(firebaseApp);

        }
    }

}
