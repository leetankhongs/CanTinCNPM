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

namespace QuanLyCanTin
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public History()
        {
            InitializeComponent();
        }

        BindingList<HoaDon> listBill;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<HoaDon> temp = HoaDonDAO.Instance.GetListBill();
            listBill = new BindingList<HoaDon>();

            for (int i = 0; i < temp.Count; i++)
                listBill.Add(temp[i]);

            ListBill.ItemsSource = listBill;
        }
    }
}
