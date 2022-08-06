using AutoMapper;
using Educa.Domain.Dto.Usuario.Request;
using Educa.Domain.Entities;
using Educa.Domain.Interfaces.Services;
using Educa.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Educa.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        private IUsuarioService _usuarioService { get; }
        private readonly IMapper _mapper;

        public UsuarioController(
            IUsuarioService usuarioService,
            IMapper mapper
            )
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        public IActionResult Create(NovoUsuarioRequest model)
        {
            try
            {
                Usuario usuario = _mapper.Map<NovoUsuarioRequest, Usuario>(model);
                var user = _usuarioService.Create(usuario, IpAddress());
                return Ok(user);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut("update")]
        public IActionResult Update(AtualizaUsuarioRequest model)
        {
            try
            {
                Usuario usuario = _mapper.Map<AtualizaUsuarioRequest, Usuario>(model);
                var response = _usuarioService.Update(usuario);
                return Ok(response);
            }
            catch 
            {
                throw;
            }
        }
        [HttpDelete("remove")]
        public IActionResult Remove(int id)
        {
            try
            {
                var user = _usuarioService.GetById(id);
                if (user == null)
                    throw new KeyNotFoundException("usuário não encontrado");

                return Ok(_usuarioService.Delete(user));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("getUserById")]
        public IActionResult GetUserByID(int id)
        {
            try
            {
                return Ok(_usuarioService.GetById(id));
            }
            catch 
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var user = _usuarioService.List();
                return Ok(user);
            }
            catch 
            {
                throw;
            }
        }
    }
}
