using Newtonsoft.Json;
using Okala.Cryptocurrency.Domain.Common;
using Okala.Cryptocurrency.Domain.Common.Utilities;
using Okala.Cryptocurrency.Domain.DTO.Crypto;
using Okala.Cryptocurrency.Infrastructure.Providers.Coinmarketcap.Models;
using Okala.Cryptocurrency.Infrastructure.Providers.Exchangeratesapi.Models;

namespace Okala.Cryptocurrency.Infrastructure.Providers.Exchangeratesapi
{
    public class Exchangeratesapi(HttpClient httpClient, string providerName, int providerId, string providerBaseUrl,
        string providerAccessKey) : CryptoProvider(httpClient, providerName, providerId, providerBaseUrl, providerAccessKey)
    {
        private static readonly SemaphoreSlim s_loginSemaphore = new(1);
        public async override Task<GetCurrentFeeSelectedDTO> GetCurrentFee(GetCurrentFeeDTO getCurrentFeeDTO, CancellationToken cancellationToken)
        {
            //await EnsureAuthenticated();
            var response = await client.GetAsync(string.Format("latest?access_key={0}&symbols={1}",
                providerAccessKey, string.Join(',', string.Join(',', getCurrentFeeDTO.Currency.Select(s => s.ToDisplay()))), cancellationToken), cancellationToken);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync(cancellationToken);
            try
            {
                var result = JsonConvert.DeserializeObject<ExchangeratesapiLatestResult>(stringResult);
                return new GetCurrentFeeSelectedDTO
                {
                    Currencies = result.Rates.ToDictionary()
                    .Where(c => c.Value != null).ToDictionary()
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public override Task EnsureAuthenticated()
        {
            throw new NotImplementedException();
        }
    }
}
