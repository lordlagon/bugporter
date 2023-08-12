using Firebase.Auth;

namespace BugPorter.Client.Features;
public partial class SignInFormViewModel : ViewModelBase 
{
    readonly FirebaseAuthClient _authClient;
    
    [ObservableProperty]
    string email;
    [ObservableProperty]
    string password;
    
    public SignInFormViewModel(FirebaseAuthClient authClient)
    {
        _authClient = authClient;
    }

    [RelayCommand]
    void SignIn() => new SignInCommand(this, _authClient).Execute(null);
}
