using System;
using AchillesChatClient.Services;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AchillesChatClient.ViewModels;
using AchillesChatClient.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AchillesChatClient;

public partial class App : Application
{
    private IServiceProvider _serviceProvider;
    private IServiceCollection _service = new ServiceCollection();

    public App()
    {
        _service.AddSingleton<IChatService, ChatService>();
        _service.AddSingleton<MainWindowViewModel>();

        _serviceProvider = _service.BuildServiceProvider();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            var mainWindowViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}