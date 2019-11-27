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

        public class Product
        {
            public String CodeProduct { get; set; }
            public String NameProduct { get; set; }
            public String TypeProduct { get; set; }
            public int Cost { get; set; }
            public bool Favorite { get; set; }
            public bool isDelete { get; set; }
            public String image { get; set; }
        }

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

        public Border CreateItemProduct(String Uri, String Name, int stt)
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
            button.Click += Button_Click;

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

        List<Product> listProduct = new List<Product>();
        BindingList<ProductOder> listProductOrder = new BindingList<ProductOder>();
        List<Border> listProductBorder = new List<Border>();
        int TotalMoney = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var screen = new Login();
            var result = screen.ShowDialog();

            if (result == true)
            {

            }
            else
                this.Close();

            Product newProduct1 = new Product() { CodeProduct = "123", Cost = 120000, Favorite = true, isDelete = false, NameProduct = "Cơm chiên", TypeProduct = "Food", image = "/Images/comchien.jpeg" };
            Product newProduct2 = new Product() { CodeProduct = "456", Cost = 240000, Favorite = true, isDelete = false, NameProduct = "Cơm Nấm", TypeProduct = "Food", image = "/Images/comchien.jpeg" };
            Product newProduct3 = new Product() { CodeProduct = "789", Cost = 100000, Favorite = true, isDelete = false, NameProduct = "Sting", TypeProduct = "Drink", image = "/Images/sting.jpg" };
            Product newProduct4 = new Product() { CodeProduct = "101", Cost = 80000, Favorite = true, isDelete = false, NameProduct = "Coca", TypeProduct = "Drink", image = "/Images/sting.jpg" };

            listProduct.Add(newProduct1);
            listProduct.Add(newProduct2);
            listProduct.Add(newProduct3);
            listProduct.Add(newProduct4);

            for (int i = 0; i < listProduct.Count(); i++)
            {
                Border border = CreateItemProduct(listProduct[i].image, listProduct[i].NameProduct, i);
                listProductBorder.Add(border);
            }

            for (int i = 0; i < listProduct.Count(); i++)
            {
                if (listProduct[i].TypeProduct.CompareTo("Food") == 0)
                {
                    Uni.Children.Add(listProductBorder[i]);
                }
            }

            ListOrder.ItemsSource = listProductOrder;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var index = (button.Tag as Tuple<int>).Item1;

            bool exist = false;
            int indexOrder = 0;

            for (int i = 0; i < listProductOrder.Count; i++)
            {
                if (listProduct[index].CodeProduct.CompareTo(listProductOrder[i].CodeProduct) == 0)
                {
                    exist = true;
                    indexOrder = i;
                    break;
                }
            }

            if (exist == false)
            {
                ProductOder productOrder = new ProductOder() { CodeProduct = listProduct[index].CodeProduct, Cost = listProduct[index].Cost, NameProduct = listProduct[index].NameProduct, Count = 1, Total = listProduct[index].Cost };
                listProductOrder.Add(productOrder);
                TotalMoney += listProduct[index].Cost;
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




        private void Drinkbtn_Click(object sender, RoutedEventArgs e)
        {
            Uni.Children.Clear();

            for (int i = 0; i < listProduct.Count(); i++)
            {
                if (listProduct[i].TypeProduct.CompareTo("Drink") == 0)
                {
                    Uni.Children.Add(listProductBorder[i]); ;
                }
            }
        }

        private void Foodbtn_Click(object sender, RoutedEventArgs e)
        {
            Uni.Children.Clear();

            for (int i = 0; i < listProduct.Count(); i++)
            {
                if (listProduct[i].TypeProduct.CompareTo("Food") == 0)
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

            Uni.Children.Clear();

            for(int i=0; i< listProduct.Count; i++)
            {
                if(listProduct[i].NameProduct.Contains(textSearch) )
                    Uni.Children.Add(listProductBorder[i]); 
            }
        }

        private void Searchtb_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            String textSearch = Searchtb.Text;

            Uni.Children.Clear();

            for (int i = 0; i < listProduct.Count; i++)
            {
                if (listProduct[i].NameProduct.Contains(textSearch))
                    Uni.Children.Add(listProductBorder[i]);
            }
        }
    }
}
