using BookingAndDelivery.Model;
using BookingAndDelivery.Model._21424031;
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
using System.Windows.Shapes;

namespace BookingAndDelivery.Views.Driver
{
    /// <summary>
    /// Interaction logic for frmDetailOrder.xaml
    /// </summary>
    public partial class frmDetailOrder : Window
    {
        Navigation naviFrm;
        OrderInformation order;
        User driver;
        OrderDAO031 orderDao;

        public frmDetailOrder()
        {
            InitializeComponent();
        }

        public frmDetailOrder(Navigation naviFrm,User driver,OrderInformation order)
        {
            InitializeComponent();

            this.naviFrm = naviFrm;
            this.order = order;
            this.driver = driver;
            orderDao = new OrderDAO031();

            Init();

        }
        private void Init()
        {
            txtNameCus.Text = order.nameCus;
            txtPhone.Text = order.phoneCus;
            txtAddressCus.Text = order.addressCus;
            txtAdOrder.Text = order.addressOrder;
            txtTotal.Text = order.total.ToString();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnConfirm.Content.ToString() == "Confirm")
                {

                    if (orderDao.checkProductIsOrder(driver.ID))
                    {
                        if (MessageBox.Show("Do you want to confirm this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            // Confirm deliver
                            bool isSuccess = orderDao.ConfirmTranferOrder_21424031(order.ID, driver.ID);
                            if (isSuccess)
                            {
                                btnCancel.IsEnabled = true;
                                btnConfirm.Content = "Deliver";
                                btnConfirm.Background = Brushes.Green;
                            }
                            else
                            {
                                if (orderDao.checkCancelOrder(order.ID) == true)
                                {
                                    MessageBox.Show("Confirm failure, this order canceled !!!", "Order");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Confirm failure, please try again !!!", "Order");
                                }
                                
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("You are having another order !!!", "Order");
                    }

                }
                else if (btnConfirm.Content.ToString() == "Deliver")
                {
                    if (MessageBox.Show("Do you want to deliver this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Confirm deliver
                        bool isSuccess = orderDao.setOrderStatus(order.ID, 3);
                        if (isSuccess)
                        {
                            btnConfirm.Content = "Done";
                            btnConfirm.Background = Brushes.DodgerBlue;
                        }
                        else
                        {
                            MessageBox.Show("Deliver failure, please try again !!!", "Order");
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Do you want to done this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Confirm deliver
                        bool isSuccess = orderDao.setOrderStatus(order.ID, 4);
                        if (isSuccess)
                        {
                            this.Close();
                            naviFrm.LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Done failure, please try again !!!", "Order");
                        }

                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.Message, "Error");
            }
            
        }

        private void btnConfirmFix_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnConfirm.Content.ToString() == "Confirm")
                {

                    if (orderDao.checkProductIsOrder(driver.ID))
                    {
                        if (MessageBox.Show("Do you want to confirm this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            // Confirm deliver
                            bool isSuccess = orderDao.ConfirmTranferOrderFix_21424031(order.ID, driver.ID);
                            if (isSuccess)
                            {
                                btnCancel.IsEnabled = true;
                                btnConfirm.Content = "Deliver";
                                btnConfirm.Background = Brushes.Green;
                            }
                            else
                            {
                                if(orderDao.checkCancelOrder(order.ID)==true)
                                {
                                    MessageBox.Show("Confirm failure, this order canceled !!!", "Order");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Confirm failure, please try again !!!", "Order");
                                }
                               
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("You are having another order !!!", "Order");
                    }

                }
                else if (btnConfirm.Content.ToString() == "Deliver")
                {
                    if (MessageBox.Show("Do you want to deliver this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Confirm deliver
                        bool isSuccess = orderDao.setOrderStatus(order.ID, 3);
                        if (isSuccess)
                        {
                            btnConfirm.Content = "Done";
                            btnConfirm.Background = Brushes.DodgerBlue;
                        }
                        else
                        {
                            MessageBox.Show("Deliver failure, please try again !!!", "Order");
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Do you want to done this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Confirm deliver
                        bool isSuccess = orderDao.setOrderStatus(order.ID, 4);
                        if (isSuccess)
                        {
                            this.Close();
                            naviFrm.LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Done failure, please try again !!!", "Order");
                        }

                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.Message, "Error");
            }
           
        }

        private void btnConfirmFixDL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnConfirm.Content.ToString() == "Confirm")
                {

                    if (orderDao.checkProductIsOrder(driver.ID))
                    {
                        if (MessageBox.Show("Do you want to confirm this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            // Confirm deliver
                            bool isSuccess = orderDao.ConfirmTranferOrderFix_DL_21424031(order.ID, driver.ID);
                            if (isSuccess)
                            {
                                btnCancel.IsEnabled = true;
                                btnConfirm.Content = "Deliver";
                                btnConfirm.Background = Brushes.Green;
                            }
                            else
                            {
                                if (orderDao.checkCancelOrder(order.ID) == true)
                                {
                                    MessageBox.Show("Confirm failure, this order canceled !!!", "Order");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Confirm failure, please try again !!!", "Order");
                                }

                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("You are having another order !!!", "Order");
                    }

                }
                else if (btnConfirm.Content.ToString() == "Deliver")
                {
                    if (MessageBox.Show("Do you want to deliver this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Confirm deliver
                        bool isSuccess = orderDao.setOrderStatus(order.ID, 3);
                        if (isSuccess)
                        {
                            btnConfirm.Content = "Done";
                            btnConfirm.Background = Brushes.DodgerBlue;
                        }
                        else
                        {
                            MessageBox.Show("Deliver failure, please try again !!!", "Order");
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Do you want to done this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Confirm deliver
                        bool isSuccess = orderDao.setOrderStatus(order.ID, 4);
                        if (isSuccess)
                        {
                            this.Close();
                            naviFrm.LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Done failure, please try again !!!", "Order");
                        }

                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.Message, "Error");
            }
        }

        private void btnConfirmDL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnConfirm.Content.ToString() == "Confirm")
                {

                    if (orderDao.checkProductIsOrder(driver.ID))
                    {
                        if (MessageBox.Show("Do you want to confirm this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            // Confirm deliver
                            bool isSuccess = orderDao.ConfirmTranferOrder_DL_21424031(order.ID, driver.ID);
                            if (isSuccess)
                            {
                                btnCancel.IsEnabled = true;
                                btnConfirm.Content = "Deliver";
                                btnConfirm.Background = Brushes.Green;
                            }
                            else
                            {
                                if (orderDao.checkCancelOrder(order.ID) == true)
                                {
                                    MessageBox.Show("Confirm failure, this order canceled !!!", "Order");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Confirm failure, please try again !!!", "Order");
                                }

                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("You are having another order !!!", "Order");
                    }

                }
                else if (btnConfirm.Content.ToString() == "Deliver")
                {
                    if (MessageBox.Show("Do you want to deliver this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Confirm deliver
                        bool isSuccess = orderDao.setOrderStatus(order.ID, 3);
                        if (isSuccess)
                        {
                            btnConfirm.Content = "Done";
                            btnConfirm.Background = Brushes.DodgerBlue;
                        }
                        else
                        {
                            MessageBox.Show("Deliver failure, please try again !!!", "Order");
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Do you want to done this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Confirm deliver
                        bool isSuccess = orderDao.setOrderStatus(order.ID, 4);
                        if (isSuccess)
                        {
                            this.Close();
                            naviFrm.LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Done failure, please try again !!!", "Order");
                        }

                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.Message, "Error");
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Cancel order deliver
            try
            {
                if (MessageBox.Show("Do you want to cancel this order?", "Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    // Confirm deliver
                    bool isSuccess = orderDao.setOrderStatus(order.ID, 0);
                    if (isSuccess)
                    {
                        MessageBox.Show("Cancel success", "Order");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cancel failure, please try again !!!", "Order");
                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.Message, "Error");
            }

        }
    }
}
