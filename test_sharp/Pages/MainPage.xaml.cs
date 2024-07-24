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
using System.Windows.Navigation;
using System.Windows.Shapes;
using test_sharp.Pages.ModalWindows;
using test_sharp.Models;
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;

namespace test_sharp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainWindow mainWindow;
        private Person person;
        private DocumentDetailsWindow _documentDetailsWindow;
        private PersonalDetailsWindow _personalDetailsWindow;

        public MainPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            person = new Person();
            this.DataContext = person;
        }

        public MainPage(MainWindow _mainWindow, Person _person)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            person = _person;
            this.DataContext = person;
        }

        private void personalDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            PersonalDetailsWindow personalDetailsWindow = new PersonalDetailsWindow(person);
            _personalDetailsWindow = personalDetailsWindow;
            personalDetailsWindow.ShowDialog();
        }
        private void documentDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            DocumentDetailsWindow documentDetailsWindow = new DocumentDetailsWindow(person);
            _documentDetailsWindow = documentDetailsWindow;
            documentDetailsWindow.ShowDialog();
        }
        private void clearAllButtonClick(object sender, RoutedEventArgs e)
        {
            person.Clear();
        }
        private void saveToXmlButtonClick(object sender, RoutedEventArgs e)
        {
            List<string> invalidFields = GetInvalidFields();
            if (invalidFields.Count > 0)
            {
                string errorMessage = "Есть ошибки в следующих полях:\n";
                errorMessage += string.Join("\n", invalidFields);
                MessageBox.Show(errorMessage);
            }
         
            else
            {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "XML Files (*.xml)|*.xml",
                            DefaultExt = "xml",
                            Title = "Сохранить XML файл"
                        };

                if (saveFileDialog.ShowDialog() == true)
                {

                    string filePath = saveFileDialog.FileName;


                    var serializer = new XmlSerializer(typeof(Person));
                    using (var writer = new StreamWriter(filePath))
                    {
                        var personToSerialize = new Person
                        {
                            LastName = person.LastName,
                            FirstName = person.FirstName,
                            MiddleName = person.MiddleName,
                            PersonalInfo = person.PersonalInfo.ShouldSerialize() ? person.PersonalInfo : null,
                            DocumentDetails = person.DocumentDetails.ShouldSerialize() ? person.DocumentDetails : null
                        };

                        serializer.Serialize(writer, personToSerialize);
                    }

                    MessageBox.Show("Файл сохранен успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private List<string> GetInvalidFields()
        {
            List<string> invalidFields = new List<string>();
            if ((Validation.GetHasError(firstNameTextBox))|| (string.IsNullOrEmpty(person.FirstName))) invalidFields.Add("Имя");
            if ((Validation.GetHasError(lastNameTextBox)) || (string.IsNullOrEmpty(person.LastName))) invalidFields.Add("Фамилия");
            if ((Validation.GetHasError(middleNameTextBox)) || (string.IsNullOrEmpty(person.MiddleName))) invalidFields.Add("Отчество");
            if (person.PersonalInfo.ShouldSerialize())
            {
                if (person.PersonalInfo.HasErrors) invalidFields.Add("Ошибки в окне Персональной информации");
            }
            if (person.DocumentDetails.ShouldSerialize())
            {
                if (person.DocumentDetails.HasErrors) invalidFields.Add("Ошибки в окне Информации о документе");
            }

            return invalidFields;
        }
    }
}
