using Okala.Cryptocurrency.Domain.Common;

namespace Okala.Cryptocurrency.Domain.Entities.Currencies
{
    public class Currency : BaseEntity
    {
        #region Ctors
        private Currency() {}
        public Currency(string currencyName, string currencyCode)
        {
            CurrencyCode = currencyCode;
            CurrencyName = currencyName;
        }
        #endregion

        #region Properties
        public string CurrencyName { get; private set; }
        public string CurrencyCode { get; private set; }
        #endregion

        #region Methods

        #endregion

    }
}
