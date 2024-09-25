using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Module0Exercise0.Model;
using Microsoft.Maui.Controls; // Make sure to include this for Shell navigation

namespace Module0Exercise0.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _employee;
        private string _fullName;

        public EmployeeViewModel()
        {
            _employee = new Employee
            {
                FirstName = "Erreh",
                LastName = "Nyeger",
                Position = "Admin",
                Department = "CCS",
                IsActive = true
            };

            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            // Command to navigate to Add Employee page
            AddEmployeeCommand = new Command(NavigateToAddEmployee);

            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName="Patrick", LastName="Pistacio", Position = "President", Department = "CCS", IsActive = true},
                new Employee {FirstName="Alyssa", LastName="Bartolomew", Position = "Vice President", Department = "CCS", IsActive = true},
                new Employee {FirstName="Yeetza", LastName="Maisip", Position = "Treasurer", Department = "CCS", IsActive = true}
            };
        }

        // Property for Employees collection
        public ObservableCollection<Employee> Employees { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        // Command for loading employee data
        public ICommand LoadEmployeeDataCommand { get; }

        // Command for navigating to Add Employee page
        public ICommand AddEmployeeCommand { get; }

        // Load Employee Data
        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); // Simulating I/O operation
            FullName = $"{_employee.FirstName} {_employee.LastName} {_employee.Position} {_employee.Department}";
        }

        // Navigate to AddEmployee page
        private async void NavigateToAddEmployee()
        {
            await Shell.Current.GoToAsync("//AddEmployee"); // Ensure the route matches with your AppShell
        }

        // Event to notify property changes
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
