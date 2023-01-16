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

namespace Jewerly
{

    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        Database.user8Entities connection = new Database.user8Entities();
        public Login()
        {
            InitializeComponent();
#if DEBUG
            TextBoxLogin.Text = "9zg4lmtik3ja@yahoo.com";
            TextBoxPassword.Password = "YOyhfR";
#endif
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = connection.User.ToList();
                string login = TextBoxLogin.Text.Trim();
                string password = TextBoxPassword.Password.Trim();

                if (login.Length < 1)
                {
                    MessageBox.Show("Логин введен не правильно");
                }
                else if (password.Length < 1)
                {
                    MessageBox.Show("Пароль введен не правильно");
                }

                foreach (var _client in client)
                {
                    if (login == _client.UserLogin)
                    {
                        if (password == _client.UserPassword)
                        {
                            if (_client.UserRole == "Администратор")
                            {
                                NavigationService.Navigate(Class1.AdminPage);
                            }
                            else if (_client.UserRole == "Клиент")
                            {
                                NavigationService.Navigate(Class1.ListProduct);
                            }
                            else if (_client.UserRole == "Менеджер")
                            {
                                NavigationService.Navigate(Class1.ListProduct);

                            }
                            //  NavigationService.Navigate(Class1.ListProduct);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }      
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Class1.ListProduct);
        }
    }
}
