using AvaloniaMvvmTutorial.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaMvvmTutorial.Shared.ViewModels
{
    public partial class StudentViewModel : ViewModelBase
    {
        private readonly Student _student;

        public string? FirstName
        {
            get => _student.FirstName;
            set => SetProperty(_student.FirstName, value, _student, (model, val) => model.FirstName = val);
        }

        public string? LastName
        {
            get => _student.LastName;
            set => SetProperty(_student.LastName, value, _student, (model, val) => model.LastName = val);
        }

        public int Grade
        {
            get => _student.Grade;
            set => SetProperty(_student.Grade, value, _student, (model, val) => model.Grade = val);
        }

        public string DisplayName => $"{FirstName} {LastName}";
        public string FullInfo => $"{FirstName} {LastName} - Grade: {Grade}";

        public StudentViewModel(Student student)
        {
            _student = student;
        }
    }
}
