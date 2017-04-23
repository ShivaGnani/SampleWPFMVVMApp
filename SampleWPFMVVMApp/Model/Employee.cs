using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SampleWPFMVVMApp.Model
{
    public class Employee : IDataErrorInfo
    {
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
            }
        }


        public string FullName
        {
            get
            {
                return _firstName + " " + _lastName;
            }
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
    }
}
