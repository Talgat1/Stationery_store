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
    public partial class Authoriztion : Page
    {
        public Authoriztion()
        {
            InitializeComponent();
        }

        private void Button_ClickVhod(object sender, RoutedEventArgs e)
        {
            //Vhod vh = new Vhod();
            foreach (var user in MainWindow.db.User)
            {
                if (user.Login == LoginTB.Text.Trim())
                {
                    //if (user.Password == PasswordTB.Password.Trim() && user.RoleID == 2)
                    {
                        MessageBox.Show($"Привет Пользователь {user.Login}");
                        MainWindow.authUser = user;
                        MessageBox.Show($"{MainWindow.authUser}");
                    }
                    //if (user.Password == PasswordTB.Password.Trim() && user.RoleID == 1)
                    {
                        MessageBox.Show($"Привет админ {user.Login}");

                    }
                }
            }
        }
    }
}
