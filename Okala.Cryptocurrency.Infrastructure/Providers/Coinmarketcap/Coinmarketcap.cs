using Okala.Cryptocurrency.Domain.Common;
using Okala.Cryptocurrency.Domain.DTO.Crypto;
using Okala.Cryptocurrency.Infrastructure.Providers.Coinmarketcap.Models;
using Okala.Cryptocurrency.Domain.Common.Utilities;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Okala.Cryptocurrency.Infrastructure.Providers.Coinmarketcap
{
    public class Coinmarketcap(HttpClient httpClient, string providerName, int providerId, string providerBaseUrl,
        string providerAccessKey) : CryptoProvider(httpClient, providerName, providerId, providerBaseUrl, providerAccessKey)
    {
        private static readonly SemaphoreSlim s_loginSemaphore = new(1);


        public override async Task<GetCurrentFeeSelectedDTO> GetCurrentFee(GetCurrentFeeDTO getCurrentFeeDTO, CancellationToken cancellationToken)
        {
            await EnsureAuthenticated();
            var response = await client.GetAsync
                (string.Format("v1/cryptocurrency/price-performance-stats/latest?symbol={0}&convert={1}",
                 string.Join(',', getCurrentFeeDTO.Crypto), string.Join(',', getCurrentFeeDTO.Currency.Select(s => s.ToDisplay()))), cancellationToken);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = JsonSerializer.Deserialize<CoinMarketCapCryptocurrencyMap>(stringResult);
            return new GetCurrentFeeSelectedDTO()
            {
                Currencies = result.data.ToDictionary().Where(c => c.Value != null).ToDictionary()

            };
        }

        public async override Task EnsureAuthenticated()
        {
            await s_loginSemaphore.WaitAsync();

            try
            {
                client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", providerAccessKey);
            }
            finally
            {
                s_loginSemaphore.Release();
            }
        }
    }
}
