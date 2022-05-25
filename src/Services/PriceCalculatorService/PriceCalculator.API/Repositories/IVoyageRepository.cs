using PriceCalculator.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculator.API.Repositories
{
    public interface IVoyageRepository
    {
        Task<IEnumerable<Voyage>> GetVoyages();
        Task<Voyage> GetVoyageCode(string voyageCode);
        Task UpdatePrice(Voyage voyage);
        Task<decimal> GetAveragePrice(string voyageCode, Currency currency);
    }
}
