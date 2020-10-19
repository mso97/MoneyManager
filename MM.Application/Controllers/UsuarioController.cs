using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MM.Application.Core;
using MM.Domain;
using MM.Domain.Notifications;
using MM.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace MM.Application.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ApiBase
    {
        private readonly IUsuarioService _service;
        private readonly ILoginService _loginService;
        private readonly IValidator<Usuario> _validator;
        public UsuarioController(IUsuarioService service, ILoginService loginService, IValidator<Usuario> validator, NotificationContext notificationContext)
        {
            _service = service;
            _loginService = loginService;
            _validator = validator;
            _notificationContext = notificationContext;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonReturn> Post(Usuario usuario)
        {
            ValidationResult results = _validator.Validate(usuario);
            JsonReturn j;
            if (results.IsValid)
                return RetornaJson(_service.Inserir(usuario));
            else
                return RetornaJson(results.Errors, (int)HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public async Task<JsonReturn> Get()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var jtwToken = _loginService.DecryptToken(token);
            Guid id = Guid.Parse(jtwToken.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            return RetornaJson(_service.Consultar(id));
        }
    }
}
