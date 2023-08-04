﻿using Microsoft.Extensions.Logging;
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

        public CreateGitHubIssueCommand(ILogger<CreateGitHubIssueCommand> logger)
        {
            _logger = logger;
        }

        public async Task<ReportedBug> Execute(NewBug newBug)
        {
            _logger.LogInformation("Creating GitHub issue");

            //Create GitHub issue
            ReportedBug reportedBug = new ReportedBug("1", newBug.Summary, newBug.Description);
            
            _logger.LogInformation("Successfully created GitHub issue {Id}", reportedBug.Id);
            return reportedBug;
        }
    }
}
