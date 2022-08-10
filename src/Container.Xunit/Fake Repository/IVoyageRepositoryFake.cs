using PriceCalculator.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.Xunit.Fake_Repository
{
   public interface IVoyageRepositoryFake
    {
        IEnumerable<Voyage> GetVoyages();
        Voyage GetVoyageCode(string voyageCode);
        Voyage UpdatePrice(Voyage voyage);
        decimal GetAveragePrice(string voyageCode, Currency currency);
    }
}
