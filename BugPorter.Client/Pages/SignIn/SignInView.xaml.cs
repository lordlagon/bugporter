namespace BugPorter.Client;

public partial class SignInView : ContentPage
{
	public SignInView(object bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}