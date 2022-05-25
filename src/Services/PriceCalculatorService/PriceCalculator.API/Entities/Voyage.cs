using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriceCalculator.API.Entities
{
    public class Voyage
    {
        [Key]
        public int Id { get; set; }
        public string VoyageCode { get; set; }
        public string Container { get; set; }
        public string Price { get; set; }  
        public Currency Currency { get; set; }        
        public DateTimeOffset TimeStamp { get; set; }
    }

    public enum Currency
    {
        US,
        GBP,
        DKK
    }
}
