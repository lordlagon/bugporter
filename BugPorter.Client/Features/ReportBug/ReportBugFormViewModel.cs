namespace BugPorter.Client;

public partial class ReportBugFormViewModel : ViewModelBase
{
    [ObservableProperty]
    string summary;

    [ObservableProperty]
    string description;

    [RelayCommand]
    public void ReportBug()
    {

    }
}