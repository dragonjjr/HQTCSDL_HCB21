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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookingAndDelivery.Model;
using BookingAndDelivery.Model._21424069;

namespace BookingAndDelivery.Views._21424069._21424069_Product
{
    /// <summary>
    /// Interaction logic for _21424069_ProductInfo.xaml
    /// </summary>
    public partial class _21424069_ProductInfo : Page
    {
        private BookingAndTransferFoodsEntities db;
        _21424069_ProductDAO _21424069_productDAO = new _21424069_ProductDAO();

        public _21424069_ProductInfo()
        {
            InitializeComponent();
            db = new BookingAndTransferFoodsEntities();
        }


        private async void btnShowProductInfo_Fix_Click(object sender, RoutedEventArgs e)
        {
            string ProdcutID = txtSearch.Text;
            if (ProdcutID == "")
            {
                MessageBox.Show("Chưa ID sản phẩm!!!", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            long ID = long.Parse(txtSearch.Text);

            List<ProductVM> product = _21424069_productDAO.SearchProductID(ID);


            if (product.Count > 0)
            {
                await Task.Run(() =>
                {
                    var temp = db.Database.SqlQuery<ProductVM>("EXEC USP_21424069_READ_DATA_PRODUCT_FIX @ProductID", new SqlParameter("@ProductID", ID));


                    this.Dispatcher.Invoke(() => {
                        Loading_Label.Visibility = Visibility.Visible;
                        Loading_Process.Visibility = Visibility.Visible;
                    });

                    var result = temp.ToList();

                    this.Dispatcher.Invoke(() =>
                    {
                        if (result.Count <= 0)
                        {
                            MessageBox.Show("Sản phẩm không tồn tại", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                            Loading_Label.Visibility = Visibility.Hidden;
                            Loading_Process.Visibility = Visibility.Hidden;
                            return;
                        }
                        ListViewProductDetail.ItemsSource = result;
                        Loading_Label.Visibility = Visibility.Hidden;
                        Loading_Process.Visibility = Visibility.Hidden;
                    });

                });
            }

            else
            {
                MessageBox.Show("Sản phẩm không tồn tại", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private async void btnShowProductInfo_Click(object sender, RoutedEventArgs e)
        {
            string ProdcutID = txtSearch.Text;
            if (ProdcutID == "")
            {
                MessageBox.Show("Chưa ID sản phẩm!!!", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            long ID = long.Parse(txtSearch.Text);

            List<ProductVM> product = _21424069_productDAO.SearchProductID(ID);


            if (product.Count > 0)
            {
                await Task.Run(() =>
                {
                    var temp = db.Database.SqlQuery<ProductVM>("EXEC USP_21424069_READ_DATA_PRODUCT @ProductID", new SqlParameter("@ProductID", ID));

                    this.Dispatcher.Invoke(() => {
                        Loading_Label.Visibility = Visibility.Visible;
                        Loading_Process.Visibility = Visibility.Visible;
                    });

                    var result = temp.ToList();

                    this.Dispatcher.Invoke(() =>
                    {
                        if (result.Count <= 0)
                        {
                            MessageBox.Show("Sản phẩm không tồn tại", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                            Loading_Label.Visibility = Visibility.Hidden;
                            Loading_Process.Visibility = Visibility.Hidden;
                            return;
                        }
                        ListViewProductDetail.ItemsSource = result;
                        Loading_Label.Visibility = Visibility.Hidden;
                        Loading_Process.Visibility = Visibility.Hidden;
                    });

                });
            }

            else
            {
                MessageBox.Show("Sản phẩm không tồn tại", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



        }

        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {
            long ID = long.Parse(txtSearch.Text);

            List<ProductVM> product = _21424069_productDAO.SearchProductID(ID);

            ListViewProduct.ItemsSource = product;

        }
    }
}
