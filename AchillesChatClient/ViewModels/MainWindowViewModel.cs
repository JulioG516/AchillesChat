using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AchillesChatClient.Messages;
using AchillesChatClient.Models;
using AchillesChatClient.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AchillesChatClient.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private static LoginViewModel _loginViewModel;
    private static ChatViewModel _chatViewModel;

    
    private readonly PageViewModelBase[] Pages;
    public MainWindowViewModel(LoginViewModel loginViewModel, ChatViewModel chatViewModel)
    {
        _loginViewModel = loginViewModel;
        _chatViewModel = chatViewModel;

        // Populate the Pages array
        Pages = new PageViewModelBase[]
        {
            loginViewModel,
            chatViewModel
        };

        _currentPage = Pages[0];

        WeakReferenceMessenger.Default.Register<LoggedInUserChangedMessage>(this, (r, m) =>
        {
            // if (!string.IsNullOrEmpty(m.Value.UserName))
            // {
                CurrentPage = Pages[1];
            // }
        });
    }

    
    // private  PageViewModelBase[] Pages =
    // {
    //     _loginViewModel,
    //     _chatViewModel
    // };

    [ObservableProperty] private PageViewModelBase _currentPage;
}