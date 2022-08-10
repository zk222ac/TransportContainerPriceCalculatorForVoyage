using PriceCalculator.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.Xunit.Fake_Repository
{
    public class VoyageRepositoryFake : IVoyageRepositoryFake
    {
        // Here I am Creating manually Fake Repository but we have another best framework
        // options like --> Moq 
        private readonly List<Voyage> _voyage;
        private int Id = 0;
        public VoyageRepositoryFake()
        {
            _voyage = new List<Voyage>
            {
                new Voyage(){Id = 1 ,Container = "Container Name 1" ,Currency = Currency.US, Price = 100.45M , TimeStamp = DateTime.UtcNow, VoyageCode = "4DF3d"},
                new Voyage(){Id = 2 ,Container = "Container Name 2" ,Currency = Currency.GBP, Price = 360.45M , TimeStamp = DateTime.UtcNow, VoyageCode = "LLS34"},
                new Voyage(){Id = 3 ,Container = "Container Name 3" ,Currency = Currency.DKK, Price = 450.45M , TimeStamp = DateTime.UtcNow, VoyageCode = "KF345"},
                new Voyage(){Id = 4 ,Container = "Container Name 4" ,Currency = Currency.US, Price = 867.45M , TimeStamp = DateTime.UtcNow, VoyageCode = "SL2ML"},
            };
        }
        public IEnumerable<Voyage> GetVoyages()
        {
            return _voyage;
        }       
        public  decimal GetAveragePrice(string voyageCode, Currency currency)
        {

            var getall = _voyage;

            var code = getall
                .Where(voy => voy.VoyageCode == voyageCode && voy.Currency == currency)
                .TakeLast(10).Average(voy => voy.Price);
            //Using Method Syntax           
            var getAveragePrice =  getall
                                  .Where(voy => voy.VoyageCode == voyageCode && voy.Currency == currency)
                                  .Average(voy => voy.Price);
            return getAveragePrice;
        }

        public Voyage GetVoyageCode(string voyageCode)
        {
            return _voyage.Where(a => a.VoyageCode == voyageCode)
                .FirstOrDefault();
        }
        public Voyage UpdatePrice(Voyage voyage)
        {
            voyage.Id = Id + 1;
            _voyage.Add(voyage);
            return voyage;
        }
    }
}
