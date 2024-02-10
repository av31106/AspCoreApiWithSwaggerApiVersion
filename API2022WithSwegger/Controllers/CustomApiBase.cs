using API2022WithSwegger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2022WithSwegger.Controllers
{
    [ApiController]
    [Route("Api/[area]/[controller]/[action]")]
    public class CustomApiBase : ControllerBase
    {
        internal ResultReponse ResponseSend(Boolean isSuccess, dynamic? result = null, string? errorMessage = null, 
            string? errorType = null, string? errorTypeDescription = null)
        {
            ResultReponse resultReponse = new ResultReponse();
            if (isSuccess)
            {
                resultReponse.IsSussses = true;
                resultReponse.Result = result;
            }
            else
            {
                resultReponse.IsSussses = false;
                resultReponse.ErrorId = Guid.NewGuid();
                resultReponse.ErrorMessage = errorMessage;
                resultReponse.ErrorType = errorType;
                resultReponse.ErrorTypeDescription = errorTypeDescription;
                resultReponse.Result = null;
            }

            return resultReponse;
        }
    }
}
