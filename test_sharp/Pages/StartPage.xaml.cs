using Microsoft.Win32;
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
using test_sharp.Enums;

namespace test_sharp.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
       
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
                // The user selected a file and pressed OK
                string selectedFileName = openFileDialog.FileName;
                MessageBox.Show("Selected file: " + selectedFileName);
            }
        }
    }
}
