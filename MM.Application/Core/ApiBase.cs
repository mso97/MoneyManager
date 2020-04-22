using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace MM.Application.Core
{
    public abstract class ApiBase : ControllerBase
    {
        public JsonReturn RetornaJson(object retorno, int status = (int)HttpStatusCode.OK)
        {
            JsonReturn json = new JsonReturn(retorno, status);
            return json;
        }
    }
}
