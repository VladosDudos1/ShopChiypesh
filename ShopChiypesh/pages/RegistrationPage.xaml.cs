using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ShopChiypesh.pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public static ObservableCollection<User> Users { get; set; }
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Reg_event(object sender, RoutedEventArgs e)
        {

        }

        private void Sign_event(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
        private void Save_event(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[^a-zA-Z0-9])\S{6,16}$");

            MatchCollection matches = regex.Matches(txt_password.ToString());

            if (matches.Count > 1)
            {
                try
                {
                    User a = new User
                    {
                        Login = txt_login.Text,
                        Password = txt_password.ToString(),
                        RoleId = 3
                    };
                    BD_connection.shop.User.Add(a);
                    BD_connection.shop.SaveChanges();
                    MessageBox.Show("OK");
                    NavigationService.GoBack();
                }
                catch (Exception)
                {
                    throw new Exception("Error");
                }
            }
            else
            {
                MessageBox.Show("Придумай пароль получше");
            }

        }

        private void Cancel_event(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
