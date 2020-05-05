using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MM.Application.Core
{
    public abstract class ApiBase : ControllerBase
    {
        public JsonReturn RetornaJson(object retorno, int status = (int)HttpStatusCode.OK)
        {
            JsonReturn json = new JsonReturn();
            
            if (status == (int)HttpStatusCode.OK)
            {
                json.Data = retorno;
                json.StatusCode = (int)HttpStatusCode.OK;
                json.Success = true;
            }
            else
            {
                json.Error = retorno;
                json.StatusCode = status;
                json.Success = false;
            }
            return json;
        }
    }
}
