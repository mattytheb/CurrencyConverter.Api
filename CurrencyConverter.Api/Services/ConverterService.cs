using System;
using CurrencyConverter.Api.Models;
using CurrencyConverter.Api.Repository;
using FixerSharp;

namespace CurrencyConverter.Api.Services
{
    public class ConverterService : IConverterService
    {
        private readonly IAppRepository _appRepository;
        public ConverterService(IAppRepository appRepository)
        {
            Fixer.SetApiKey("c7c75f53d4aed79c069a4add8b60f613");
            _appRepository = appRepository;
        }

        public bool GetCurrencyData(ConversionViewModel conversion)
        {
            var correctCurrencyCodes = CheckCurrencyCodes(conversion);

            if (!correctCurrencyCodes)
            {
                return false;
            }

            ConvertCurrency(conversion);

            AddCurrencyNamesToConversion(conversion);

            return true;
        }

        private bool CheckCurrencyCodes(ConversionViewModel conversion)
        {
            return _appRepository.CheckCurrencyCode(conversion.CurrencyCodeFrom) && _appRepository.CheckCurrencyCode(conversion.CurrencyCodeTo);
        }

        private void ConvertCurrency(ConversionViewModel conversion)
        {
            var exchangeRate = Fixer.Rate(conversion.CurrencyCodeFrom, conversion.CurrencyCodeTo, DateTime.Today.Date);

            var convertedAmount = (decimal)(conversion.AmountToConvert * (decimal) exchangeRate.Rate);

            conversion.ConvertedAmount = decimal.Round(convertedAmount, 2);
        }
        
        private void AddCurrencyNamesToConversion(ConversionViewModel conversion)
        {
            conversion.CurrencyNameFrom = _appRepository.GetCurrencyName(conversion.CurrencyCodeFrom);
            conversion.CurrencyNameTo = _appRepository.GetCurrencyName(conversion.CurrencyCodeTo);
        }

    }
}
