using AvaloniaMvvmTutorial.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AvaloniaMvvmTutorial.Shared.ViewModels;

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
        Students.Add(new StudentViewModel(new Student { FirstName = "Alice", LastName = "Smith", Grade = 90 }));
        Students.Add(new StudentViewModel(new Student { FirstName = "Bob", LastName = "Johnson", Grade = 85 }));
    }

    private void AddStudent()
    {
        if (!string.IsNullOrWhiteSpace(NewStudentFirstName) && !string.IsNullOrWhiteSpace(NewStudentLastName))
        {
            var newStudent = new Student { FirstName = NewStudentFirstName, LastName = NewStudentLastName, Grade = NewStudentGrade };
            Students.Add(new StudentViewModel(newStudent));
            NewStudentFirstName = string.Empty;
            NewStudentLastName = string.Empty;
            NewStudentGrade = 0;
        }
    }
}
