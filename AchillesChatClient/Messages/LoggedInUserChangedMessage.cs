using AchillesChatClient.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AchillesChatClient.Messages;

public class LoggedInUserChangedMessage : ValueChangedMessage<UserLogin>
{
    public LoggedInUserChangedMessage(UserLogin userLogin) : base(userLogin)
    {
    }
}