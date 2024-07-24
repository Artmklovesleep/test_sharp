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
using test_sharp.Models;

namespace test_sharp.Pages.ModalWindows
{
    /// <summary>
    /// Логика взаимодействия для DocumentDetailsWindow.xaml
    /// </summary>
    public partial class DocumentDetailsWindow : Window
    {
        private Person person;
        public DocumentDetailsWindow(Person _person)
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
                person.DocumentDetails.HasErrors = true;
                this.Close();
            }
            else
            {
                person.DocumentDetails.HasErrors = false;
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
                person.DocumentDetails.HasErrors = false;
                this.Close();
            }
        }

        private List<string> CheckErrors()
        {
            List<string> invalidFields = new List<string>();
            if ((Validation.GetHasError(codeDocumentTextBox)) || (string.IsNullOrEmpty(person.DocumentDetails.CodeDocument))) invalidFields.Add("Код документа");
            if ((Validation.GetHasError(nameDocumentTextBox)) || (string.IsNullOrEmpty(person.DocumentDetails.NameDocument))) invalidFields.Add("Название документа");
            if ((Validation.GetHasError(seriesDocumentTextBox)) || (string.IsNullOrEmpty(person.DocumentDetails.SeriesDocument))) invalidFields.Add("Серия документа");
            if ((Validation.GetHasError(numberDocumentTextBox)) || (string.IsNullOrEmpty(person.DocumentDetails.NumberDocument))) invalidFields.Add("Номер документа");
            if ((Validation.GetHasError(issuanceDateTextBox)) || (string.IsNullOrEmpty(person.DocumentDetails.IssuanceDate))) invalidFields.Add("Дата документа");
            if ((Validation.GetHasError(documentAuthorTextBox)) || (string.IsNullOrEmpty(person.DocumentDetails.DocumentAuthor))) invalidFields.Add("Автор документа");
            return invalidFields;
        }
    }
}
