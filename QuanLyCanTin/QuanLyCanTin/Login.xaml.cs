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

namespace QuanLyCanTin
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            // Hiện thông báo, nhấn OK thì đóng chương trình
            if (MessageBox.Show("Bạn có chắc là muốn thoát chương trình không?", "Thông báo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                DialogResult = false;
                this.Close();
            }
        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
            //var screen = new Home();
            //this.Hide();
            //if (screen.ShowDialog() == true)
            //{
            //    // do something here if needed

            //}
            //this.Show();
        }
    }
}
