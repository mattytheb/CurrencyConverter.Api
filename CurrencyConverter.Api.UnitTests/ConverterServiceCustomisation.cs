using AutoFixture;
using CurrencyConverter.Api.Repository;
using Moq;

namespace CurrencyConverter.Api.UnitTests
{
    public class ConverterServiceCustomisation : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.OmitAutoProperties = true;

            var appRepositoryMock = new Mock<IAppRepository>();

            appRepositoryMock
                .Setup(x => x.CheckCurrencyCode(It.IsAny<string>()))
                .Returns(false);

            fixture.Inject(appRepositoryMock);
        }
    }
}
