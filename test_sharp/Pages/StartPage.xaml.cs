using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using test_sharp.Enums;
using test_sharp.Models;

namespace test_sharp.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private Person person;
        public MainWindow mainWindow;
        public StartPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void createButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(PageType.MAIN);
        }
        private void openButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.Title = "Выберите xml фаил";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string selectedFileName = openFileDialog.FileName;

                try
                {
                    var serializer = new XmlSerializer(typeof(Person));
                    using (var writer = new FileStream(selectedFileName, FileMode.OpenOrCreate))
                    {
                        person = (Person)serializer.Deserialize(writer);
                    }
                    mainWindow.OpenPage(PageType.MAIN, person);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии XML");
                }
                
            }
        }
    }
}
