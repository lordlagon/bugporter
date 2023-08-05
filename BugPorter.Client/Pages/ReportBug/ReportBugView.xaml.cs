namespace BugPorter.Client;

public partial class ReportBugView : ContentPage
{
	public ReportBugView(object bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}
