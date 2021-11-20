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
using Stationery_store.db;
using Stationery_store.authoriztion;
using Stationery_store;

namespace Stationery_store.registration
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_ClickRegis(object sender, RoutedEventArgs e)
        {
            if (SurnameTB.Text == "" || NameTB.Text == "" || PhoneTB.Text == "" || AgeTB.Text == "" || adressTB.Text == "" || LoginTB.Text == "" || PasswordTB.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                try
                {
                    Сustomer customer = new Сustomer();
                    customer.Name = NameTB.Text;
                    customer.Surname = SurnameTB.Text;
                    customer.Phone = PhoneTB.Text;
                    customer.Age = Convert.ToInt32(AgeTB.Text);
                    customer.address = adressTB.Text;
                    User user = new User();
                    user.Login = LoginTB.Text;
                    user.Password = PasswordTB.Text;
                    user.Id_role = 111112;
                    MainWindow.db.User.Add(user);
                    MainWindow.db.Сustomer.Add(customer);
                    MainWindow.db.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрированы, теперь войдите в приложение.");
                    MainWindow win = new MainWindow();
                    this.Close();
                    win.Show();
                }
                catch
                {
                    foreach (var user in MainWindow.db.User)
                    {
                        if (user.Login == LoginTB.Text.Trim())
                        {
                            MessageBox.Show("Такой логин уже существет, введите другой");
                        }
                    }

                }                
            }
        }

        private void Button_ClickNazad(object sender, RoutedEventArgs e)
        {
            Authoriztion aut = new Authoriztion();
            this.Close();
            aut.Show();
        }
    }
}
