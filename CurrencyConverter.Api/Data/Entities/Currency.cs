using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Api.Data.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CurrencyCode { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Symbol { get; set; }
    }
}
