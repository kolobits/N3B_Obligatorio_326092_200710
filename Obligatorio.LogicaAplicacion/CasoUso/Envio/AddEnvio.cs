using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Envios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Envio;
using Obligatorio.CasoDeUsoCompartida.DTOs.Envios;

namespace Obligatorio.LogicaAplicacion.CasoUso.Envio
{
    public class AddEnvio : IAddEnvio<EnvioDto>
    {
        private IRepositorioEnvio _repo;
        public AddEnvio(
                        IRepositorioEnvio repo
                        )
        {
            _repo = repo;

        }


        public void Execute(EnvioDto envioDto)
        {
            //_repo.Add(EnvioMapper.FromDto(envioDto));
        }

    }
}
