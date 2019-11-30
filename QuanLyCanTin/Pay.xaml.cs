using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static QuanLyCanTin.MainWindow;

namespace QuanLyCanTin
{
    /// <summary>
    /// Interaction logic for Pay.xaml
    /// </summary>
    public partial class Pay : Window
    {
        public BindingList<ProductOder> listOrder;
        public String MaNV;

        public Pay(BindingList<ProductOder> listOrder, String MaNV)
        {
            this.listOrder = listOrder;
            this.MaNV = MaNV;
            InitializeComponent();
        }

        private void ClearOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListPay.ItemsSource = listOrder;
        }

        private void Paybtn_Click(object sender, RoutedEventArgs e)
        {
            // lưu lịch sử thanh toán ở đây: lưu vào HoaDon và ChiTietHoaDon
            string nextBillID = HoaDonDAO.Instance.getNextID();
            int nextSTT = HoaDonDAO.Instance.getNextSTT();

            // Tìm cách lấy mã nhân viên đang đăng nhập
            string accountID = this.MaNV;
            int TotalMoney = 0;
            for (int i = 0; i < listOrder.Count; i++)
                TotalMoney += listOrder[i].Total;

            bool check = HoaDonDAO.Instance.InsertBill(nextBillID, nextSTT, DateTime.Now, TotalMoney, accountID);
            if (check)
            {
                MessageBox.Show("Thêm hóa đơn vào cơ sở dữ liệu thành công!!!");
            }

            List<string> listProductOrderID = new List<string>();
            List<int> listProductOrderCount = new List<int>();

            for (int i = 0; i < listOrder.Count; i++)
            {
                listProductOrderCount.Add(listOrder[i].Count);
                listProductOrderID.Add(listOrder[i].CodeProduct);
            }

            check = HoaDonInfoDAO.Instance.InsertBillInfo(nextBillID, listProductOrderID, listProductOrderCount);
            if (check)
            {
                MessageBox.Show("Thêm chi tiết hóa đơn vào cơ sở dữ liệu thành công!!!");
            }

            DialogResult = true;
            this.Close();
        }
    }
}
