using BugPorter.API.Features.ReportBug.GitHub;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

            string firebaseConfig = configuration.GetValue<string>("FIREBASE_CONFIG");            
            string gitHubToken = configuration.GetValue<string>("GITHUB_TOKEN");
            string owner = configuration.GetValue<string>("GITHUB_REPOSITORY_OWNER");
            string name = configuration.GetValue<string>("GITHUB_REPOSITORY_NAME");
            FirebaseApp firebaseApp = FirebaseApp.Create(new AppOptions(){Credential = GoogleCredential.FromJson(firebaseConfig).CreateScoped(new[] { "FIREBASE_CONFIG" })});

            builder.Services.AddSingleton(firebaseApp);
            builder.Services.AddSingleton<GoogleCredential>();
            builder.Services.AddSingleton<Credentials>();            
            builder.Services.AddSingleton<CreateGitHubIssueCommand>();
            builder.Services.AddSingleton(new GitHubClient(new ProductHeaderValue("bugporter-api")){Credentials = new Credentials(gitHubToken)});
            builder.Services.Configure<GitHubRepositoryOptions>(options =>{ options.Owner = owner; options.Name = name; });
            builder.Services.AddFirebaseAuthentication();
        }
    }

}
