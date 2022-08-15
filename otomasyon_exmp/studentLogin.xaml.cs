using Microsoft.Extensions.Logging;
using Microsoft.Owin.Security.Infrastructure;
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

namespace otomasyon_exmp
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class studentLogin : Window
    {
        public studentLogin()
        {
            InitializeComponent();
            Closing += studentLoginClick_Closing;
        }

        private void studentLoginClick_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //checkbox işaretlenmediği sürece açılan öğrenci ekranı kapatılamayacak
            if (Onaylandı.IsChecked == false)
            {
                e.Cancel = true;
            }
        }

        private void StudentLoginClick(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(studentUser.Text) || string.IsNullOrEmpty(studentPassword.Password) || string.IsNullOrEmpty(kontrol.Text ) || string.IsNullOrEmpty(ogrenci_ID.Text))
            { 
                MessageBox.Show("lütfen tüm alanları doldurun");
            }
            else
            {
                var user = DBHelper.Instance.Users.FirstOrDefault(x => x.Username == studentUser.Text);


                if (user != null && VerifyHash(studentPassword.Password, user.Password) && kontrol.Text.Equals("10") && user.ManagerId.Equals(ogrenci_ID.Text))
                {
                    
                    MessageBox.Show( "Kullanıcı girişi başarılı");
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("hatalı");

                }
            }
            

        }

        public static bool VerifyHash(string input, string input2)
        {
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(input, input2) == 0;


        }



        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void userLogin(object sender, RoutedEventArgs e)
        {

        }

        private void studentUserLogin(object sender, TextChangedEventArgs e)
        {

        }
    }
    }

