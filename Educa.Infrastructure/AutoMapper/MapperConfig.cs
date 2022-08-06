using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Infrastructure.AutoMapper
{
    public class MapperConfig
    {
        public MapperConfiguration Configure() => new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
    }
}
