using AvaloniaMvvmTutorial.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AvaloniaMvvmTutorial.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? _newStudentFirstName;

    [ObservableProperty]
    private string? _newStudentLastName;

    [ObservableProperty]
    private int _newStudentGrade;

    public ObservableCollection<StudentViewModel> Students { get; } = new();

    public ICommand AddStudentCommand { get; }

    public MainWindowViewModel()
    {
        AddStudentCommand = new RelayCommand(AddStudent);

        // Add some sample students for demonstration
        Students.Add(new StudentViewModel(new Student { FirstName = "Alice", LastName = "Smith", Grade = 90 }));
        Students.Add(new StudentViewModel(new Student { FirstName = "Bob", LastName = "Johnson", Grade = 85 }));
        Students.Add(new StudentViewModel(new Student { FirstName = "Charlie", LastName = "Brown", Grade = 95 }));
    }

    private void AddStudent()
    {
        if (!string.IsNullOrWhiteSpace(NewStudentFirstName) &&
            !string.IsNullOrWhiteSpace(NewStudentLastName))
        {
            var newStudent = new Student
            {
                FirstName = NewStudentFirstName,
                LastName = NewStudentLastName,
                Grade = NewStudentGrade
            };
            Students.Add(new StudentViewModel(newStudent));

            // Clear input fields after adding
            NewStudentFirstName = string.Empty;
            NewStudentLastName = string.Empty;
            NewStudentGrade = 0; // Reset grade to default
        }
        // Optional: Add some error handling or notification if input is invalid
    }
}
