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
using Stationery_store.zakaz;
using Stationery_store.db;

namespace Stationery_store.zakaz
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        
        public static Stationery_storeEntities1 db = new Stationery_storeEntities1();
        public Vhod()
        {
            InitializeComponent();
            db = new Stationery_storeEntities1();

            Zakaz.ItemsSource = db.Product.ToList();

            CollectionView vi = (CollectionView)CollectionViewSource.GetDefaultView(Zakaz.ItemsSource);
            vi.Filter = poisk;
        }
        private bool poisk(object item)
        {
            if (string.IsNullOrEmpty(Poisk.Text))
                return true;
            else 
                return (item as Product).Name.IndexOf(Poisk.Text, StringComparison.OrdinalIgnoreCase)>=0;
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Zakaz.ItemsSource).Refresh();
        }
        public int coll { get; set; } = 0;
        public int summ { get; set; } = 0;
        public int dili { get; set; } = 70002;
        public int cust { get; set; } = 1004;

        string dateString = null;

        private void Button_ClickPlPeper(object sender, RoutedEventArgs e)
        {
            foreach (var pr in MainWindow.db.Product)
            {
                if (pr.Name == NameTovar.Text.Trim())
                {
                    coll = coll + 1;
                    Coll.Text = Convert.ToString(coll);
                    Price.Text = pr.Price.ToString();
                    summ = coll * Convert.ToInt32(Price.Text);                  
                    Itog.Text = Convert.ToString(summ);                   
                }
            }
        }
        private void Button_ClickMiPeper(object sender, RoutedEventArgs e)
        {
            if (coll > 1)
            {
                coll = coll - 1;
                Coll.Text = Convert.ToString(coll);                
                summ = summ = coll * Convert.ToInt32(Price.Text);
                Itog.Text = Convert.ToString(summ);
            }           
        }

        private void Button_ClickZakaz(object sender, RoutedEventArgs e)
        {
            if (NameTovar.Text == "")
            {
                MessageBox.Show("Введите название товара");
            }
            else
            {
                Order op = new Order();
                op.Amount = coll;
                dateString = "2021-11-17 00:00:00.000";
                DateTime dateTime1 = Convert.ToDateTime(dateString);
                op.Data = dateTime1;
                op.Order_cost = Convert.ToInt32(Itog.Text);
                op.Id_employees = 40003;
                op.Id_delivery = dili + 1;
                op.Id_customer = cust + 1;
                Delivery de = new Delivery();
                de.Id_delivery = dili + 1;
                DateTime dateTime = Convert.ToDateTime(dateString);
                de.Date_delivery = dateTime;
                de.Delivered = false;
                de.Order_weight = 20;
                MainWindow.db.Order.Add(op);
                MainWindow.db.Delivery.Add(de);
                try
                {
                    MainWindow.db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка, повторите заказ еще раз!");
                    return;
                }

                finally
                {
                    MessageBox.Show("Ваш заказ оформлен успешно!");                    
                    this.Close();
                }

            }

        }
    }
}
