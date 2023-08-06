namespace BugPorter.Client.Features;

public partial class ReportBugFormViewModel : ViewModelBase
{
    readonly IReportBugApiCommand _reportBugApiCommand;
    [ObservableProperty]
    string summary;

    [ObservableProperty]
    string description;

    public ReportBugFormViewModel(IReportBugApiCommand reportBugApiCommand)
    {
        _reportBugApiCommand = reportBugApiCommand;
    }
    [RelayCommand]
    void ReportBug() => new ReportBugCommand(this, _reportBugApiCommand).Execute(null);
}