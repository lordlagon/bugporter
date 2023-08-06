namespace BugPorter.Client;

public partial class SignInFormView : ContentPage
{
	public SignInFormView(object bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}