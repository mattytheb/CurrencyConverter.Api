using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverter.Api.Data;
using CurrencyConverter.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Api.Repository
{
    public class AppRepository : IAppRepository
    {
        private readonly CurrencyContext _context;

        public AppRepository(CurrencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Currency>> GetAllCurrenciesAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public string GetCurrencyName(string currencyCode)
        {
            return _context.Currencies.FirstOrDefault(x => x.CurrencyCode == currencyCode)?.Name;
        }

        public bool CheckCurrencyCode(string currencyCode)
        {
            return _context.Currencies.Any(x => x.CurrencyCode == currencyCode);
        }
    }
}
