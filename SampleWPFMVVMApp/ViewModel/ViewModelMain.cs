using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SampleWPFMVVMApp.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SampleWPFMVVMApp.Command;

namespace SampleWPFMVVMApp.ViewModel
{
    public class ViewModelMain : INotifyPropertyChanged
    {

        private Employee _employee;
        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                RaisePropertyChanged("Employees");
            }
        }
        public ICommand AddEmployeeCommand { get; set; }

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                RaisePropertyChanged("Employee");
            }
        }

        private Employee _selectedItem;

        public Employee SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }


        public ViewModelMain()
        {
            Employee = new Employee();
            Employees = new ObservableCollection<Employee>();
            Employees.Add(new Employee() { FirstName= "Tom", LastName= "Hanks", Salary= 12 });
            Employees.Add(new Employee() { FirstName = "Leonardo", LastName = "DeCaprio", Salary = 22 });
            Employees.Add(new Employee() { FirstName = "Robert", LastName = "Downey", Salary = 50 });
            AddEmployeeCommand = new RelayCommand(AddEmployee, CanAddEmployee);
           // SelectedItem = "Select";
        }
        private void AddEmployee(object parameter)
        {
            Employees.Add(Employee);
        }

        private bool CanAddEmployee(object parameter)
        {
            if (string.IsNullOrEmpty(Employee.FirstName) || string.IsNullOrEmpty(Employee.LastName))
                return false;
            else
                return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }


    }
}
