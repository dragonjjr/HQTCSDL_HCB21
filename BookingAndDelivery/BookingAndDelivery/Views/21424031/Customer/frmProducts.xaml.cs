using BookingAndDelivery.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BookingAndDelivery.Views.Customer
{
    /// <summary>
    /// Interaction logic for frmProducts.xaml
    /// </summary>
    public partial class frmProducts : Window
    {
        OrderDAO orderDao;
        private User cus;
        private NavigationCustomer naviCus;
        private PartnerInformation partner;
        private ObservableCollection<ProductInformation> lstProductsOrder;

        public frmProducts()
        {
            InitializeComponent();
        }

        public frmProducts(NavigationCustomer naviCus, User cus, PartnerInformation partner)
        {
            InitializeComponent();

            orderDao = new OrderDAO();
            this.cus = cus;
            this.naviCus = naviCus;
            this.partner = partner;

            Init();
        }

        private void Init()
        {
            txtStatus.Text = "Not order";
            txtNamePn.Text = partner.name;
            cbBranch.ItemsSource = orderDao.GetListBranchByPartner(partner.ID);

        }

        private void cbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Load information products by branch
            if(cbBranch.SelectedValue != null)
            {
                var branch = cbBranch.SelectedItem as Branch;
                txtAddress.Text = branch.Address;

                lstProductsOrder = orderDao.GetListProductByBranch(branch.ID);
                lvProducts.ItemsSource = lstProductsOrder;
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to order these products?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // Order products
                    var branch = cbBranch.SelectedItem as Branch;
                    bool isSuccess = orderDao.orderProduct(lstProductsOrder, branch.ID, cus, 100);
                    if (isSuccess)
                    {
                        txtStatus.Text = "Ordered";
                        btnCancel.IsEnabled = true;
                        MessageBox.Show("Order success !!!", "Order");
                    }
                    else
                    {
                        MessageBox.Show("Confirm failure, please try again !!!", "Order");
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: "+er.Message, "Error");
                }

            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Do you want to cancel this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // Cancel order
                    var branch = cbBranch.SelectedItem as Branch;
                    Order order = orderDao.getOrderInformation(branch.ID, cus.ID, 1);

                    bool isSuccess = orderDao.CancelOrder_21424031(order.ID);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cancel success !!!","Order");
                    }
                    else
                    {
                        MessageBox.Show("Cancel failure, please try again !!!", "Order");
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er.Message, "Error");
                }

            }
        }
    }
}
