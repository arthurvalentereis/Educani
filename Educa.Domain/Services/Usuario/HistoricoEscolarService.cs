using Educa.Domain.Entities;
using Educa.Domain.Interfaces.Repositories;
using Educa.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Domain.Services.Usuario
{
    public class HistoricoEscolarService : IHistoricoEscolarService
    {
        private readonly IHistoricoEscolarRepository _context;
        private string _caminhoArquivoSalvo { get; }

        public HistoricoEscolarService(
            IHistoricoEscolarRepository context,
            IConfiguration configuration)
        {
            _context = context;
            _caminhoArquivoSalvo = configuration["Ambiente:CaminhoArquivosHistoricoEscolar"];
        }

        public Entities.HistoricoEscolar Create(IFormFile file, string ipAddress)
        {
            if (!Directory.Exists(_caminhoArquivoSalvo))
                Directory.CreateDirectory(_caminhoArquivoSalvo);

            string filePathArquivo = Path.Combine(_caminhoArquivoSalvo, file.FileName);
            using (var fileStream = new FileStream(filePathArquivo, FileMode.Create))
            {
                file.CopyToAsync(fileStream);
            }

            var historicoEscolar = new HistoricoEscolar(
                                        Formato: Path.GetExtension(filePathArquivo),
                                        Nome: file.FileName,
                                        CaminhoArquivo: filePathArquivo
                                        );

            return _context.Add(historicoEscolar);
        }
        public Entities.HistoricoEscolar Update(Entities.HistoricoEscolar HistoricoEscolar)
        {
            return _context.Update(HistoricoEscolar);
        }
        public Entities.HistoricoEscolar Delete(Entities.HistoricoEscolar model)
        {
            try
            {
                _context.Delete(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Entities.HistoricoEscolar> List()
        {
            var HistoricoEscolar = _context.List().ToList();
            return HistoricoEscolar;
        }
        public Entities.HistoricoEscolar GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("HistoricoEscolar id was not informed");
            }

            var HistoricoEscolar = _context.GetById(id);
            if (HistoricoEscolar == null) throw new KeyNotFoundException("HistoricoEscolar not found");

            return HistoricoEscolar;
        }

    }
}
