using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using AvaloniaMvvmTutorial.Shared.ViewModels; // Changed namespace
using AvaloniaMvvmTutorial.Shared.Views;   // Changed namespace

namespace AvaloniaMvvmTutorial.Shared; // Changed namespace

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Create the MainWindowViewModel. This will be our main DataContext.
        var vm = new MainWindowViewModel();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0); // Simpler way to remove default DataAnnotationsValidationPlugin

            // The Desktop project will have its own MainWindow type.
            // We set its DataContext here. The ViewLocator will handle displaying MainView.
            desktop.MainWindow = new AvaloniaMvvmTutorial.Shared.Views.MainWindow // This refers to the Desktop's MainWindow if it's moved/referenced, or a generic one
            {
                DataContext = vm
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            BindingPlugins.DataValidators.RemoveAt(0);
            // For mobile and browser, we directly set MainView with the ViewModel.
            singleViewPlatform.MainView = new MainView
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
