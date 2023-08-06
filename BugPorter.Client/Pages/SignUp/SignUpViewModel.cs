namespace BugPorter.Client.Pages;

public partial class SignUpViewModel : ViewModelBase
{
    public SignUpFormViewModel SignUpFormViewModel { get; }

    public SignUpViewModel(SignUpFormViewModel signUpFormViewModel)
    {
        SignUpFormViewModel = signUpFormViewModel;
    }
}
