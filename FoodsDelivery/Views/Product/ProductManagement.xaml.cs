using FoodsDelivery.Model;
using FoodsDelivery.DB;
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

namespace FoodsDelivery.Views.Product
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Page
    {
        private ProductModel ProductDAO = new ProductModel();
        public ProductManagement()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            lvProduct.ItemsSource = ProductDAO.GetProducts();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ReFeshList();
            //DialogNhapDiem.IsOpen = true;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var ts = lvProduct.SelectedItem as ProductVM;
            if(ts != null)
            {
                var dia = DialogNhapDiem;
                dia.IsOpen = true;
                txtID.Text = ts.ID.ToString();
                txtName.Text = ts.Name;
                txtPrice.Text = ts.Price.ToString();
                unfUpdate.Visibility = Visibility.Visible;
                unfAdd.Visibility = Visibility.Collapsed;
            }    
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var id = txtID.Text;
            var price = txtPrice.Text;
            var m = ProductDAO.UpdatePrice(int.Parse(id), decimal.Parse(price));
            if(m)
            {
                var dia = DialogNhapDiem;
                dia.IsOpen = false;
                MessageBox.Show("Cập nhật thành công");
                lvProduct.ItemsSource = null;
                ReFeshList();
            }
            
        }

        private void ReFeshList()
        {
            var lst = ProductDAO.GetProducts();

            lvProduct.ItemsSource = lst;
        }
    }
}
