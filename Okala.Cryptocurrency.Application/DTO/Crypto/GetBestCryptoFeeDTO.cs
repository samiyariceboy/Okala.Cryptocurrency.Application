using Okala.Cryptocurrency.Domain.DTO.Crypto;

namespace Okala.Cryptocurrency.Application.DTO.Crypto
{
    public class GetBestCryptoFeeDTO
    {

        public CurrencyType[] Currency { get; init; } = [CurrencyType.USD, CurrencyType.EUR, CurrencyType.BRL, CurrencyType.GBP, CurrencyType.AUD];
        public CryptoType Crypto { get; init; } = CryptoType.BTC;
    }

    public class GetBestCryptoFeeSelectedDTO
    {
        public object[] Result { get; init; }
    }
}
