using BugPorter.Client.Entities;
using Firebase.Auth;

namespace BugPorter.Client.Features
{
    public class SignInCommand : AsyncCommandBase
    {
        readonly FirebaseAuthClient _authClient;
        readonly SignInFormViewModel _viewModel;
        readonly CurrentUserStore _currentUserStore;

        public SignInCommand(
            SignInFormViewModel viewModel, 
            FirebaseAuthClient authClient, 
            CurrentUserStore currentUserStore)
        {
            _authClient = authClient;
            _viewModel = viewModel;
            _currentUserStore = currentUserStore;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                UserCredential userCredential = await _authClient.SignInWithEmailAndPasswordAsync(
                    _viewModel.Email, 
                    _viewModel.Password);

                _currentUserStore.CurrentUser = userCredential.User;

                await Application.Current.MainPage.DisplayAlert("Success", $"Successfully signed in!", "Ok");
                
                await Shell.Current.GoToAsync("//ReportBug");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign in, Please try again later.", "Ok");
            }
        }
    }
}
