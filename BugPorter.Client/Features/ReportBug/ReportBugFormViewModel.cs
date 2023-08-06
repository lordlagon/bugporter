using System.Windows.Input;

namespace BugPorter.Client.Features;

public partial class ReportBugFormViewModel : ViewModelBase
{
    [ObservableProperty]
    string summary;

    [ObservableProperty]
    string description;

    [RelayCommand]
    void ReportBug() => new ReportBugCommand(this).Execute(null);
}