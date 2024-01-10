using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2
{
    public class Vegetable
    {
        public string Name { get; set; }
        public string Price { get; set; }

        private double priceInDouble;
        public Vegetable(string name,double price)
        {
            Name = name;
            this.priceInDouble = price;
            Price = string.Format("$(0:0.00)", price);
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Vegetable> vegetables = new ObservableCollection<Vegetable>();
        public MainWindow()
        {
            InitializeComponent();
            doMyCustom();
        }
        public void doMyCustom()
        {
            this.dataGrid1.ItemsSource = vegetables;
            vegetables.Add(new Vegetable("Corn", 3.11));
            vegetables.Add(new Vegetable("Corns", 3.11));
            vegetables.Add(new Vegetable("Cojjjrn", 3.11));
            vegetables.Add(new Vegetable("Corgggn", 3.11));
        }
        private void delt(object sender,RoutedEventArgs e)
        {
            Vegetable v = (Vegetable)dataGrid1.SelectedItem;
            vegetables.Remove(v);
        }
    }
}
