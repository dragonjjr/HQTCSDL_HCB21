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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookingAndDelivery.Views._21424028.Staff
{
    /// <summary>
    /// Interaction logic for ContractManagement.xaml
    /// </summary>
    public partial class ContractManagement : Page
    {
        private BookingAndTransferFoodsEntities db;
        public ContractManagement()
        {
            InitializeComponent();
            initData();
        }
        public void initData()
        {
            db = new BookingAndTransferFoodsEntities();
        }

        private void btnAdminViewContract_Click(object sender, RoutedEventArgs e)
        {
            var listContract = (from ct in db.Contracts
                                select new
                                {
                                    ID = ct.ID,
                                    Representative = ct.Representative,
                                    FromDate = ct.FromDate,
                                    ToDate = ct.ToDate
                                }).ToList();
            lvAdminContract.ItemsSource = listContract;
        }

        private void btnAdminUpdateContract_Click(object sender, RoutedEventArgs e)
        {
            if (lvAdminContract.SelectedItem != null)
            {
                dynamic contractInfo = lvAdminContract.SelectedItem;
                tbAminUpdateID.Text = contractInfo.ID.ToString();
                tbAdminUpdateName.Text = contractInfo.Representative.ToString();
                dpAdminUpdateFromDate.SelectedDate = DateTime.Parse(contractInfo.FromDate.ToString());
                dpAdminUpdateToDate.SelectedDate = DateTime.Parse(contractInfo.ToDate.ToString());
            }
            else
            {

            }
        }

        private void btnAdminUpdateContractSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var returnCode = new SqlParameter("@ReturnCode", SqlDbType.Int);
                returnCode.Direction = ParameterDirection.Output;

                db.Database.ExecuteSqlCommand("EXEC @ReturnCode = USP_21424028_Contract_Extension @ID, @FromDate, @ToDate",
                    returnCode,
                    new SqlParameter("@ID", tbAminUpdateID.Text),
                    new SqlParameter("@FromDate", dpAdminUpdateFromDate.SelectedDate),
                    new SqlParameter("@ToDate", dpAdminUpdateToDate.SelectedDate));
                if (returnCode.Value.ToString() == "0")
                {
                    MessageBox.Show("Update success");
                }
                else
                {
                    MessageBox.Show("Update failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

