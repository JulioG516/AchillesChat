using System;
using AchillesChatClient.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AchillesChatClient;

public class ViewModelLocator
{
    private readonly IServiceProvider _serviceProvider;

    public ViewModelLocator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ChatViewModel ChatViewModel => _serviceProvider.GetRequiredService<ChatViewModel>();
    
    
}