using System;
using System.Threading.Tasks;

namespace AchillesChatClient.Services;

public interface IChatService
{
    event Action<string, string> ReceiveMessage;
    
    
    Task SendMessage(string user, string message);

    Task ConnectAsync();
}