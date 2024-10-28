using Microsoft.AspNetCore.Mvc;
using Okala.Cryptocurrency.Application.DTO.Crypto;
using Okala.Cryptocurrency.Application.Models;
using Okala.Cryptocurrency.Application.Services.ApplicationServices;

namespace Okala.Cryptocurrency.Application.Controllers.v1
{
    [ApiVersion("1")]
    public class CryptoController(ICryptoManagerService cryptoManagerService) : BaseController
    {
        private readonly ICryptoManagerService _cryptoManagerService = cryptoManagerService;


        [HttpGet("[action]")]
        public virtual async Task<ActionResult> GetBestCryptoFee([FromQuery] GetBestCryptoFeeDTO getBestCryptoFeeDTO, CancellationToken cancellationToken)
        {
            var result = await _cryptoManagerService.GetBestCryptoFee(getBestCryptoFeeDTO, cancellationToken);
            return Ok(result);
        }
    }
}