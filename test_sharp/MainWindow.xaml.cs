using System;
using System.Collections;
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
using test_sharp.Pages;

namespace test_sharp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(PageType.START);
        }

        public void OpenPage(PageType pageType)
        {
            switch (pageType)
            {
                case PageType.START:
                    mainFrame.Navigate(new StartPage(this));
                    break;
                case PageType.MAIN:
                    mainFrame.Navigate(new MainPage(this));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageType), pageType, null);
            }
        }

    }
}
