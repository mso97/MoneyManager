using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace MM.Application.Core
{
    public abstract class ApiBase : ControllerBase
    {
        public object RetornaJson(object retorno, int status = (int)HttpStatusCode.OK)
        {
            object json = new
            {
                Status = status,
                Retorno = retorno
            };

            return json;
        }
    }
}
