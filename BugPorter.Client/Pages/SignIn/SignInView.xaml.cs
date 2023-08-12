namespace BugPorter.Client.Pages;

public partial class SignInView : ContentPage
{
	public SignInView(object bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}

    private async void Button_Pressed(object sender, EventArgs e)
    {        
        await Shell.Current.GoToAsync($"//SignUp");        
    }
}