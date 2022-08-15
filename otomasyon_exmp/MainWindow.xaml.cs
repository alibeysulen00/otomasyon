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

namespace otomasyon_exmp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await DBHelper.InitDb();
        }

        private void studentLoginClick(object sender, RoutedEventArgs e)
        {
            var window2 = new studentLogin();
            window2.ShowDialog();
        }

        private void managerLoginClick(object sender, RoutedEventArgs e)
        {

            var window1 = new managerLogin();
            window1.ShowDialog();
            
        }

        private void registrationClick(object sender, RoutedEventArgs e)
        {
            var window3 = new registrationWindow();
            window3.ShowDialog();
        }
    }
}
