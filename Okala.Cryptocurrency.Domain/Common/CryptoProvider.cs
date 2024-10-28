using Okala.Cryptocurrency.Domain.DTO.Crypto;

namespace Okala.Cryptocurrency.Domain.Common
{
    public abstract class CryptoProvider(HttpClient httpClient,
        string providerName, int providerId, string providerBaseUrl, string providerAccessKey) : ICryptoProvider
    {
        #region Fiesls
        protected readonly HttpClient client = httpClient;
        private readonly string providerName = providerName;
        private readonly int providerId = providerId;
        protected readonly string providerBaseUrl = providerBaseUrl;
        protected readonly string providerAccessKey = providerAccessKey;

        #endregion
        #region Ctors


        #endregion

        #region Propeties
        public virtual string ProviderName  => providerName;
        public virtual int ProviderID => providerId;

        #endregion

        #region Methods 
        public abstract Task<GetCurrentFeeSelectedDTO> GetCurrentFee(GetCurrentFeeDTO getCurrentFeeDTO, CancellationToken cancellationToken);
        public abstract Task EnsureAuthenticated();
        #endregion
    }
}
