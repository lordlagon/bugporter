﻿namespace BugPorter.Client.Pages;

public partial class SignInViewModel : ViewModelBase 
{
    public SignInFormViewModel SignInFormViewModel { get; }

    public SignInViewModel(SignInFormViewModel signInFormViewModel)
    {
        SignInFormViewModel = signInFormViewModel;
    }

    
}
