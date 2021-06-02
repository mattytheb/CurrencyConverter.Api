using CurrencyConverter.Api.Models;
using CurrencyConverter.Api.Services;
using FluentAssertions;
using Xunit;

namespace CurrencyConverter.Api.UnitTests
{
    public class ConverterServiceUnitTests
    {
        [Theory]
        [ConverterServiceAutoData]
        public void GetCurrencyData_RepositoryReturnFalse_ShouldReturnFalse(ConverterService sut, ConversionViewModel model)
        {
            var result = sut.GetCurrencyData(model);

            result.Should().Be(false);
        }
    }
}
