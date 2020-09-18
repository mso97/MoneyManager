using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MM.Application.Core;
using MM.Domain;
using MM.Domain.Core;
using MM.Domain.Notifications;
using MM.Service.Interface;

namespace MM.Application.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LoginController : ApiBase
    {
        private readonly ILoginService _service;
        private readonly IValidator<Usuario> _validator;
        public LoginController(ILoginService service, IValidator<Usuario> validator, NotificationContext notificationContext)
        {
            _service = service;
            _validator = validator;
            _notificationContext = notificationContext;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonReturn> Post(Usuario usuario)
        {
            return RetornaJson(_service.Login(usuario));
        }
    }
}