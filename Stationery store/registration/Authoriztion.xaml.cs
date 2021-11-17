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
using Stationery_store.registration;
using Stationery_store.db;


namespace Stationery_store.registration
{
    /// <summary>
    /// Логика взаимодействия для Authoriztion.xaml
    /// </summary>
    public partial class Authoriztion : Window
    {
        public Authoriztion()
        {
            InitializeComponent();
        }

        private void Button_ClickVhod(object sender, RoutedEventArgs e)
        {
            Vhod vh = new Vhod();
            foreach (var user in MainWindow.db.User)
            {
                if (user.Login == LoginTB.Text.Trim() && user.Password == PasswordTB.Text.Trim())
                {
                    MessageBox.Show($"Привет Пользователь {user.Login}");
                    Vhod whod = new Vhod();
                    this.Close();
                    whod.Show();
                    break;
                }
                else
                {
                    MessageBox.Show($"Неверно введён логин или пароль!");
                    break;
                }
            }
        }

        private void Button_ClickRegis(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            this.Close();
            reg.Show();
        }
    }
}
