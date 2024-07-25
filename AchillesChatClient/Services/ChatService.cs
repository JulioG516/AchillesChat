using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace AchillesChatClient.Services;

public class ChatService : IChatService
{
    private HubConnection _connection;
    private string Url = "http://localhost:5179/chathub";

    public event Action<string, string>? ReceiveMessage;

    public async Task ConnectAsync()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(Url)
            .Build();


        _connection.On<string, string>("ReceiveMessage", 
            (u, m) => ReceiveMessage?.Invoke(u, m));

        // Reconnect, reconnected, disconnected

        await _connection.StartAsync();
    }

    public async Task SendMessage(string user, string message)
    {
        await _connection.InvokeAsync("SendMessage", user, message );
    }
}