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
using Stationery_store.authoriztion;
using Stationery_store.registration;
using Stationery_store.db;
using Stationery_store.zakaz;
using Stationery_store;


namespace Stationery_store.authoriztion
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
                /*if (user.Login == LoginTB.Text.Trim() && user.Password == PasswordTB.Text.Trim())
                {
                    MessageBox.Show($"Привет Пользователь {user.Login}");
                    Vhod whod = new Vhod();
                    this.Close();
                    whod.Show();
                    break;
                }*/


                if (user.Login == LoginTB.Text.Trim())
                {
                    if (user.Password == PasswordTB.Text.Trim() && user.Id_role == 111112)
                    {
                        MessageBox.Show($"Привет Пользователь {user.Login}");
                        //MainWindow.authUser = user;
                        //MessageBox.Show($"{MainWindow.authUser}");
                        this.Close();
                        vh.Show();
                    }
                    if (user.Password == PasswordTB.Text.Trim() && user.Id_role == 111111)
                    {
                        MessageBox.Show($"Привет Сотрудник {user.Login}");
                        this.Close();
                        vh.Show();
                    }
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
