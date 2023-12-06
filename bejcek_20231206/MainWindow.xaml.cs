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

namespace bejcek_20231206
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double meziVypocet;
        double mezimeziVypocet;
        double vysledek;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(X.Text);
            int y = int.Parse(Y.Text);
            generate(x, y);
        }
        public void generate(int x, int y)
        {
            vysledekGrid.Children.Clear();
            for(int i = 0; i < x; i++)
            {
                vysledekGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(25) });
                for(int j = 0; j < y; j++)
                {
                    if(i == j)
                    {
                        Rectangle mainrec = new Rectangle();
                        mainrec.Fill = Brushes.Green;
                        mainrec.Stroke = Brushes.Black;
                        vysledekGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
                        Grid.SetRow(mainrec, i);
                        Grid.SetColumn(mainrec, j);
                        vysledekGrid.Children.Add(mainrec);
                    }
                    else
                    {
                        Rectangle mainrec = new Rectangle();
                        mainrec.Fill = Brushes.White;
                        mainrec.Stroke = Brushes.Black;
                        vysledekGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
                        Grid.SetRow(mainrec, i);
                        Grid.SetColumn(mainrec, j);
                        vysledekGrid.Children.Add(mainrec);
                    }
                }
            }
        }
        public void count(double r)
        {
            meziVypocet = (Math.Pow(r, 2.0)) + (Math.Pow(r, 2.0));
            mezimeziVypocet = Math.Sqrt(meziVypocet);
            vysledek = ((4.0 / 3.0 * Math.PI) * Math.Pow(r, 3)) - ((Math.Pow(mezimeziVypocet, 3.0)));
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            count(double.Parse(txtBox.Text));
            txtBlock.Text = vysledek.ToString();
        }
    }
}
