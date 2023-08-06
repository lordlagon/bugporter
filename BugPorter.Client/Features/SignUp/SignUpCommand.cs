using Firebase.Auth;

namespace BugPorter.Client.Features
{
    public class SignUpCommand : AsyncCommandBase
    {
        readonly FirebaseAuthClient _authClient;
        readonly SignUpFormViewModel _viewModel;

        public SignUpCommand(SignUpFormViewModel viewModel, FirebaseAuthClient authClient)
        {
            _authClient = authClient;
            _viewModel = viewModel;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.Password != _viewModel.ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password and confirm password values do not match", "Ok");
                return;
            }

            try
            {
                var user = await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password, _viewModel.Name);
                await Application.Current.MainPage.DisplayAlert("Success", $"Successfully signed up!", "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign up, Please try again later.", "Ok");
            }
        }
    }
}
