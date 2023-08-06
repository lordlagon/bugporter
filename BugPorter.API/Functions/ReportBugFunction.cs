using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using BugPorter.API.Features.ReportBug.GitHub;
using BugPorter.API.Features.ReportBug;
using FirebaseAdminAuthentication.DependencyInjection.Services;
using Microsoft.AspNetCore.Http;
using BugPorter.Core.Features;

namespace BugPorter.API
{
    public  class ReportBugFunction
    {
        readonly CreateGitHubIssueCommand _createGitHubIssueCommand;
        readonly FirebaseAuthenticationFunctionHandler _authenticationHandler;
        readonly ILogger<ReportBugFunction> _logger;

        public ReportBugFunction(
            ILogger<ReportBugFunction> logger, 
            CreateGitHubIssueCommand createGitHubIssueCommand, 
            FirebaseAuthenticationFunctionHandler authenticationHandler)
        {
            _logger = logger;
            _createGitHubIssueCommand = createGitHubIssueCommand;
            _authenticationHandler = authenticationHandler;
        }

        [FunctionName("ReportBugFunction")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bugs")] ReportedBugRequest request, 
            HttpRequest httpRequest)
        {
            //AuthenticateResult authenticateResult = await _authenticationHandler.HandleAuthenticateAsync(httpRequest);

            //if (!authenticateResult.Succeeded)
            //{
            //    return new UnauthorizedResult();
            //}

            //string userId = authenticateResult.Principal.FindFirst(FirebaseUserClaimType.ID).Value;
            //_logger.LogInformation("Authenticated user {UserId}", userId);

            NewBug newBug = new NewBug(request.Summary, request.Description);

            ReportedBug reportedBug = await _createGitHubIssueCommand.Execute(newBug);

            return new OkObjectResult(new ReportedBugResponse()
            {
                Id = reportedBug.Id,
                Summary = reportedBug.Summary,
                Description = reportedBug.Description,
            });
        }
    }
}
