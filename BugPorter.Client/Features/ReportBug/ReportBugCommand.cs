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

        public ReportBugCommand(ReportBugFormViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
