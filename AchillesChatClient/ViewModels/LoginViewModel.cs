using System;
using AchillesChatClient.Messages;
using AchillesChatClient.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AchillesChatClient.ViewModels;

public partial class LoginViewModel : PageViewModelBase
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    public string _userName;
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    public string _passWord;
    
    
    public override bool CanNavigateNext
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    public override bool CanNavigatePrevious
    {
        get => false;
        protected set => throw new NotSupportedException();
    }
    
    [RelayCommand(CanExecute = nameof(CanLogin))]
    private void Login()
    {
        UserLogin user = new()
        {
            UserName = UserName,
            Password = PassWord
        };
        
        WeakReferenceMessenger.Default.Send(new LoggedInUserChangedMessage(user));
    }

    

    private bool CanLogin()
    {
        return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(PassWord);
    }
        
    
    
}