using BookingAndDelivery.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookingAndDelivery.Views._21424028.Partner
{
    /// <summary>
    /// Interaction logic for UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Page
    {
        private long userID;

        private BookingAndTransferFoodsEntities db;

        public UpdateProduct()
        {
            InitializeComponent();
            this.userID = long.Parse(Application.Current.Properties["UserID"].ToString());
            db = new BookingAndTransferFoodsEntities();
            initData();
        }
        public void initData()
        {
            db = new BookingAndTransferFoodsEntities();
            try
            {
                cbbPartnerBranch.ItemsSource = getBranchOfPartner(this.userID);
                cbbPartnerBranch.DisplayMemberPath = "Branchname";
                cbbPartnerBranch.SelectedValuePath = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ObservableCollection<Branch> getBranchOfPartner(long ID)
        {
            var listBranchOfPartner = new ObservableCollection<Branch>(db.Branches.Where(b => b.PartnerID == ID).ToList());

            return listBranchOfPartner;
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
        private void btnPartnerUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (lvProductBranch.SelectedItem != null)
            {
                dynamic productInfo = lvProductBranch.SelectedItem;
                tbPartnerUpdateID.Text = productInfo.ID.ToString();
                tbPartnerUpdateName.Text = productInfo.Name.ToString();
                tbPartnerUpdateQuantityProducts.Text = productInfo.Quantity.ToString();
                tbPartnerUpdatePrice.Text = productInfo.Price.ToString();
            }
            else
            {
                refeshDialog();
            }
        }

        private void refeshDialog()
        {
            tbPartnerUpdateID.Text = "";
            tbPartnerUpdateName.Text = "";
            tbPartnerUpdateQuantityProducts.Text = "";
            tbPartnerUpdatePrice.Text = "";
        }

        private void btnPartnerUpdateQuantity_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                db.Database.ExecuteSqlCommand("EXEC USP_21424028_Update_Quantity_Product @BranchID, @ProductID, @Quantity, @isActive",
                    new SqlParameter("@BranchID", long.Parse(cbbPartnerBranch.SelectedValue.ToString())),
                    new SqlParameter("@ProductID", long.Parse(tbPartnerUpdateID.Text)),
                    new SqlParameter("@Quantity", int.Parse(tbPartnerUpdateQuantityProducts.Text)),
                    new SqlParameter("@isActive", 1));
                MessageBox.Show("Update success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
