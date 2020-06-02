using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MM.Application.Core;
using MM.Domain;
using MM.Domain.Notifications;
using MM.Service.Interface;
using System.Net;
using System.Threading.Tasks;

namespace MM.Application.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ApiBase
    {
        private readonly IUsuarioService _service;
        private readonly IValidator<Usuario> _validator;
        public UsuarioController(IUsuarioService service, IValidator<Usuario> validator, NotificationContext notificationContext)
        {
            _service = service;
            _validator = validator;
            _notificationContext = notificationContext;
        }

        [HttpPost]
        public async Task<JsonReturn> Post(Usuario usuario)
        {
            ValidationResult results = _validator.Validate(usuario);
            JsonReturn j;
            if (results.IsValid)
                return RetornaJson(_service.Inserir(usuario));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }
    }
}
