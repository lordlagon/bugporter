using Firebase.Auth;

namespace BugPorter.Client.Features;
public partial class SignUpFormViewModel : ViewModelBase
{
    readonly FirebaseAuthClient _authClient;
    [ObservableProperty]
    string name; 
    [ObservableProperty]
    string email;
    [ObservableProperty]
    string password;
    [ObservableProperty]
    string confirmPassword;
    public SignUpFormViewModel(FirebaseAuthClient authClient)
    {
        _authClient = authClient;
    }

    [RelayCommand]
    void SignUp() => new SignUpCommand(this, _authClient).Execute(null);
}