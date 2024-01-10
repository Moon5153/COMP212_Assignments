using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filepath = @"stockData.csv";
        List<StockData> stockList = new List<StockData>();
        int factorial = 0;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            txtFilePath.Text = filepath;
            List<StockData> data = new List<StockData>();
            Parallel.Invoke(() => data = SortData().ToList<StockData>());
            dataGrid.ItemsSource = data;
        }
        public void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            for (int i = 1; i < lines.Length; i++)
            {
                TextFieldParser parser = new TextFieldParser(new StringReader(lines[i]));
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(",");
                string[] line;

                while (!parser.EndOfData)
                {
                    line = parser.ReadFields();
                    string[] dt = line[1].Split('/');
                    DateTime date = DateTime.Parse(line[1]);
                    double open = ConvertCurrencyToDouble(line[2]);
                    double high = ConvertCurrencyToDouble(line[3]);
                    double low = ConvertCurrencyToDouble(line[4]);
                    double close = ConvertCurrencyToDouble(line[5]);
                    bool result = false;
                    Parallel.Invoke(() => result = IsValid(open, high, low, close));

                    if (result)
                    {
                        StockData stockData = new StockData()
                        {
                            Symbol = line[0],
                            Date = date,
                            Open = line[2],
                            High = line[3],
                            Low = line[4],
                            Close = line[5]
                        };
                        stockList.Add(stockData);
                    }

                }
                parser.Close();
            }
        }
        private bool IsValid(double open, double high, double low, double close)
        {
            if (open >= 0 && high >= 0 && low >= 0 && close >= 0)
                return true;
            else
                return false;
        }
        private double ConvertCurrencyToDouble(string value)
        {
            return Convert.ToDouble(Double.Parse(value, System.Globalization.NumberStyles.Currency));
        }
        IOrderedEnumerable<StockData> SortData()
        {
            var sortedData = stockList.OrderBy(x => x.Date.Month) .ThenBy(x => x.Date.Day).ThenBy(x => x.Date.Year);
            return sortedData;
        }
        private void Factorial(int number)
        {
            int result = 1;
            if (number > 0)
            {
                while (number != 1)
                {
                    result = result * number;
                    number = number - 1;
                }
                factorial = result;
               
            }
            else
            {
                MessageBox.Show("Please Enter a Positive integer");
            }
        }

        private async void btnReload_Click(object sender, RoutedEventArgs e)
        {
            stockList = new List<StockData>();
            await Task.Run(new Action(LoadData));
            List<StockData> result = new List<StockData>();
            Parallel.Invoke(() => result = SortData().ToList<StockData>());
            dataGrid.ItemsSource = result;
            MessageBox.Show("Total number of records found: " + stockList.Count);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            stockList = stockList.FindAll(x => x.Symbol.Equals(txtSearch.Text.ToUpper()));
            List<StockData> result = new List<StockData>();
            Parallel.Invoke(() => result = SortData().ToList<StockData>());
            dataGrid.ItemsSource = SortData();
            MessageBox.Show("Number of Records Found: " + stockList.Count);
        }

        private async void btnFactorial_Click(object sender, RoutedEventArgs e)
        {
            int value = Convert.ToInt32(txtFactorial.Text);
            await Task.Run(() => Factorial(value));
            txtResult.Text = factorial.ToString();
        }
    }
}
