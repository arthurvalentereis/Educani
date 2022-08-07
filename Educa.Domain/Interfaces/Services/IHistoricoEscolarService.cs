using Educa.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Domain.Interfaces.Services
{
    public interface IHistoricoEscolarService
    {
        HistoricoEscolar Create(IFormFile file, string ipAddress);
        IEnumerable<HistoricoEscolar> List();
        HistoricoEscolar Update(HistoricoEscolar model);
        HistoricoEscolar Delete(HistoricoEscolar model);
        HistoricoEscolar GetById(int id);
    }
}
