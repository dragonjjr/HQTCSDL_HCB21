using BookingAndDelivery.Model;
using BookingAndDelivery.Model._21424069._21424069_Staff;
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

namespace BookingAndDelivery.Views._21424069._21424069_Staff
{
    /// <summary>
    /// Interaction logic for _21424069_StaffManagement.xaml
    /// </summary>
    public partial class _21424069_StaffManagement : Page
    {
        private _21424069_StaffDAO staffDAO = new _21424069_StaffDAO();
        private BookingAndTransferFoodsEntities db;
        public _21424069_StaffManagement()
        {
            InitializeComponent();
            db = new BookingAndTransferFoodsEntities();
            Init();
        }

        private void Init()
        {
            lvListStaff.ItemsSource = staffDAO.GetStaffs();
        }

        private async void btnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            var ts = lvListStaff.SelectedItem as User_DAO;
            if (ts != null)
            {
                await Task.Run(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var dia = DialogDeleteProduct;
                        dia.IsOpen = true;
                        txtFullName.Text = ts.FullName;
                        txtPhone.Text = ts.Phone;
                        txtAddress.Text = ts.Address;
                        txtEmail.Text = ts.Email;
                        txtNameOfBank.Text = ts.NameOfBank;
                        txtBankAccount.Text = ts.BankAccount;
                        txtNumOfOrder.Text = ts.NumOfOrder.ToString();
                        unfUpdate.Visibility = Visibility.Visible;
                        btnUpdateProduct_21424069.Visibility = Visibility.Visible;
                    });
                   
                });
                
            }
            else
            {
                var dia = DialogDeleteProduct;
                dia.IsOpen = true;
                unfUpdate.Visibility = Visibility.Visible;
                btnUpdateProduct_21424069.Visibility = Visibility.Visible;
            }
        }

        public void UpdateStaffListView()
        {
            lvListStaff.ItemsSource = staffDAO.GetStaffs();
        }

        private async void btnUpdateProduct_21424069_Click(object sender, RoutedEventArgs e)
        {
            string FullName = txtFullName.Text;
            string Phone = txtPhone.Text;
            string Address = txtAddress.Text;
            string Email = txtEmail.Text;
            string NameOfBank = txtNameOfBank.Text;
            string Bank_Account = txtBankAccount.Text;
            int NumOfOrder = int.Parse(txtNumOfOrder.Text);
            Nullable<long> RoleID = 2;


            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    Loading_Label.Visibility = Visibility.Visible;
                    Loading_Process.Visibility = Visibility.Visible;
                });

                bool result = staffDAO.AddStaff(FullName, Phone, Address, Email, NameOfBank, Bank_Account, NumOfOrder, RoleID);


                if (result == true)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    db.SaveChanges();

                    this.Dispatcher.Invoke(() =>
                    {
                        UpdateStaffListView();
                        Loading_Label.Visibility = Visibility.Hidden;
                        Loading_Process.Visibility = Visibility.Hidden;
                    });


                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            });
        }
    }
}
