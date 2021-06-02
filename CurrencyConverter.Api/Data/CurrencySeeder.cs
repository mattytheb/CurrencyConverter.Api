using System.Collections.Generic;
using System.IO;
using System.Linq;
using CurrencyConverter.Api.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace CurrencyConverter.Api.Data
{
    public class CurrencySeeder 
    {
        private readonly CurrencyContext _context;
        private readonly IWebHostEnvironment _env;

        public CurrencySeeder(CurrencyContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Currencies.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data/currencies.json");
                var seedJson = File.ReadAllText(filePath);
                var currencies = JsonConvert.DeserializeObject<IEnumerable<Currency>>(seedJson);

                _context.Currencies.AddRange(currencies);

                _context.SaveChanges();

            }
        }

    }
}
