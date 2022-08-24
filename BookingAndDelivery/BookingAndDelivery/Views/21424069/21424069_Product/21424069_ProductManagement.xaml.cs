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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookingAndDelivery.Model._21424069;

namespace BookingAndDelivery.Views._21424069._21424069_Product
{
    /// <summary>
    /// Interaction logic for _21424069_ProductManagement.xaml
    /// </summary>
    public partial class _21424069_ProductManagement : Page
    {

        _21424069_ProductDAO _21424069_productDAO = new _21424069_ProductDAO();

        public _21424069_ProductManagement()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            lvProduct.ItemsSource = _21424069_productDAO.GetProducts();
        }

        
        private void ReFeshList()
        {
            var lst = _21424069_productDAO.GetProducts();

            lvProduct.ItemsSource = lst;
        }

        private async void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var ts = lvProduct.SelectedItem as ProductVM;
            if (ts != null)
            {
                await Task.Run(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var dia = DialogDeleteProduct;
                        dia.IsOpen = true;
                        txtID.Text = ts.ID.ToString();
                        unfUpdate.Visibility = Visibility.Visible;
                        btnUpdateProduct_21424069.Visibility = Visibility.Visible;
                    });
                });
                
            }
        }

 


        private async void btnUpdateProduct_21424069_Click(object sender, RoutedEventArgs e)
        {
            var id = txtID.Text;
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    Loading_Label.Visibility = Visibility.Visible;
                    Loading_Process.Visibility = Visibility.Visible;
                });

                var m = _21424069_productDAO.DeleteProduct(int.Parse(id));

                if (m)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var dia = DialogDeleteProduct;
                        dia.IsOpen = false;
                        MessageBox.Show("Xóa thành công");
                        ReFeshList();

                        Loading_Label.Visibility = Visibility.Hidden;
                        Loading_Process.Visibility = Visibility.Hidden;
                    });
                    
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var dia = DialogDeleteProduct;
                        dia.IsOpen = false;
                        MessageBox.Show("Xóa thất bại");

                        Loading_Label.Visibility = Visibility.Hidden;
                        Loading_Process.Visibility = Visibility.Hidden;
                    });
                    
                }

            });
            
            
        }
    }
}
