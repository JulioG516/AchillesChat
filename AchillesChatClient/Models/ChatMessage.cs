using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AchillesChatClient.Models;

public partial class ChatMessage : ObservableObject
{
    [ObservableProperty] private string _message;

    [ObservableProperty] private string _author;

    [ObservableProperty] private DateTime _messageTime;

    [ObservableProperty] private bool _isOriginNative;

    [ObservableProperty] private bool _isAcked;
    
}