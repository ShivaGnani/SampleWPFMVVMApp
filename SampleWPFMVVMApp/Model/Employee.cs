using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SampleWPFMVVMApp.Model
{
    public class Employee : INotifyPropertyChanged, IDataErrorInfo
    {
        //private string _fullName;
        private string _firstName;
        private string _lastName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                //RaisePropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                //RaisePropertyChanged("LastName");
            }
        }


        public string FullName
        {
            get
            {
                return _firstName + " " + _lastName;
            }
            //set
            //{
            //    if (_fullName != value)
            //    {
            //        _fullName = value;
            //        RaisePropertyChanged("FullName");
            //    }
            //}
        }

        private double _salary;

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                string result = string.Empty;
                switch (propertyName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName))
                            result = "First Name cannot be empty.";
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName))
                            result = "Last Name cannot be empty.";
                        break;
                    case "Salary":
                        if (string.IsNullOrEmpty(LastName))
                            result = "Salary cannot be zero.";
                        break;
                    default:
                        result = "";
                        break;
                }
                return result;
            }
        }
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
