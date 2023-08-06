namespace BugPorter.Client.Features.SignIn;

public partial class SignInFormView : ContentPage
{
	public SignInFormView(object bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}