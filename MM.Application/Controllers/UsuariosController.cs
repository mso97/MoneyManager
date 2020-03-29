using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using MM.Domain;
using MM.Service.Interface;
using System.Threading.Tasks;

namespace MM.Application.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<WriteResult> Post(Usuario usuario)
        {
            return await _service.Inserir(usuario);
        }
    }
}
