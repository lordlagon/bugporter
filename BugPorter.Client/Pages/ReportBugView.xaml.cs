namespace BugPorter.Client.Pages;

public partial class ReportBugView : ContentPage
{
	public ReportBugView(ReportBugViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
