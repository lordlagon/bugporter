namespace BugPorter.Client;

public partial class ReportBugFormView : ContentView
{
	public ReportBugFormView(object bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}
