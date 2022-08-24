using BookingAndDelivery.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookingAndDelivery.Views._21424028.Customer
{
    /// <summary>
    /// Interaction logic for OrderProduct.xaml
    /// </summary>
    public partial class OrderProduct : Page
    {
        public ObservableCollection<User> partnerList { get; private set; }


        private BookingAndTransferFoodsEntities db;

        public OrderProduct()
        {
            InitializeComponent();
            initData();
            this.DataContext = this;
        }
        private void initData()
        {
            db = new BookingAndTransferFoodsEntities();
            try
            {
                partnerList = getListPartner();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ObservableCollection<User> getListPartner()
        {
            var listPartner = new ObservableCollection<User>(db.Users.Where(us => us.RoleID == 3).ToList());

            return listPartner;
        }

        public ObservableCollection<Branch> getBranchOfPartner(long ID)
        {
            var listBranchOfPartner = new ObservableCollection<Branch>(db.Branches.Where(b => b.PartnerID == ID).ToList());

            return listBranchOfPartner;
        }

        private void cbbPartnerName_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {

                cbbPartnerBranch.ItemsSource = getBranchOfPartner(int.Parse(cbbPartnerName.SelectedValue.ToString()));
                cbbPartnerBranch.DisplayMemberPath = "Branchname";
                cbbPartnerBranch.SelectedValuePath = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbPartnerBranch_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                lvProductBranch.ItemsSource = null;
                if (cbbPartnerBranch.SelectedValue != null)
                {
                    long Result;
                    bool isSuccess;
                    string cbbPartnerBranchSelected = cbbPartnerBranch.SelectedValue.ToString();
                    isSuccess = long.TryParse(cbbPartnerBranch.SelectedValue.ToString(), out Result);
                    if (isSuccess == true)
                    {
                        var listProductBranch = (from p in db.Products
                                                 join pb in db.ProductBranches
                                                 on p.ID equals pb.ProductID
                                                 where pb.BranchID == Result
                                                 select new
                                                 {
                                                     ID = p.ID,
                                                     Name = p.Name,
                                                     Price = p.Price,
                                                     pb.Quantity
                                                 }).ToList();
                        lvProductBranch.ItemsSource = listProductBranch;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCustomerOrder_Click(object sender, RoutedEventArgs e)
        {
            if (lvProductBranch.SelectedItem != null)
            {
                dynamic productInfo = lvProductBranch.SelectedItem;
                tbID.Text = productInfo.ID.ToString();
                tbName.Text = productInfo.Name.ToString();
                tbQuantityProducts.Text = "0";
            }
            else
            {

            }
        }

        private void btnCustomerOrderSubmit_Click(object sender, RoutedEventArgs e)
        {
            int branchID = int.Parse(cbbPartnerBranch.SelectedValue.ToString());
            int payment = 1;
            decimal amount = 0.5m;
            decimal totalAmount = 0.1m;
            decimal productFee = 0.5m;
            decimal transferFee = 0.5m;
            int customerCityID = 79;
            int customerDistricID = 1;
            string customerAddress = "";
            int status = 1;
            long driverID = 1;
            long customerID = 1;
            long productID = long.Parse(tbID.Text);
            int quantityOrder = int.Parse(tbQuantityProducts.Text);
            decimal price = decimal.Parse("50000");
            int amountProduct = quantityOrder;

            try
            {

                var returnCode = new SqlParameter("@ReturnCode", SqlDbType.Int);
                returnCode.Direction = ParameterDirection.Output;
                if (tgbtnIsFix.IsChecked == false)
                {
                    db.Database.ExecuteSqlCommand("EXEC @returnCode = USP_21424028_Insert_Order @BranchID, @Payment, @Amount, @TotalAmount, @CustomerCityID, @CustomerDistrictID, @ProductFee, @TransferFee," +
                        "@CustomerAddress, @Status, @DriverID, @CustomerID, @ProductID, @QuantityOrder, @Price, @AmountProduct",
                        returnCode,
                        new SqlParameter("@BranchID", branchID),
                        new SqlParameter("@Payment", payment), new SqlParameter("@Amount", amount),
                        new SqlParameter("@totalAmount", totalAmount), new SqlParameter("@CustomerCityID", customerCityID),
                        new SqlParameter("@CustomerDistrictID", customerDistricID), new SqlParameter("@ProductFee", productFee),
                        new SqlParameter("@TransferFee", transferFee), new SqlParameter("@CustomerAddress", customerAddress),
                        new SqlParameter("@Status", status), new SqlParameter("DriverID", driverID), new SqlParameter("@CustomerID", customerID),
                        new SqlParameter("@ProductID", productID), new SqlParameter("@QuantityOrder", quantityOrder),
                        new SqlParameter("@Price", price), new SqlParameter("@amountProduct", amountProduct));
                    if (returnCode.Value.ToString() == "0")
                    {
                        MessageBox.Show("Order success");
                    }
                    else
                    {
                        MessageBox.Show("Order failed");
                    }
                }
                else
                {
                    db.Database.ExecuteSqlCommand("EXEC @returnCode = USP_21424028_Insert_Order_Fix @BranchID, @Payment, @Amount, @TotalAmount, @CustomerCityID, @CustomerDistrictID, @ProductFee, @TransferFee," +
                        "@CustomerAddress, @Status, @DriverID, @CustomerID, @ProductID, @QuantityOrder, @Price, @AmountProduct",
                        returnCode,
                        new SqlParameter("@BranchID", branchID),
                        new SqlParameter("@Payment", payment), new SqlParameter("@Amount", amount),
                        new SqlParameter("@totalAmount", totalAmount), new SqlParameter("@CustomerCityID", customerCityID),
                        new SqlParameter("@CustomerDistrictID", customerDistricID), new SqlParameter("@ProductFee", productFee),
                        new SqlParameter("@TransferFee", transferFee), new SqlParameter("@CustomerAddress", customerAddress),
                        new SqlParameter("@Status", status), new SqlParameter("DriverID", driverID), new SqlParameter("@CustomerID", customerID),
                        new SqlParameter("@ProductID", productID), new SqlParameter("@QuantityOrder", quantityOrder),
                        new SqlParameter("@Price", price), new SqlParameter("@amountProduct", amountProduct));
                    if (returnCode.Value.ToString() == "0")
                    {
                        MessageBox.Show("Order success");
                    }
                    else
                    {
                        MessageBox.Show("Order failed");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

