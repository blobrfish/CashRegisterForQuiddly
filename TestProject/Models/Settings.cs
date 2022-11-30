using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Settings
    {
        public string Currency { get; }
        public string WeightMetric { get; set; }
        public string CountMetric { get; }

        public int MinimumPurchaseCount = 1;

        public Settings(string currency, string weightMetric, string countMetric)
        {
            this.Currency = currency;
            this.WeightMetric = weightMetric;
            this.CountMetric = countMetric;
        }
    }
}
