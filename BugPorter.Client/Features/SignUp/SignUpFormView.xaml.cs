namespace BugPorter.Client.Features.SignUp;

public partial class SignUpFormView : ContentPage
{
    public SignUpFormView(object bindingContext)
    {
        InitializeComponent();
        BindingContext = bindingContext;
    }
}