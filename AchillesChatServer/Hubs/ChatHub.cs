using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace AchillesChatServer.Hubs;

[SignalRHub]
public class ChatHub : Hub
{
    /// <summary>
    /// Current logged users with string username and List of Users object.
    /// </summary>
    private static ConcurrentDictionary<string, List<string>> ChatClients = new();

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}