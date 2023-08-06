namespace BugPorter.Client.Pages;

public partial class ReportBugViewModel : ViewModelBase
{
    public ReportBugFormViewModel ReportBugFormViewModel { get; }

    public ReportBugViewModel(ReportBugFormViewModel reportBugFormViewModel)
    {
        ReportBugFormViewModel = reportBugFormViewModel;
    }
}
