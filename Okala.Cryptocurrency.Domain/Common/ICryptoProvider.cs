using Okala.Cryptocurrency.Domain.DTO.Crypto;

namespace Okala.Cryptocurrency.Domain.Common
{
    public interface ICryptoProvider
    {
        string ProviderName { get; }
        int ProviderID { get; }
        Task<GetCurrentFeeSelectedDTO> GetCurrentFee(GetCurrentFeeDTO getCurrentFeeDTO, CancellationToken cancellationToken);
        Task EnsureAuthenticated();
    }
}
