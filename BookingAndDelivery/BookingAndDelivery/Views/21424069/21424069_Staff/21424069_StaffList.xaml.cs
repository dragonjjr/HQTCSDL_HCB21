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
using BookingAndDelivery.Model;
using BookingAndDelivery.Model._21424069._21424069_Staff;

namespace BookingAndDelivery.Views._21424069._21424069_Staff
{
    /// <summary>
    /// Interaction logic for _21424069_StaffList.xaml
    /// </summary>
    public partial class _21424069_StaffList : Page
    {

        private _21424069_StaffDAO staffDAO;
        private BookingAndTransferFoodsEntities db;
        public _21424069_StaffList()
        {
            InitializeComponent();
            staffDAO = new _21424069_StaffDAO();
            db = new BookingAndTransferFoodsEntities();
        }

        private async void btnListStaff_Click(object sender, RoutedEventArgs e)
        {
            int CountStaff = staffDAO.Count_Staff();

            if (CountStaff > 0)
            {
                await Task.Run(() =>
                {
                    var temp = db.Database.SqlQuery<User_DAO>("EXEC USP_21424069_READ_DATA_USERS");

                    this.Dispatcher.Invoke(() =>
                    {
                        Loading_Label.Visibility = Visibility.Visible;
                        Loading_Process.Visibility = Visibility.Visible;
                    });


                    var result = temp.ToList();

                    for (int i = 0; i < result.Count; i++)
                    {
                        result[i].STT = i + 1;
                    }

                    this.Dispatcher.Invoke(() =>
                    {
                        if (result.Count <= 0)
                        {
                            MessageBox.Show("Không có nhân viên nào", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        ListViewListStaff.ItemsSource = result;
                        Loading_Label.Visibility = Visibility.Hidden;
                        Loading_Process.Visibility = Visibility.Hidden;
                    });

                });
            }
            else
            {
                MessageBox.Show("Không có nhân viên nào", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


        }


        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnListStaff_Fix_Click(object sender, RoutedEventArgs e)
        {
            int CountStaff = staffDAO.Count_Staff();

            if (CountStaff > 0)
            {
                await Task.Run(() =>
                {
                    var temp = db.Database.SqlQuery<User_DAO>("EXEC USP_21424069_READ_DATA_USERS_FIX");

                    this.Dispatcher.Invoke(() =>
                    {
                        Loading_Label.Visibility = Visibility.Visible;
                        Loading_Process.Visibility = Visibility.Visible;
                    });


                    var result = temp.ToList();


                    for (int i = 0; i < result.Count; i++)
                    {
                        result[i].STT = i + 1;
                    }

                    this.Dispatcher.Invoke(() =>
                    {
                        if (result.Count <= 0)
                        {
                            MessageBox.Show("Không có nhân viên nào", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        ListViewListStaff.ItemsSource = result;
                        Loading_Label.Visibility = Visibility.Hidden;
                        Loading_Process.Visibility = Visibility.Hidden;
                    });

                });
            }
            else
            {
                MessageBox.Show("Không có nhân viên nào", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnCountStaff_Click(object sender, RoutedEventArgs e)
        {
            int CountStaff = staffDAO.Count_Staff();

            Label_CountStaff.Visibility = Visibility.Visible;
            Txt_CountStaff.Text = CountStaff.ToString();
            Txt_CountStaff.Visibility = Visibility.Visible;
        }

        private void btnUpdateStaff_Click(object sender, RoutedEventArgs e)
        {
            int CountStaff = staffDAO.Count_Staff();

            Label_CountStaff.Visibility = Visibility.Visible;
            Txt_CountStaff.Text = CountStaff.ToString();
            Txt_CountStaff.Visibility = Visibility.Visible;

            ListViewListStaff.ItemsSource = null;
        }
    }
}
