using Firebase.Auth;

namespace BugPorter.Client.Features
{
    public class SignInCommand : AsyncCommandBase
    {
        readonly FirebaseAuthClient _authClient;
        readonly SignInFormViewModel _viewModel;

        public SignInCommand(SignInFormViewModel viewModel, FirebaseAuthClient authClient)
        {
            _authClient = authClient;
            _viewModel = viewModel;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var user = await _authClient.SignInWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);
                await Application.Current.MainPage.DisplayAlert("Success", $"Successfully signed in!", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign in, Please try again later.", "Ok");
            }
        }
    }
}
