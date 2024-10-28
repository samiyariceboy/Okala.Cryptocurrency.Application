namespace Okala.Cryptocurrency.Infrastructure.Providers.Options
{
    public class ProviderOptions
    {
        public int ProviderId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ApiKey { get; set; }
        public string? BaseAddress { get; set; }
    }
}