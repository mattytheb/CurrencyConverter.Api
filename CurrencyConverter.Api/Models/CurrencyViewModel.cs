using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Api.Models
{
    public class CurrencyViewModel
    {
        public string Name { get; set; }

        public string CurrencyCode { get; set; }

        public string Symbol { get; set; }
    }
}
