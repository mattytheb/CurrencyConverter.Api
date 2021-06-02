using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverter.Api.Data.Entities;

namespace CurrencyConverter.Api.Repository
{
    public interface IAppRepository
    {
        Task<IEnumerable<Currency>> GetAllCurrenciesAsync();

        string GetCurrencyName(string currencyCode);

        bool CheckCurrencyCode(string currencyCode);
    }
}
