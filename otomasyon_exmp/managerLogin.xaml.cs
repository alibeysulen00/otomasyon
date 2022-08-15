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
    public partial class managerLogin : Window
    {
        public managerLogin()
        {
            InitializeComponent();
        }

     
        private void managerLoginClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(managerUser.Text) || string.IsNullOrEmpty(managerPassword.Text) || string.IsNullOrEmpty(managerID.Password)  )
            {
                MessageBox.Show("lütfen tüm alanları doldurun");
            }
            else
            {
                var user = DBHelper.Instance.Users.FirstOrDefault(x => x.Username == managerUser.Text );


                if (user != null && VerifyHash(managerPassword.Text, user.Password) && user.ManagerId.Equals(managerID.Password))
                {

                    MessageBox.Show( "Kullanıcı girişi başarılı");
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");

                }
            }
        }
        public static bool VerifyHash(string input, string input2)
        {
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(input, input2) == 0;


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
