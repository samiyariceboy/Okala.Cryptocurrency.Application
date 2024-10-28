using Okala.Cryptocurrency.Domain.DTO.Crypto;

namespace Okala.Cryptocurrency.Application.DTO.Crypto
{
    public class GetBestCryptoFeeDTO
    {

        public CurrencyType[] Currency { get; init; }
        public CryptoType Crypto { get; init; }
    }

    public class GetBestCryptoFeeSelectedDTO
    {
        public object[] Result { get; init; }
    }
}
