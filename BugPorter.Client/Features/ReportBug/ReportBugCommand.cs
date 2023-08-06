using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugPorter.Client.Features
{
    public class ReportBugCommand : AsyncCommandBase
    {
        readonly ReportBugFormViewModel _viewModel;
        readonly IReportBugApiCommand _reportBugApiCommand;

        public ReportBugCommand(ReportBugFormViewModel viewModel, IReportBugApiCommand reportBugApiCommand)
        {
            _viewModel = viewModel;
            _reportBugApiCommand = reportBugApiCommand;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            ReportedBugRequest request = new()
            {
                Summary = _viewModel.Summary,
                Description = _viewModel.Description
            };
            try
            {
                ReportedBugResponse response = await _reportBugApiCommand.Execute(request);
                await Application.Current.MainPage.DisplayAlert("Success", $"Successfully reported bug #{response.Id}!", "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to report bug.","Ok");                
            }

        }
    }
}
