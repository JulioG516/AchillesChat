using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AchillesChatClient.Models;

public partial class ChatParticipant : ObservableObject
{
    public string Name { get; set; }

    public string DisplayName { get; set; }

    public DateTime LastMessageTime
    {
        get
        {
            if (Chatter.Count == 0) return DateTime.MinValue;

            var lastMessage = Chatter.Last();
            return lastMessage.MessageTime;
        }
    }

    public bool IsOverSeer { get; set; }

    [ObservableProperty] private bool _isLoggedIn;
    [ObservableProperty] private bool _selected;
    [ObservableProperty] private bool _hasSentNewMessage;
    [ObservableProperty] private bool _isTyping;

    public ObservableCollection<ChatMessage> Chatter { get; set; }

    public ChatParticipant()
    {
        Chatter = new ObservableCollection<ChatMessage>();
    }
}