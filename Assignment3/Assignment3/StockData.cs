using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class StockData
    {
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }

        public override string ToString()
        {
            return $"Symbol: {Symbol} Date: {Date}  Open: {Open} High: {High}";
        }
    }
}
