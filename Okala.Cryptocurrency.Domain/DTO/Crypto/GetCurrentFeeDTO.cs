
namespace Okala.Cryptocurrency.Domain.DTO.Crypto
{
    public class GetCurrentFeeDTO
    {
        public CurrencyType[] Currency { get; init; }
        public CryptoType Crypto { get; init; }
    }

    public class GetCurrentFeeSelectedDTO
    {
        public string Crypto { get; set; }
        public Dictionary<string, object>? Currencies { get; init; }
    }

    public enum CurrencyType
    {
        USD,
        EUR,
        BRL,
        GBP,
        AUD
    }

    public enum CryptoType
    {
        USD,
        EUR,
        BRL,
        GBP,
        AUD,
        BTC,
        USDT,
        ETH,
    }
}
