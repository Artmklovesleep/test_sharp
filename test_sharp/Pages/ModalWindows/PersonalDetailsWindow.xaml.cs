using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using test_sharp.Models;

namespace test_sharp.Pages.ModalWindows
{
    /// <summary>
    /// Логика взаимодействия для PersonalDetailsWindow.xaml
    /// </summary>
    public partial class PersonalDetailsWindow : Window
    {
        private Person person;
        public PersonalDetailsWindow(Person _person)
        {
            InitializeComponent();
            person = _person;
            this.DataContext = person;
        }

        private void cancelButtonClick(object sender, RoutedEventArgs e)
        {
            List<string> invalidFields = CheckErrors();
            if (invalidFields.Count > 0)
            {
                person.PersonalInfo.HasErrors = true;
                this.Close();
            }
            else
            {
                person.PersonalInfo.HasErrors = false;
                this.Close();
            }
        }

        private void saveButtonClick(object sender, RoutedEventArgs e)
        {
            List<string> invalidFields = CheckErrors();
            if (invalidFields.Count > 0)
            {
                string errorMessage = "Есть ошибки в следующих полях:\n";
                errorMessage += string.Join("\n", invalidFields);
                MessageBox.Show(errorMessage);
            }
            else
            {
                person.PersonalInfo.HasErrors = false;
                this.Close();
            }
        }

        private List<string> CheckErrors()
        {
            List<string> invalidFields = new List<string>();
            if ((Validation.GetHasError(snilsTextBox)) || (string.IsNullOrEmpty(person.PersonalInfo.Snils))) invalidFields.Add("СНИЛС");
            if ((Validation.GetHasError(adressTextBox)) || (string.IsNullOrEmpty(person.PersonalInfo.Adress))) invalidFields.Add("Адрес");
            if ((Validation.GetHasError(innTextBox))  || (string.IsNullOrEmpty(person.PersonalInfo.Inn)))invalidFields.Add("ИНН");
            if ((Validation.GetHasError(ogrnipTextBox)) || (string.IsNullOrEmpty(person.PersonalInfo.Ogrnip))) invalidFields.Add("ОГРНИП");
            return invalidFields;
        }
    }
}
