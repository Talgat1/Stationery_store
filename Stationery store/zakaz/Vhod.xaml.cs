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

       public static Stationery_storeEntities2 db = new Stationery_storeEntities2();
        public Vhod()
        {
            InitializeComponent();
            db = new Stationery_storeEntities2();

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
        private void Button_ClickPlPeper(object sender, RoutedEventArgs e)
        {
            Itog.Text = (int.Parse(Itog.Text) + 20).ToString();
            SumPeper = +1;
        }
        private void Button_ClickMiPeper(object sender, RoutedEventArgs e)
        {
            Itog.Text = (int.Parse(Itog.Text) - 20).ToString();
            SumPeper = -1;
        }
    }
}
