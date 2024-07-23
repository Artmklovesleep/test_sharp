using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_sharp.Models
{
    internal class PersonalDetail : BaseViewModel
    {
        private string _snils;
        public string snils
        {
            get => _snils;
            set
            {
                if (_snils != value)
                {
                    _snils = value;
                    OnPropertyChanged(nameof(snils));
                }
            }
        }

        private string _Adress;
        public string Adress
        {
            get => _Adress;
            set
            {
                if (_Adress != value)
                {
                    _Adress = value;
                    OnPropertyChanged(nameof(Adress));
                }
            }
        }

        private string _inn;
        public string inn
        {
            get => _inn;
            set
            {
                if (_inn != value)
                {
                    _inn = value;
                    OnPropertyChanged(nameof(inn));
                }
            }
        }
        private string _ogrnip;
        public string ogrnip
        {
            get => _ogrnip;
            set
            {
                if (_ogrnip != value)
                {
                    _ogrnip = value;
                    OnPropertyChanged(nameof(ogrnip));
                }
            }
        }
    }
}
