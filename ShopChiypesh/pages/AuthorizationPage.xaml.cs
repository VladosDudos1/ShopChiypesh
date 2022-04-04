using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ShopChiypesh.pages
{
    public partial class AuthorizationPage : Page
    {
        public static ObservableCollection<User> users { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
            login_tbx.Text = Properties.Settings.Default.Login;

            DataContext = this;
        }

        private void auto_btn_Click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<User>(BD_connection.shop.User.ToList());
            var k = users.Where(a => a.Login == login_tbx.Text && a.Password == password_tbx.Password).FirstOrDefault();
            if (k != null)
            {
                if (safe_chbx.IsChecked.GetValueOrDefault())
                {
                    Properties.Settings.Default.Login = login_tbx.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Login = null;
                    Properties.Settings.Default.Save();
                }
            }

            else MessageBox.Show("Логин или пароль введены неверно", "error", MessageBoxButton.OK, MessageBoxImage.Error);

            DataContext = this;
        }

        private void reg_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
