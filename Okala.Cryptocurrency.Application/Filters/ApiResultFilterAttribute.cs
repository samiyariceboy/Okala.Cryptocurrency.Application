using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Okala.Cryptocurrency.Application.Models;
using Okala.Cryptocurrency.Domain.Common;

namespace Okala.Cryptocurrency.Application.Filters
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult1 && context.ModelState.IsValid && context.ActionDescriptor.DisplayName == "VoipService.Api.Controllers.v1.AuthController.GetTokenJustForSwagger (VoipService.Api)")
            {
                ApiResult<object> apiResult = new ApiResult<object>(true, ApiResultStatusCode.Success, objectResult1.Value);
                context.Result = new JsonResult(apiResult.Data);
                //moshkel dar Controller Tozih Dadeh Shod
            }
            if (context.Result is ObjectResult objectResult && context.ModelState.IsValid)
            {
                ApiResult<object> apiResult = new ApiResult<object>(true, ApiResultStatusCode.Success, objectResult.Value);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is OkResult okResult)
            {
                ApiResult apiResult = new ApiResult(true, ApiResultStatusCode.Success);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is BadRequestResult badRequestResult)
            {
                ApiResult apiResult = new ApiResult(false, ApiResultStatusCode.BadRequest);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                string message = badRequestObjectResult.Value.ToString();
                if (badRequestObjectResult.Value is SerializableError error)
                {
                    IEnumerable<string> errorMessage = error.SelectMany(p => (string[])p.Value).Distinct();
                    message = string.Join("|", errorMessage);
                }
                ApiResult apiResult = new ApiResult<object>(false, ApiResultStatusCode.BadRequest, badRequestObjectResult.Value);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is ContentResult contentResult)
            {
                ApiResult apiResult = new ApiResult(true, ApiResultStatusCode.Success, contentResult.Content);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is NotFoundResult notFoundResult)
            {
                ApiResult apiResult = new ApiResult(false, ApiResultStatusCode.NotFound);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is NotFoundObjectResult notFoundObjectResult)
            {
                ApiResult<object> apiResult = new ApiResult<object>(false, ApiResultStatusCode.NotFound, notFoundObjectResult.Value);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is ObjectResult ObjectResult && ObjectResult.StatusCode == null
                && !(ObjectResult.Value is ApiResult))
            {
                ApiResult<object> apiResult = new ApiResult<object>(true, ApiResultStatusCode.NotFound, ObjectResult.Value);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is ChallengeResult challengeResult)
            {
                ApiResult<object> apiResult = new ApiResult<object>(true, ApiResultStatusCode.Success, challengeResult);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is BadRequestObjectResult)
            {

            }
            base.OnResultExecuting(context);
        }
    }

}
