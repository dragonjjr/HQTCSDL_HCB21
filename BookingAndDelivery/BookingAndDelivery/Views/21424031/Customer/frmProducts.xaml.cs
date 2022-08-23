using BookingAndDelivery.Model;
using BookingAndDelivery.Model._21424031;
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
        OrderDAO031 orderDao;
        private User cus;
        private PartnerInformation partner;
        private ObservableCollection<ProductInformation> lstProductsOrder;

        public frmProducts()
        {
            InitializeComponent();
        }

        public frmProducts(User cus, PartnerInformation partner)
        {
            InitializeComponent();

            orderDao = new OrderDAO031();
            this.cus = cus;
            this.partner = partner;

            Init();
        }

        private void Init()
        {
            txtTotal.Text = "0";
            txtStatus.Text = "Not order";
            txtNamePn.Text = partner.name;
            cbBranch.ItemsSource = orderDao.GetListBranchByPartner(partner.ID);

        }

        private void cbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Load information products by branch
            if (cbBranch.SelectedValue != null)
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
                    long total = 0;
                    foreach (ProductInformation item in lstProductsOrder)
                    {
                        total += item.quantityBuy * item.price;
                    }
                    bool isSuccess = orderDao.orderProduct(lstProductsOrder, branch.ID, cus, (int)total);
                    if (isSuccess)
                    {
                        txtStatus.Text = "Ordered";
                        btnCancel.IsEnabled = true;
                        btnCancelFix.IsEnabled = true;
                        btnCancelDl.IsEnabled = true;
                        btnCancelDlFix.IsEnabled = true;

                        MessageBox.Show("Order success !!!", "Order");
                    }
                    else
                    {
                        MessageBox.Show("Confirm failure, please try again !!!", "Order");
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er.Message, "Error");
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
                        MessageBox.Show("Cancel success !!!", "Order");
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

        private void btnCancelFix_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // Cancel order
                    var branch = cbBranch.SelectedItem as Branch;
                    Order order = orderDao.getOrderInformation(branch.ID, cus.ID, 1);

                    bool isSuccess = orderDao.CancelOrderFix_21424031(order.ID);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cancel success !!!", "Order");
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

        private void btnCancelDl_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // Cancel order
                    var branch = cbBranch.SelectedItem as Branch;
                    Order order = orderDao.getOrderInformation(branch.ID, cus.ID, 1);

                    bool isSuccess = orderDao.CancelOrder_DL_21424031(order.ID);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cancel success !!!", "Order");
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

        private void btnCancelDlFix_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // Cancel order
                    var branch = cbBranch.SelectedItem as Branch;
                    Order order = orderDao.getOrderInformation(branch.ID, cus.ID, 1);

                    bool isSuccess = orderDao.CancelOrderFix_DL_21424031(order.ID);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cancel success !!!", "Order");
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

        private void txtQuantityBuy_MouseLeave(object sender, MouseEventArgs e)
        {
            long total = 0;
            foreach (ProductInformation item in lstProductsOrder)
            {
                total += item.quantityBuy * item.price;
            }

            txtTotal.Text = total.ToString();
        }
    }
}
