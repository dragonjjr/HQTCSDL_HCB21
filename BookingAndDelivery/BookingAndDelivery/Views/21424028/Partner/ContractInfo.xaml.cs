using BookingAndDelivery.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookingAndDelivery.Views._21424028.Partner
{
    /// <summary>
    /// Interaction logic for ContractInfo.xaml
    /// </summary>
    public partial class ContractInfo : Page
    {
        private long userID;

        private BookingAndTransferFoodsEntities db;
        public ContractInfo()
        {
            InitializeComponent();
            this.userID = long.Parse(Application.Current.Properties["UserID"].ToString());
            db = new BookingAndTransferFoodsEntities();
        }

        private void btnPartnerViewContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tgbtnIsFix.IsChecked == false)
                {
                    using (new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadUncommitted
                    }))
                    {
                        var contractInfo = db.Contracts.Where(ct => ct.PartnerID == userID).Select(x => new { x.ID, x.Representative, x.FromDate, x.ToDate }).Single();
                        tbPartnerViewContractID.Text = contractInfo.ID.ToString();
                        tbPartnerViewContractPre.Text = contractInfo.Representative.ToString();
                        tbPartnerViewContractFromDate.Text = contractInfo.FromDate.ToString();
                        tbPartnerViewContractToDate.Text = contractInfo.ToDate.ToString();
                    }
                }
                else
                {
                    using (new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted
                    }))
                    {
                        var contractInfo = db.Contracts.Where(ct => ct.PartnerID == userID).Select(x => new { x.ID, x.Representative, x.FromDate, x.ToDate }).Single();
                        tbPartnerViewContractID.Text = contractInfo.ID.ToString();
                        tbPartnerViewContractPre.Text = contractInfo.Representative.ToString();
                        tbPartnerViewContractFromDate.Text = contractInfo.FromDate.ToString();
                        tbPartnerViewContractToDate.Text = contractInfo.ToDate.ToString();
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
