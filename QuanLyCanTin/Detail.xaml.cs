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
using System.Windows.Shapes;
using static QuanLyCanTin.MainWindow;

namespace QuanLyCanTin
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Window
    {
        public SanPham productOrder;
        public ProductOder tempProduct;
        public Detail(SanPham productOder, ProductOder tempProduct)
        {
            this.productOrder = productOder;
            this.tempProduct = tempProduct;
            this.tempProduct.Count = 1;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Detail_st.DataContext = productOrder;
            CountOrder.DataContext = tempProduct;
        }

        private void Reduce_Click(object sender, RoutedEventArgs e)
        {
            if (this.tempProduct.Count > 0)
                this.tempProduct.Count--;
        }

        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            this.tempProduct.Count++;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
