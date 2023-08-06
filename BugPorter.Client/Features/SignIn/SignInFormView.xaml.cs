namespace BugPorter.Client.Features;

public partial class SignInFormView : ContentPage
{
	public SignInFormView(object bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}