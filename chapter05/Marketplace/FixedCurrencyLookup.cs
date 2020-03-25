using System.Collections.Generic;
using System.Linq;
using Marketplace.Domain;

namespace Marketplace
{
    public class FixedCurrencyLookup : ICurrencyLookup
    {
        private static readonly IEnumerable<Currency> Currencies =
            new[]
            {
                new Currency
                {
                    CurrencyCode = "EUR",
                    DecimalPlaces = 2,
                    InUse = true
                },
                new Currency
                {
                    CurrencyCode = "USD",
                    DecimalPlaces = 2,
                    InUse = true
                }
            };

        public Currency FindCurrency(string currencyCode)
        {
            var currency = Currencies.FirstOrDefault(x => x.CurrencyCode == currencyCode);
            return currency ?? Currency.None;
        }
    }
}