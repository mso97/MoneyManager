using Microsoft.AspNetCore.Mvc;
using MM.Service.Interface;

namespace MM.Application.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            return _service.resultado();
        }
    }
}
