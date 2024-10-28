using Okala.Cryptocurrency.Domain.Common;

namespace Okala.Cryptocurrency.Domain.Entities.Providers
{
    public class CryptoProvider : BaseEntity
    {
        #region Ctors
        private CryptoProvider() {}
        public CryptoProvider(string providerName, string providerID)
        {
            ProviderName = providerName;
            ProviderID = providerID;
        }
        #endregion

        #region Properties
        public string ProviderName { get; private set; }
        public string ProviderID { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        
        #endregion

        #region Collections

        #endregion
        #endregion

        #region Methods 

        #endregion
    }
}
