using BookingAndDelivery.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace BookingAndDelivery.Views._21424032
{
    /// <summary>
    /// Interaction logic for Order32.xaml
    /// </summary>
    public partial class Order32 : Window
    {
        private BookingAndTransferFoodsEntities db = new BookingAndTransferFoodsEntities();
        public Order32()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadUncommitted
                    }))

            {
                var data = (from od in db.OrderDetails
                            join pd in db.Products on od.ProductID equals pd.ID
                            where od.OrderID == 5
                            select new
                            {
                                od.ID,
                                pd.Name,
                                od.Price,
                                od.Quantity,
                                od.Amount
                            }).ToList();
                orderListview.ItemsSource = data;
            }
            var outParam = new SqlParameter("@TONGTIEN", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            db.Database.ExecuteSqlCommand("EXEC USP_21424032_DIRTY_READ @ORDER_ID,@TONGTIEN OUT", new SqlParameter("@ORDER_ID", 5), outParam);
            priceorder32.Text = outParam.Value.ToString();

        }
    
    
    }
}
