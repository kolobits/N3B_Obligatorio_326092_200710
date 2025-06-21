using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
    public class GetEnviosComentario : IGetEnviosComentario<EnvioListadoDto>
    {
        private IRepositorioEnvio _repo;

        public GetEnviosComentario(IRepositorioEnvio repo)
        {
            _repo = repo;
        }

        public IEnumerable<EnvioListadoDto> Execute( string comentario, int clienteId)
        {

            return EnvioMapper.ToListDto(_repo.GetEnviosComentario(comentario, clienteId));
        }
    }
}
