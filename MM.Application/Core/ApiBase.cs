using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace MM.Application.Core
{
    public abstract class ApiBase : ControllerBase
    {
        public object retornaJson(object retorno)
        {
            object json = new
            {
                Status = (int)HttpStatusCode.OK,
                Retorno = retorno
            };

            return json;
        }
    }
}
