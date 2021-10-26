using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Prodest.EOuv.Dominio.Modelo;
using Prodest.EOuv.Dominio.Modelo.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodest.EOuv.Infra.DAL
{
    public class SetorRepository : ISetorRepository
    {
        private readonly EouvContext _eouvContext;
        private readonly IMapper _mapper;

        public SetorRepository(EouvContext context, IMapper mapper)
        {
            _eouvContext = context;
            _mapper = mapper;
        }

        public async Task<SetorModel> BuscarSetor(string idSetor)
        {
            var setor = await _eouvContext.Setor
                                    .Include(m => m.Orgao)
                                    //.Include(m => m.Orgao.Patriaca)
                                    .Where(d => d.GuidSetor == new Guid(idSetor)).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<SetorModel>(setor);
        }
    }
}