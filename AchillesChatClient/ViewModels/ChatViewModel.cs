using System.Collections.ObjectModel;
using AchillesChatClient.Models;
using AchillesChatClient.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AchillesChatClient.ViewModels;

public partial class ChatViewModel : PageViewModelBase
{
    # region fields property

    private IChatService _chatService;

    [ObservableProperty] public string messageToSend;
    [ObservableProperty] public string userName;
    [ObservableProperty] public bool _isConnected;

    public ObservableCollection<string> MessagesList { get; } = new();

    public ObservableCollection<ChatParticipant> Participants { get; set; }
        = new ObservableCollection<ChatParticipant>
        {
            new ChatParticipant()
            {
                Name = "ellizabeth.grant",
                DisplayName = "Lana Del Rey",
                IsTyping = true,
                IsLoggedIn = true,
                IsOverSeer = true
            },
            new ChatParticipant()
            {
                Name = "john.doe",
                DisplayName = "John Doe",
                IsTyping = false,
                IsLoggedIn = true,
                IsOverSeer = false
            },
            new ChatParticipant()
            {
                Name = "david.bowie",
                DisplayName = "David Bowie",
                IsTyping = false,
                IsLoggedIn = false,
                IsOverSeer = false
            }
        };

    [RelayCommand]
    public void ConnectCommand()
    {
        Connect();
    }

    private void Connect()
    {
        _chatService.ConnectAsync();
    }

    private bool CanSendMessage() => !string.IsNullOrEmpty(messageToSend);

    [RelayCommand]
    public void SendMessage()
    {
        _chatService.SendMessage(UserName, MessageToSend);
    }

    #endregion

    # region Events

    private void ChatServiceOnReceiveMessage(string name, string message)
    {
        MessagesList.Add($"User: {name} - {message}");
    }

    #endregion


    public ChatViewModel()
    {
    }

    public ChatViewModel(IChatService _chatService)
    {
        this._chatService = _chatService;

        _chatService.ReceiveMessage += ChatServiceOnReceiveMessage;

        _chatService.ConnectAsync();
    }

    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; }
}