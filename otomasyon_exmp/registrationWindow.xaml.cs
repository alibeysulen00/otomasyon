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
    /// Interaction logic for Kayit_window.xaml
    /// </summary>
    public partial class registrationWindow : Window
    {
        public registrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click_1(object sender, RoutedEventArgs e)
        {

           
                if (string.IsNullOrEmpty(registUser.Text) || string.IsNullOrEmpty(registPassword.Password) )
                {
                    MessageBox.Show("lütfen tüm alanları doldurun");
                }
                else
                {
                    var isUserExist = DBHelper.Instance.Users.FirstOrDefault(x => x.Username == registUser.Text);

                    if (isUserExist != null)
                    {
                        MessageBox.Show("Var olan bir kullanıcı ismi girdiniz", "Yeni Kullanıcı");
                        return;
                    }

                    var user = new User
                    {
                        Username = registUser.Text,
                        Password = registPassword.Password,
                        ManagerId = ID.Password
                    };

                    var result = DBHelper.Instance.Users.Add(user);
                    DBHelper.Instance.SaveChangesAsync();

                    if (result.State.ToString().Equals("Added"))
                    {
                        MessageBox.Show("Kullanıcı başarıyla eklendi", "Yeni Kullanıcı");
                        Close();
                    }
                    else
                        MessageBox.Show($"Kullanıcı eklenemedi veritabanı durumu = {result.State.ToString()}", "Kullanıcı Eklenemedi");
                }
            }

      

        private void userLogin(object sender, TextChangedEventArgs e)
        {

        }
    }
    }
            
            
        

       
