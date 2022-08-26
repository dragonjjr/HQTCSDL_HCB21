using BookingAndDelivery.Model;
using BookingAndDelivery.Model._21424031;
using BookingAndDelivery.Views._21424028;
using BookingAndDelivery.Views._21424028.Customer;
using BookingAndDelivery.Views._21424028.Partner;
using BookingAndDelivery.Views._21424028.Staff;
using BookingAndDelivery.Views._21424032;
using BookingAndDelivery.Views._21424069._21424069_Product;
using BookingAndDelivery.Views._21424069._21424069_Staff;
using BookingAndDelivery.Views.Customer;
using BookingAndDelivery.Views.Driver;
using BookingAndDelivery.Views.Orders;
using BookingAndDelivery.Views.Product;
using BookingAndDelivery.Views.Transfer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
            if (int.Parse(Application.Current.Properties["Roles"].ToString()) == 1)
            {
                tProduct031.Visibility = Visibility.Collapsed;
                tOrder031.Visibility = Visibility.Collapsed;
                ItemProduct.Visibility = Visibility.Collapsed;
                ItemOrder.Visibility = Visibility.Collapsed;
                ItemTransfer.Visibility = Visibility.Collapsed;
                ItemContractInfo.Visibility = Visibility.Collapsed;
                ItemOrderProduct.Visibility = Visibility.Collapsed;
                ItemUpdateProduct.Visibility = Visibility.Collapsed;
                ItemContractManagement.Visibility = Visibility.Collapsed;

                ItemProduct_21424069.Visibility = Visibility.Collapsed;
                SearchProduct_21424069.Visibility = Visibility.Collapsed;
                Staff_21424069.Visibility = Visibility.Visible;
                StaffManage_21424069.Visibility = Visibility.Visible;

                //21424032
                Order32.Visibility = Visibility.Collapsed;
                Contract32.Visibility = Visibility.Collapsed;
                
            }
            else if (int.Parse(Application.Current.Properties["Roles"].ToString()) == 2)
            {
                tProduct031.Visibility = Visibility.Collapsed;
                tOrder031.Visibility = Visibility.Collapsed;
                ItemProduct.Visibility = Visibility.Collapsed;
                ItemOrder.Visibility = Visibility.Collapsed;
                ItemTransfer.Visibility = Visibility.Collapsed;
                ItemContractInfo.Visibility = Visibility.Collapsed;
                ItemOrderProduct.Visibility = Visibility.Collapsed;
                ItemUpdateProduct.Visibility = Visibility.Collapsed;
                SearchProduct_21424069.Visibility = Visibility.Collapsed;
                Staff_21424069.Visibility = Visibility.Collapsed;
                StaffManage_21424069.Visibility = Visibility.Collapsed;
                ItemProduct_21424069.Visibility = Visibility.Collapsed;

                ItemContractManagement.Visibility = Visibility.Visible;

                //21424032
                Order32.Visibility = Visibility.Collapsed;
                Contract32.Visibility = Visibility.Collapsed;
            }
            else if (int.Parse(Application.Current.Properties["Roles"].ToString()) == 3)
            {
                // Long-21424031
                tProduct031.Visibility = Visibility.Collapsed;
                tOrder031.Visibility = Visibility.Collapsed; 

                ItemProduct.Visibility = Visibility.Visible;
                ItemOrder.Visibility = Visibility.Collapsed;
                ItemTransfer.Visibility = Visibility.Collapsed;

                ItemOrderProduct.Visibility = Visibility.Collapsed;
                ItemContractManagement.Visibility = Visibility.Collapsed;
                ItemContractInfo.Visibility = Visibility.Visible;
                ItemUpdateProduct.Visibility = Visibility.Visible;

                SearchProduct_21424069.Visibility = Visibility.Collapsed;
                Staff_21424069.Visibility = Visibility.Collapsed;
                StaffManage_21424069.Visibility = Visibility.Collapsed;
                ItemProduct_21424069.Visibility = Visibility.Visible;

                //21424032
                Order32.Visibility = Visibility.Visible;
                Contract32.Visibility = Visibility.Visible;
                buttonDeleteContract21424032.Visibility = Visibility.Collapsed;
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


                ItemContractInfo.Visibility = Visibility.Collapsed;
                ItemUpdateProduct.Visibility = Visibility.Collapsed;
                ItemContractManagement.Visibility = Visibility.Collapsed;
                ItemOrderProduct.Visibility = Visibility.Visible;

                ItemProduct_21424069.Visibility = Visibility.Collapsed;
                Staff_21424069.Visibility = Visibility.Collapsed;
                StaffManage_21424069.Visibility = Visibility.Collapsed;
                SearchProduct_21424069.Visibility = Visibility.Visible;

                //21424032
                Order32.Visibility = Visibility.Visible;
                Contract32.Visibility = Visibility.Visible;
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

                ItemContractInfo.Visibility = Visibility.Collapsed;
                ItemUpdateProduct.Visibility = Visibility.Collapsed;
                ItemContractManagement.Visibility = Visibility.Collapsed;
                ItemOrderProduct.Visibility = Visibility.Collapsed;

                SearchProduct_21424069.Visibility = Visibility.Collapsed;
                Staff_21424069.Visibility = Visibility.Collapsed;
                StaffManage_21424069.Visibility = Visibility.Collapsed;
                ItemProduct_21424069.Visibility = Visibility.Collapsed;

                //21424032
                Order32.Visibility = Visibility.Visible;
                Contract32.Visibility = Visibility.Visible;
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

        private void OrderProduct_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Customer028.Content = new OrderProduct();
        }

        private void ContractInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Partner1028.Content = new ContractInfo();
        }

        private void UpdateProduct_Click(object sender, MouseButtonEventArgs e)
        {
            Partner2028.Content = new UpdateProduct();
        }

        private void ContractManagement_Click(object sender, MouseButtonEventArgs e)
        {
            ContractManagement028.Content = new ContractManagement();
        }

        private void ItemProduct_21424069_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Product_21424069.Content = new _21424069_ProductManagement();
        }

        private void SearchProduct_21424069_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SearchProductItem_21424069.Content = new _21424069_ProductInfo();
        }

        private void Staff_21424069_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StaffInfo_21424069.Content = new _21424069_StaffList();
        }

        private void StaffManage_21424069_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StaffManagement_21424069.Content = new _21424069_StaffManagement();
        }

        private void buttonAddProductDetail21424032_Click(object sender, RoutedEventArgs e)
        {
            BookingAndTransferFoodsEntities db = new BookingAndTransferFoodsEntities();
            if (productListview32.SelectedItem != null)
            {
                var productSelected = productListview32.SelectedItem as BookingAndDelivery.Model.Product;
                var selected = (from pb in db.ProductBranches
                                join b in db.Branches on pb.BranchID equals b.ID
                                where productSelected.ID == pb.ProductID
                                select new
                                {
                                    b.ID,
                                    pb.Quantity,
                                    b.Branchname
                                }).ToList();
                OrderDetail od = new OrderDetail();
                od.ProductID = productSelected.ID;
                double tt = 0;
                var outParam = new SqlParameter("@TONGTIEN", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                // var temp = db.Database.ExecuteSqlCommand("EXEC USP_DIRTY_READ @ORDER_ID,@TONGTIEN OUT", new SqlParameter("@ORDER_ID", 1), outParam);
                var returnCode = new SqlParameter("@ReturnCode", SqlDbType.Int);
                returnCode.Direction = ParameterDirection.Output;

                //var test = db.Database.SqlQuery<double>("EXEC @ReturnCode = USP_DIRTY_READ @ORDER_ID,@TONGTIEN OUT", returnCode, new SqlParameter("@ORDER_ID", 1), outParam);
                db.Database.ExecuteSqlCommand("EXEC @ReturnCode =  USP_21424032_DIRTY_UPDATE @ORDER_ID,@PRODUCT_ID,@QUANTITY,@PRICE", returnCode, new SqlParameter("@ORDER_ID", 5),
                    new SqlParameter("@PRODUCT_ID", productSelected.ID), new SqlParameter("@QUANTITY", Int32.Parse(quantityProduct32.Text)), new SqlParameter("@PRICE", productSelected.Price));

                if ((int)returnCode.Value == 1)
                {
                    MessageBox.Show("Loi");
                }

            }
        }

        private void buttonSeeOrder21424032_Click(object sender, RoutedEventArgs e)
        {
            Order32 oder32 = new Order32();
            oder32.Show();
        }

        private void buttonSeeOrderFix21424032_Click(object sender, RoutedEventArgs e)
        {
            Order32Fix oder32fix = new Order32Fix();
            oder32fix.Show();
        }

        private void buttonSeeContractFix21424032_Click(object sender, RoutedEventArgs e)
        {
            //contractListview.ItemsSource = db.Contracts.ToList();
            var outParam = new SqlParameter("@SOLUONG", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            var returnCode = new SqlParameter("@ReturnCode", SqlDbType.Int);
            returnCode.Direction = ParameterDirection.Output;
            //db.Database.ExecuteSqlCommand("EXEC USP_READ_DATA_CONTRACT @SOLUONG", outParam);
            contractListview21424032.ItemsSource = db.Database.SqlQuery<Contract>("EXEC @ReturnCode = USP_21424032_READ_DATA_CONTRACT_FIX", returnCode).ToList();
            tbSumFee.Text = returnCode.Value.ToString();
        }

        private void buttonSeeContract21424032_Click(object sender, RoutedEventArgs e)
        {
            //contractListview.ItemsSource = db.Contracts.ToList();
            var outParam = new SqlParameter("@SOLUONG", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            var returnCode = new SqlParameter("@ReturnCode", SqlDbType.Int);
            returnCode.Direction = ParameterDirection.Output;
            //db.Database.ExecuteSqlCommand("EXEC USP_READ_DATA_CONTRACT @SOLUONG", outParam);
            contractListview21424032.ItemsSource = db.Database.SqlQuery<Contract>("EXEC @ReturnCode = USP_21424032_READ_DATA_CONTRACT", returnCode).ToList();
            tbSumFee.Text = returnCode.Value.ToString();
        }

        private void buttonDeleteContract21424032_Click(object sender, RoutedEventArgs e)
        {
            var contractSelect = contractListview21424032.SelectedItem as Contract;
            if (contractSelect == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng");
            }
            else
            {
                db.Database.ExecuteSqlCommand("EXEC USP_WRITE_DATA_CONTRACT @CONTRACT_ID", new SqlParameter("@CONTRACT_ID", contractSelect.ID));
                MessageBox.Show("Xóa thành công");
                contractListview21424032.ItemsSource = db.Contracts.ToList();
                tbSumFee.Text = db.Contracts.ToList().Count().ToString();
            }
        }

        private void productListview21424032_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var productSelected = productListview32.SelectedItem as BookingAndDelivery.Model.Product;
            var selected = (from pb in db.ProductBranches
                            join b in db.Branches on pb.BranchID equals b.ID
                            where productSelected.ID == pb.ProductID
                            select new
                            {
                                b.ID,
                                pb.Quantity,
                                b.Branchname
                            }).ToList();

            nameProduct32.Text = productSelected.Name;
            priceProduct32.Text = productSelected.Price.ToString();
            nameBranchProduct32.Text = selected.FirstOrDefault().Branchname;
            quantityProduct32.Text = "1";
            //var test = "a";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            productListview32.ItemsSource = db.Products.ToList();
        }
    }
}
