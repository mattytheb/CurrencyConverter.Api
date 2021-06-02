using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CurrencyConverter.Api.Data.Entities;

namespace CurrencyConverter.Api.Models
{
    public class ConversionViewModel
    {
        [Required]
        [MaxLength(3, ErrorMessage="Too Long For Code")]
        [MinLength(3, ErrorMessage = "Too Short for Currency Code")]
        public string CurrencyCodeFrom { get; set; }

        public string CurrencyNameFrom { get; set; }

        [Required]
        [MaxLength(3, ErrorMessage = "Too Long For Code")]
        [MinLength(3, ErrorMessage = "Too Short for Currency Code")]
        public string CurrencyCodeTo { get; set; }

        public string CurrencyNameTo { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal? AmountToConvert { get; set; }

        public decimal ConvertedAmount { get; set; }

        public string ConvertedSymbol { get; set; }

        public IEnumerable<CurrencyViewModel> Currencies { get; set; }
    }
}
