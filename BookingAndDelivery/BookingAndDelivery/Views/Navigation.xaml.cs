using BookingAndDelivery.Model;
using System;
using System.Collections.Generic;
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
        public Navigation()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            productListview32.ItemsSource = db.Products.ToList();
        }
        private void productListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var productSelected = productListview32.SelectedItem as Product;
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

        private void buttonAddProductDetail_Click(object sender, RoutedEventArgs e)
        {
            if(productListview32.SelectedItem !=null)
            {
                var productSelected = productListview32.SelectedItem as Product;
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
                var temp = db.Database.ExecuteSqlCommand("EXEC @ReturnCode =  USP_DIRTY_UPDATE @ORDER_ID,@PRODUCT_ID,@QUANTITY,@PRICE", returnCode,new SqlParameter("@ORDER_ID", 5), 
                    new SqlParameter("@PRODUCT_ID", productSelected.ID), new SqlParameter("@QUANTITY", Int32.Parse(quantityProduct32.Text)), new SqlParameter("@PRICE", productSelected.Price));
                int a = (int)returnCode.Value;
                if (a == 1)
                {
                    MessageBox.Show("Loi");
                }
            }

        }

        private void buttonSeeOrder_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            Order32 oder32 = new Order32();
            oder32.Show();
            //this.Show();
        }
    }
}
