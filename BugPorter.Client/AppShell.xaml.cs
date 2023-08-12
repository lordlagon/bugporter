namespace BugPorter.Client;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(SignUpView), typeof(SignUpView));
        Routing.RegisterRoute(nameof(SignInView), typeof(SignInView));
        Routing.RegisterRoute(nameof(ReportBugView), typeof(ReportBugView));
    }
}
