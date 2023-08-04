﻿using BugPorter.API.Features.ReportBug.GitHub;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: FunctionsStartup(typeof(BugPorter.API.Startup))]
namespace BugPorter.API
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfiguration configuration = builder.GetContext().Configuration;


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
        }
    }

} 
