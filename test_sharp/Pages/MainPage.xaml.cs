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

namespace test_sharp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainWindow mainWindow;
        public MainPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void personalDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            PersonalDetailsWindow personalDetailsWindow = new PersonalDetailsWindow();
            personalDetailsWindow.ShowDialog();
        }
        private void documentDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            DocumentDetailsWindow documentDetailsWindow = new DocumentDetailsWindow();
            documentDetailsWindow.ShowDialog();
        }
        private void clearAllButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void saveToXmlButtonClick(object sender, RoutedEventArgs e)
        {

        }


    }
}
