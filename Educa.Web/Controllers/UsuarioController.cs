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
        private IHistoricoEscolarService _historicoEscolar { get; }
        private readonly IMapper _mapper;

        public UsuarioController(
            IUsuarioService usuarioService,
            IHistoricoEscolarService historicoEscolar,
            IMapper mapper
            )
        {
            _usuarioService = usuarioService;
            _historicoEscolar = historicoEscolar;
            _mapper = mapper;
        }
        [HttpPost("create")]
        public IActionResult Create([FromForm] NovoUsuarioRequest model)
        {
            try
            {
                Usuario novoUsuario = _mapper.Map<NovoUsuarioRequest, Usuario>(model);

                if (model.HistoricoEscolar != null)
                {
                    var historicoEscolar = _historicoEscolar.Create(model.HistoricoEscolar, IpAddress());
                    novoUsuario.HistoricoEscolarId = historicoEscolar.Id;
                }
                var usuario = _usuarioService.Create(novoUsuario, IpAddress());
                return Ok(usuario);
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

        [HttpGet("DownloadHistoricoEscolar/{id:int}")]
        public ActionResult DownloadHistoricoEscolar([FromRoute] int id)
        {
            try
            {
                var historicoEscolar =  _historicoEscolar.GetById(id);
                if (!System.IO.File.Exists(historicoEscolar.CaminhoArquivo))
                {
                    throw new ArgumentException("Arquivo não existe!");
                }
                return File(System.IO.File.ReadAllBytes(historicoEscolar.CaminhoArquivo), $"application/{historicoEscolar.Formato.Replace(".","")}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
