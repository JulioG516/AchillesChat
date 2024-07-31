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
    public string _userName;
    
    [ObservableProperty]
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
    
    [RelayCommand]
    public void LoginCommand()
    {
        Login();
    }

    private void Login()
    {
        UserLogin user = new()
        {
            UserName = UserName,
            Password = PassWord
        };
        
        WeakReferenceMessenger.Default.Send(new LoggedInUserChangedMessage(user));
    }
}