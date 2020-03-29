using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using MM.Application.Core;
using MM.Domain;
using MM.Service.Interface;
using System.Threading.Tasks;

namespace MM.Application.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuariosController : ApiBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<object> Post(Usuario usuario)
        {
            return retornaJson(_service.Inserir(usuario));
        }
    }
}
