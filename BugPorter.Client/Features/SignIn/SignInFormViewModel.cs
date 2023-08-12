using BugPorter.Client.Entities;
using Firebase.Auth;

namespace BugPorter.Client.Features;
public partial class SignInFormViewModel : ViewModelBase 
{
    readonly FirebaseAuthClient _authClient;
    readonly CurrentUserStore _currentUserStore;
    
    [ObservableProperty]
    string email;
    [ObservableProperty]
    string password;

    public SignInFormViewModel(FirebaseAuthClient authClient, CurrentUserStore currentUserStore)
    {
        _authClient = authClient;
        _currentUserStore = currentUserStore;
    }

    [RelayCommand]
    void SignIn() => new SignInCommand(this, _authClient, _currentUserStore).Execute(null);
}
