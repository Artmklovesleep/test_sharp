using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_sharp.Models
{
    public class Person : BaseViewModel
    {
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string _middleName;
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged(nameof(MiddleName));
                }
            }
        }
    }

}
