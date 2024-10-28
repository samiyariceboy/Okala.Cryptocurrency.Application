using Okala.Cryptocurrency.Application.DTO.Crypto;

namespace Okala.Cryptocurrency.Application.Services.ApplicationServices
{
    public interface ICryptoManagerService
    {
        Task<GetBestCryptoFeeSelectedDTO> GetBestCryptoFee(GetBestCryptoFeeDTO getCurrentFeeDTO, CancellationToken cancellationToken);
    }
}