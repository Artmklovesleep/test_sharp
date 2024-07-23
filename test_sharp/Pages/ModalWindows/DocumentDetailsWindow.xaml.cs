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
        private Document document;
        public DocumentDetailsWindow()
        {
            InitializeComponent();
            document = new Document();
            this.DataContext = document;

        }
    
        private void cancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Пользователь {document.DocumentAuthor}");
        }
    }
}
