namespace BugPorter.Client.Features;

public partial class SignUpFormView : ContentPage
{
    public SignUpFormView(object bindingContext)
    {
        InitializeComponent();
        BindingContext = bindingContext;
    }
}