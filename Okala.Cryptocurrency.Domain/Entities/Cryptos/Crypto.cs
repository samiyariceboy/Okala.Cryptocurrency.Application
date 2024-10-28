using Okala.Cryptocurrency.Domain.Common;

namespace Okala.Cryptocurrency.Domain.Entities.Cryptos
{
    public class Crypto : AggregateRoot<Guid>
    {
        #region Ctors
        private Crypto() {}
        #endregion

        #region Propeties
        public string CryptoName { get; private set; }
        public string CryptoCode { get; private set; }
        #endregion

        #region Relations

        #endregion

        #region Methods

        #endregion

    }
}
