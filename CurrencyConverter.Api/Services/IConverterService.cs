using CurrencyConverter.Api.Models;

namespace CurrencyConverter.Api.Services
{
    public interface IConverterService
    {
        bool GetCurrencyData(ConversionViewModel conversion);
    }
}
