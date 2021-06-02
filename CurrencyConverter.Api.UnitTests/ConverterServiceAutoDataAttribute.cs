using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace CurrencyConverter.Api.UnitTests
{
    public class ConverterServiceAutoDataAttribute : DefaultAutoDataAttribute
    {
        public ConverterServiceAutoDataAttribute()
            : base(fixture => fixture.Customize(new ConverterServiceCustomisation()))
        {
        }
    }

    public class ConverterServiceInlineAutoDataAttribute : InlineAutoDataAttribute
    {
        public ConverterServiceInlineAutoDataAttribute(params object[] objects) : base(new ConverterServiceAutoDataAttribute(), objects) { }
    }

    public class DefaultAutoDataAttribute : AutoDataAttribute
    {
        public DefaultAutoDataAttribute(Action<IFixture> fixtureAction, bool omitAutoProperties = false) : base(() =>
        {
            var fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization
            {
                ConfigureMembers = true
            });

            fixture.OmitAutoProperties = omitAutoProperties;

            fixtureAction.Invoke(fixture);

            return fixture;
        })
        {
        }
    }
}
