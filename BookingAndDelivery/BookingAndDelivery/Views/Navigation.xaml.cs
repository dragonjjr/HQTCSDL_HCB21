using BookingAndDelivery.Model;
using BookingAndDelivery.Views.Orders;
using BookingAndDelivery.Views.Product;
using BookingAndDelivery.Views.Transfer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace BookingAndDelivery.Views
{
    /// <summary>
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Window
    {
        private BookingAndTransferFoodsEntities db = new BookingAndTransferFoodsEntities();
        public Navigation()
        {
            InitializeComponent();
            if(int.Parse(Application.Current.Properties["Roles"].ToString()) == 3)
            {
                ItemProduct.Visibility = Visibility.Visible;
                ItemOrder.Visibility = Visibility.Collapsed;
                ItemTransfer.Visibility = Visibility.Collapsed;
            }
            else if(int.Parse(Application.Current.Properties["Roles"].ToString()) == 4)
            {
                ItemProduct.Visibility = Visibility.Collapsed;
                ItemOrder.Visibility = Visibility.Visible;
                ItemTransfer.Visibility = Visibility.Collapsed;
            }
            else if (int.Parse(Application.Current.Properties["Roles"].ToString()) == 5)
            {
                ItemProduct.Visibility = Visibility.Collapsed;
                ItemOrder.Visibility = Visibility.Collapsed;
                ItemTransfer.Visibility = Visibility.Visible;
            }
        }

        private void ItemProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Product.Content = new ProductManagement();
        }

        private void ItemOrder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Order.Content = new OrderManagement();
        }

        private void ItemTransfer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Transfer.Content = new TransferManagement();
        }
    }
}
