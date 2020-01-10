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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyCanTin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // lấy danh sách sản phẩm
        List<SanPham> dsSanPham = new List<SanPham>();
        private void loadSanPham()
        {
            dsSanPham = SanPhamDAO.Instance.GetListFood();
        }

        // lấy danh sách combo
        List<ComBo> dsComBo = new List<ComBo>();
        private void loadComBo()
        {
            dsComBo = ComBoDAO.Instance.GetListComBo();
        }
        List<ComBoInfo> comBoInfos = new List<ComBoInfo>();

        private void loadComBoInfo()
        {
            comBoInfos = ComBoInfoDAO.Instance.GetListComBoInfo();
        }
        int current = 0;
        public class ProductOder : INotifyPropertyChanged
        {
            private String _CodeProduct;
            private String _NameProduct;
            private int _Cost;
            private int _Count;
            private int _Total;
            public String CodeProduct
            {
                get
                {
                    return _CodeProduct;
                }
                set
                {
                    _CodeProduct = value;
                    Notify("CodeProduct");
                }
            }
            public String NameProduct
            {
                get
                {
                    return _NameProduct;
                }
                set
                {
                    _NameProduct = value;
                    Notify("NameProduct");
                }
            }


            public int Cost
            {
                get
                {
                    return _Cost;
                }
                set
                {
                    _Cost = value;
                    Notify("Cost");
                }
            }
            public int Count
            {
                get
                {
                    return _Count;
                }
                set
                {
                    _Count = value;
                    Notify("Count");
                }
            }

            public int Total
            {
                get
                {
                    return _Total;
                }
                set
                {
                    _Total = value;
                    Notify("Total");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            public void Notify(string v)
            {
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(v));
            }
        }

        public Border CreateItemProduct(String Uri, String Name, int stt, int type)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(Uri, UriKind.Relative));
            img.Width = 100;
            img.Height = 100;
            StackPanel stackPanel = new StackPanel();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Name;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.Children.Add(img);
            stackPanel.Children.Add(textBlock);
            stackPanel.Background = new SolidColorBrush(Colors.Transparent);

            Button button = new Button();
            button.Margin = new Thickness(10, 5, 10, 5);
            button.BorderThickness = new Thickness(0);
            button.Background = new SolidColorBrush(Colors.Transparent);
            button.BorderBrush = new SolidColorBrush(Colors.Transparent);
            button.Content = stackPanel;
            button.Tag = new Tuple<int>(stt);
            if (type == 0)
                button.Click += Button_Click;
            else
                button.Click += ButtonCombo_Click;

            Border border = new Border();
            border.Margin = new Thickness(0, 8, 0, 8);
            border.Width = 190;
            border.Height = 190;
            border.Child = button;
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(2);
            border.Background = new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFE6E6E6"));
            border.CornerRadius = new CornerRadius(20);
            return border;
        }



        //List<SanPham> listProduct = new List<SanPham>();
        BindingList<ProductOder> listProductOrder = new BindingList<ProductOder>();
        List<Border> listProductBorder = new List<Border>();

        int TotalMoney = 0;
        String MaNV = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var screen = new Login();

            if (screen.ShowDialog() == false)
            {
                this.Close();
                return;
            }

            MaNV = screen.MaNV;
            loadSanPham();
            loadComBo();
            loadComBoInfo();

            //MessageBox.Show(dsSanPham[0].TenSanPham + "\n" + dsSanPham[1].ImgUrl);

            //Test đọc hết dữ liệu SẢN PHẨM
            //for (int i = 0; i < dsSanPham.Count; i++)
            //{
            //    MessageBox.Show("Mã sản phẩm: " + dsSanPham[i].MaSanPham + " - Tên sản phẩm: " + dsSanPham[i].TenSanPham);
            //}

            //Test đọc hết dữ liệu COMBO
            //for (int i = 0; i < dsComBo.Count; i++)
            //{
            //    MessageBox.Show("Mã combo: " + dsComBo[i].MaComBo + " - Tên combo: " + dsComBo[i].TenComBo + " - Giá combo: " + dsComBo[i].GiaComBo);
            //}


            for (int i = 0; i < dsSanPham.Count(); i++)
            {
                if (dsSanPham[i].IsDelete == false)
                {
                    Border border = CreateItemProduct(dsSanPham[i].ImgUrl, dsSanPham[i].TenSanPham, i, 0);
                    listProductBorder.Add(border);
                }
                current = i;
            }
            current += 1;

            for (int i = current; i < dsComBo.Count + current; i++)
            {
                String URL = null;

                for (int j = 0; j < comBoInfos.Count; j++)
                    if (comBoInfos[j].MaComBo.CompareTo(dsComBo[i - current].MaComBo) == 0)
                    {
                        for (int k = 0; k < dsSanPham.Count; k++)
                        {
                            if (dsSanPham[k].MaSanPham.CompareTo(comBoInfos[j].MaSanPham) == 0)
                            {
                                URL = dsSanPham[k].ImgUrl;

                                break;
                            }

                        }
                        break;
                    }

                dsComBo[i - current].Image = URL;
                Border border = CreateItemProduct(URL, dsComBo[i - current].TenComBo, i, 1);
                listProductBorder.Add(border);
            }


            int temp = 0;
            for (int i = 0; i < dsSanPham.Count(); i++)
            {
                if (dsSanPham[i].LoaiSanPham.CompareTo("002") == 0)
                {
                    temp++;
                    Uni.Children.Add(listProductBorder[i]);
                }
            }

            ListOrder.ItemsSource = listProductOrder;
        }
        private void ButtonCombo_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var index = (button.Tag as Tuple<int>).Item1;


            var screen = new DetailCombo(dsComBo[index - current]);

            if (screen.ShowDialog() == true)
            {
                List<ProductOder> newList = new List<ProductOder>();

                for (int i = 0; i < comBoInfos.Count; i++)
                {
                    if (comBoInfos[i].MaComBo.CompareTo(dsComBo[index - current].MaComBo) == 0)
                    {
                        for (int j = 0; j < dsSanPham.Count; j++)
                        {
                            if (comBoInfos[i].MaSanPham.CompareTo(dsSanPham[j].MaSanPham) == 0)
                            {
                                ProductOder productOrder = new ProductOder() { CodeProduct = dsSanPham[j].MaSanPham, Cost = dsSanPham[j].Gia, NameProduct = dsSanPham[j].TenSanPham, Count = 1, Total = dsSanPham[j].Gia };
                                newList.Add(productOrder);
                                break;
                            }

                        }
                    }
                }

                for (int i = 0; i < newList.Count; i++)
                {
                    int indexOrder = 0;
                    bool exist = false;
                    for (int j = 0; j < listProductOrder.Count; j++)
                    {
                        if (newList[i].CodeProduct.CompareTo(listProductOrder[j].CodeProduct) == 0)
                        {
                            exist = true;
                            indexOrder = j;
                            break;
                        }
                    }

                    if (exist == false)
                    {
                        listProductOrder.Add(newList[i]);
                        TotalMoney += newList[i].Cost;
                        TongTien.Text = TotalMoney.ToString();
                    }
                    else
                    {
                        listProductOrder[indexOrder].Count++;
                        TotalMoney += listProductOrder[indexOrder].Cost;
                        listProductOrder[indexOrder].Total += listProductOrder[indexOrder].Cost;
                        TongTien.Text = TotalMoney.ToString();
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var index = (button.Tag as Tuple<int>).Item1;

            bool exist = false;

            ProductOder tempProduct = new ProductOder();
            //var productOrder = new ProductOder();
            var screen = new Detail(dsSanPham[index], tempProduct);

            if (screen.ShowDialog() == true)
            {
                int indexOrder = 0;

                for (int i = 0; i < listProductOrder.Count; i++)
                {
                    if (dsSanPham[index].MaSanPham.CompareTo(listProductOrder[i].CodeProduct) == 0)
                    {
                        exist = true;
                        indexOrder = i;
                        break;
                    }
                }

                if (exist == false)
                {
                    ProductOder productOrder = new ProductOder() { CodeProduct = dsSanPham[index].MaSanPham, Cost = dsSanPham[index].Gia, NameProduct = dsSanPham[index].TenSanPham, Count = tempProduct.Count, Total = tempProduct.Count * dsSanPham[index].Gia };
                    listProductOrder.Add(productOrder);
                    TotalMoney += tempProduct.Count * dsSanPham[index].Gia;
                    TongTien.Text = TotalMoney.ToString();
                }
                else
                {
                    listProductOrder[indexOrder].Count += tempProduct.Count;
                    TotalMoney += tempProduct.Count * listProductOrder[indexOrder].Cost;
                    listProductOrder[indexOrder].Total += tempProduct.Count * listProductOrder[indexOrder].Cost;
                    TongTien.Text = TotalMoney.ToString();
                }
            }



        }




        private void Drinkbtn_Click(object sender, RoutedEventArgs e)
        {
            Uni.Children.Clear();

            for (int i = 0; i < dsSanPham.Count(); i++)
            {
                if (dsSanPham[i].LoaiSanPham.CompareTo("002") == 0)
                {
                    Uni.Children.Add(listProductBorder[i]); ;
                }
            }
        }

        private void Foodbtn_Click(object sender, RoutedEventArgs e)
        {
            Uni.Children.Clear();

            for (int i = 0; i < dsSanPham.Count(); i++)
            {
                if (dsSanPham[i].LoaiSanPham.CompareTo("001") == 0)
                {
                    Uni.Children.Add(listProductBorder[i]);
                }
            }

        }

        private void FileListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClearOrder_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = ListOrder.Items.IndexOf(item);

            TotalMoney -= listProductOrder[index].Total;
            TongTien.Text = TotalMoney.ToString();

            listProductOrder.RemoveAt(index);

        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            String textSearch = Searchtb.Text;

            if (textSearch == "")
                return;
            Uni.Children.Clear();

            for (int i = 0; i < dsSanPham.Count; i++)
            {
                if (dsSanPham[i].TenSanPham.ToLower().Contains(textSearch.ToLower()))
                    Uni.Children.Add(listProductBorder[i]);
            }
        }

        private void Searchtb_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void Paybtn_Click(object sender, RoutedEventArgs e)
        {
            var screen = new Pay(listProductOrder, MaNV);

            if (listProductOrder.Count == 0)
            {
                MessageBox.Show("Hãy chọn món!!");
                return;

            }

            if (screen.ShowDialog() == true)
            {
                listProductOrder.Clear();
                TotalMoney = 0;
                TongTien.Text = "";
                MessageBox.Show("Thanh toán thành công");
            }
        }

        private void Combobtn_Click(object sender, RoutedEventArgs e)
        {
            Uni.Children.Clear();

            for (int i = current; i < listProductBorder.Count; i++)
            {
                Uni.Children.Add(listProductBorder[i]);
            }
        }

        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            var screen = new AboutUs();
            screen.ShowDialog();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            var screen = new History();

            if (screen.ShowDialog() == true)
            {
            }
        }

        private void Favoritebtn_Click(object sender, RoutedEventArgs e)
        {
            Uni.Children.Clear();

            for (int i = 0; i < dsSanPham.Count(); i++)
            {
                if (dsSanPham[i].YeuThich == true)
                {
                    Uni.Children.Add(listProductBorder[i]);
                }
            }
        }
    }
}
