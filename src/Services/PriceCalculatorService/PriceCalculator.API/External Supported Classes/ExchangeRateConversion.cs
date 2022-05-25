using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.API.External_Supported_Classes
{
    public class ExchangeRateConversion
    {
        public static string ExchangeRateConversionFunc(string input , string from , string to) 
        {
            Dictionary<string, double> rates = new Dictionary<string, double>();
            rates.Add("USD", 1);            
            rates.Add("DKK", 0.14);
            rates.Add("GBP", 0.80);
            double amount;
            Double.TryParse(input, out amount);
            return Convert.ToString(Math.Round(((amount / rates[from]) * rates[to]), 2));
        }
    }
}
