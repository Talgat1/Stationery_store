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
using Stationery_store.db;

namespace Stationery_store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Stationery_storeEntities1 db = new Stationery_storeEntities1();

        public static User authUser;
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Button_ClickOpen(object sender, RoutedEventArgs e)
        {
            Authoriztion aut = new Authoriztion();
            this.Close();
            aut.Show();
        }
    }
}
