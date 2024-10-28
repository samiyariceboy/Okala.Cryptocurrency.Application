using Okala.Cryptocurrency.Application.DTO.Crypto;
using Okala.Cryptocurrency.Domain.Common;
using Okala.Cryptocurrency.Domain.Common.InterfaceDependency;
using Okala.Cryptocurrency.Domain.DTO.Crypto;

namespace Okala.Cryptocurrency.Application.Services.ApplicationServices
{
    public class CryptoManagerService(IEnumerable<ICryptoProvider> cryptoProviders)
        : ICryptoManagerService, IScopedDependency
    {
        private readonly IEnumerable<ICryptoProvider> _cryptoProviders = cryptoProviders;

        public async Task<GetBestCryptoFeeSelectedDTO> GetBestCryptoFee(GetBestCryptoFeeDTO getCurrentFeeDTO, CancellationToken cancellationToken)
        {
            var providerResults = new List<GetCurrentFeeSelectedDTO>();
            var providerTasks = _cryptoProviders
                .Select(s => s.GetCurrentFee(new GetCurrentFeeDTO
                {
                    Crypto = getCurrentFeeDTO.Crypto,
                    Currency = getCurrentFeeDTO.Currency,
                }, cancellationToken)).ToList();


            foreach (var providerTask in providerTasks)
            {
                try
                {
                    var providerResult = await providerTask;
                    providerResults.Add(providerResult);
                }
                catch (Exception e)
                {

                }
            }


            return new GetBestCryptoFeeSelectedDTO
            {
                Result = providerResults.ToArray()
            };
        }
    }


}
