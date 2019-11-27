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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var screen = new Login();
            var result = screen.ShowDialog();

            if (result == true)
            {

            }
            else
                this.Close();

            for (int i = 0; i < 100; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("/Images/comchien.jpeg", UriKind.Relative));
                img.Width = 100;
                img.Height = 100;
                StackPanel stackPanel = new StackPanel();
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "COM CHIEN";
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

                Border border = new Border();
                border.Child = button;
                border.BorderThickness = new Thickness(5, 10, 15, 20);
                border.Background = new SolidColorBrush(Colors.LightGray);
                border.CornerRadius = new CornerRadius(20);
                Uni.Children.Add(border);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
