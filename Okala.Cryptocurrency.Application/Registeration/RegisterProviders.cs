using Okala.Cryptocurrency.Domain.Common;
using Okala.Cryptocurrency.Infrastructure.Providers.Coinmarketcap;
using Okala.Cryptocurrency.Infrastructure.Providers.Exchangeratesapi;

namespace Okala.Cryptocurrency.Application.Registeration
{
    public static class RegisterProviders
    {
        public static void RegisterCoinMarketCap(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<Coinmarketcap>(ctx =>
            {
                var providerBaseUrl = config.GetValue<string>("Providers:Coinmarketcap:ProviderBaseUrl") ?? "";
                ctx.BaseAddress = new Uri(providerBaseUrl);
            });

            //Then set up DI for the TypedClient
            services.AddScoped<ICryptoProvider>(ctx =>
            {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var config = ctx.GetRequiredService<IConfiguration>();
                var httpClient = clientFactory.CreateClient(nameof(Coinmarketcap));

                var providerName = config.GetValue<string>("Providers:Coinmarketcap:ProviderName") ?? "";
                var providerId = config.GetValue<int>("Providers:Coinmarketcap:ProviderId");
                var providerBaseUrl = config.GetValue<string>("Providers:Coinmarketcap:ProviderBaseUrl") ?? "";
                var providerAccessKey = config.GetValue<string>("Providers:Coinmarketcap:ProviderAccessKey") ?? "";

                return new Coinmarketcap(httpClient, providerName, providerId, providerBaseUrl, providerAccessKey);
            });
        }

        public static void RegisterExchangeratesapi(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<Exchangeratesapi>(ctx =>
            {
                var providerBaseUrl = config.GetValue<string>("Providers:Exchangeratesapi:ProviderBaseUrl") ?? "";
                ctx.BaseAddress = new Uri(providerBaseUrl);
            });

            //Then set up DI for the TypedClient
            services.AddScoped<ICryptoProvider>(ctx =>
            {
                var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
                var config = ctx.GetRequiredService<IConfiguration>();
                var httpClient = clientFactory.CreateClient(nameof(Exchangeratesapi));

                var providerName = config.GetValue<string>("Providers:Exchangeratesapi:ProviderName") ?? "";
                var providerId = config.GetValue<int>("Providers:Exchangeratesapi:ProviderId");
                var providerBaseUrl = config.GetValue<string>("Providers:Exchangeratesapi:ProviderBaseUrl") ?? "";
                var providerAccessKey = config.GetValue<string>("Providers:Exchangeratesapi:ProviderAccessKey") ?? "";

                return new Exchangeratesapi(httpClient, providerName, providerId, providerBaseUrl, providerAccessKey);
            });
        }
    }
}
