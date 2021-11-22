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

namespace Stationery_store.zakaz
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        
        public static Stationery_storeEntities db = new Stationery_storeEntities();
        public Vhod()
        {
            InitializeComponent();
            db = new Stationery_storeEntities();

            Zakaz.ItemsSource = db.Product.ToList();

            CollectionView vi = (CollectionView)CollectionViewSource.GetDefaultView(Zakaz.ItemsSource);
            vi.Filter = poisk;
        }
        private bool poisk(object item)
        {
            if (String.IsNullOrEmpty(Poisk.Text))
                return true;
            else 
                return ((item as Product).Name.IndexOf(Poisk.Text, StringComparison.OrdinalIgnoreCase)>=0);
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Zakaz.ItemsSource).Refresh();
        }
        int SumPeper = 0;
        public int itog { get; set; } = 0;
        
        private void Button_ClickPlPeper(object sender, RoutedEventArgs e)
        {
            itog = itog + 20;
            Itog.Text = Convert.ToString(itog);           
            SumPeper = +1;
            Order order = new Order();
            order.Data = Convert.ToDateTime(2021-11-22);
            order.Amount = SumPeper;
            order.Order_cost = itog;
            order.Id_employees = 40003;
        }
        private void Button_ClickMiPeper(object sender, RoutedEventArgs e)
        {
            itog = itog - 20;
            Itog.Text = Convert.ToString(itog);
            SumPeper = -1;
        }
    }
}
