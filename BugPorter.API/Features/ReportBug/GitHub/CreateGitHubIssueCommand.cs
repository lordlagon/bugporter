using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugPorter.API.Features.ReportBug.GitHub
{
    public class CreateGitHubIssueCommand
    {
        readonly ILogger<CreateGitHubIssueCommand> _logger;
        readonly GitHubClient _gitHubClient;
        readonly GitHubRepositoryOptions _gitHubRepositoryOptions;

        public CreateGitHubIssueCommand(
            GitHubClient gitHubClient,
            ILogger<CreateGitHubIssueCommand> logger,
            IOptions<GitHubRepositoryOptions> gitHubRepositoryOptions)
        {
            _logger = logger;
            _gitHubClient = gitHubClient;
            _gitHubRepositoryOptions = gitHubRepositoryOptions.Value;
        }

        public async Task<ReportedBug> Execute(NewBug newBug)
        {
            _logger.LogInformation("Creating GitHub issue");

            //Create GitHub issue
            NewIssue newIssue = new NewIssue(newBug.Summary)
            {
                Body = newBug.Description
            };
            Issue createdIssue = await _gitHubClient.Issue.Create(
                _gitHubRepositoryOptions.Owner, 
                _gitHubRepositoryOptions.Name, 
                newIssue);

            _logger.LogInformation("Successfully created GitHub issue {Id}", createdIssue.Number);
            return new ReportedBug(
                createdIssue.Number.ToString(),
                createdIssue.Title,
                createdIssue.Body); ;
        }
    }
}
