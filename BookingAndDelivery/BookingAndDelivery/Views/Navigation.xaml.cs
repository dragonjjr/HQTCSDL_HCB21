using BookingAndDelivery.Model;
using BookingAndDelivery.Model._21424031;
using BookingAndDelivery.Views.Customer;
using BookingAndDelivery.Views.Driver;
using BookingAndDelivery.Views.Orders;
using BookingAndDelivery.Views.Product;
using BookingAndDelivery.Views.Transfer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        OrderDAO031 orderDao031 = new OrderDAO031();

        public Navigation()
        {
            InitializeComponent();
            if(int.Parse(Application.Current.Properties["Roles"].ToString()) == 3)
            {
                // Long-21424031
                tProduct031.Visibility = Visibility.Collapsed;
                tOrder031.Visibility = Visibility.Collapsed;

                ItemProduct.Visibility = Visibility.Visible;
                ItemOrder.Visibility = Visibility.Collapsed;
                ItemTransfer.Visibility = Visibility.Collapsed;
            }
            else if(int.Parse(Application.Current.Properties["Roles"].ToString()) == 4)
            {
                // Long-21424031
                LoadPartner();
                tProduct031.Visibility = Visibility.Visible;
                tOrder031.Visibility = Visibility.Collapsed;

                ItemProduct.Visibility = Visibility.Collapsed;
                ItemOrder.Visibility = Visibility.Visible;
                ItemTransfer.Visibility = Visibility.Collapsed;
            }
            else if (int.Parse(Application.Current.Properties["Roles"].ToString()) == 5)
            {
                // Long-21424031
                LoadOrders();
                tProduct031.Visibility = Visibility.Collapsed;
                tOrder031.Visibility = Visibility.Visible;

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

        // Long 21424031
        public void LoadPartner()
        {
            ObservableCollection<PartnerInformation> partners = orderDao031.GetListPartner();
            lvPartner.ItemsSource = partners;
        }
        public void LoadOrders()
        {
            long userID = int.Parse(Application.Current.Properties["UserID"].ToString());
            User driver = db.Users.Where(us => us.ID == userID).Single();

            ObservableCollection<OrderInformation> orderInfos = orderDao031.getListOrderByLocation((int)driver.CityID, (int)driver.District, driver.ID);
            lvOrder.ItemsSource = orderInfos;
        }
        private void btnViewPd_Click(object sender, RoutedEventArgs e)
        {
            Button btnDetail = sender as Button;
            PartnerInformation partner = btnDetail.DataContext as PartnerInformation;

            long userID = int.Parse(Application.Current.Properties["UserID"].ToString());
            User customer = db.Users.Where(us => us.ID == userID).Single();
            frmProducts frmDetail = new frmProducts(customer, partner);
            frmDetail.Show();
        }
        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Button btnDetail = sender as Button;
            OrderInformation order = btnDetail.DataContext as OrderInformation;

            long userID = int.Parse(Application.Current.Properties["UserID"].ToString());
            User driver = db.Users.Where(us => us.ID == userID).Single();

            frmDetailOrder frmDetail = new frmDetailOrder(this, driver, order);
            frmDetail.Show();
        }

        private void tOrder031_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadOrders();
        }

        private void tProduct031_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadPartner();
        }
    }
}
