using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaMvvmTutorial.Shared.ViewModels; // Changed namespace

namespace AvaloniaMvvmTutorial.Shared; // Changed namespace

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is null)
            return null;

        // Example: param is AvaloniaMvvmTutorial.Shared.ViewModels.MainWindowViewModel
        // name becomes AvaloniaMvvmTutorial.Shared.Views.MainView
        var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type != null)
        {
            // This will create an instance of MainView when MainWindowViewModel is passed.
            return (Control)Activator.CreateInstance(type)!;
        }
        else
        {
            // A more specific error message might be helpful for debugging
            return new TextBlock { Text = "View Not Found: " + name };
        }
    }

    public bool Match(object? data)
    {
        // This ensures the ViewLocator is only used for objects that inherit from ViewModelBase
        return data is ViewModelBase;
    }
}
