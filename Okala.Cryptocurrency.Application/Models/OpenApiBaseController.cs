using Microsoft.AspNetCore.Components;

namespace Okala.Cryptocurrency.Application.Models
{

    public class InternalApiController : BaseController
    {
    }


    [Route("api/v{version:apiVersion}/[controller]")]
    public class OpenApiController : BaseController
    {
    }
}
