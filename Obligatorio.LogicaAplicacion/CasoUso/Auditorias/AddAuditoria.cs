using Obligatorio.CasoDeUsoCompartida.DTOs;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Auditorias;
using Obligatorio.LogicaNegocio.InterfacesRepositorios.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasoUso.Auditorias
{
    public class AddAuditoria : IAddAuditoria<AuditoriaDto>
    {
        private IRepositorioAuditoria _repo;

        public AddAuditoria (IRepositorioAuditoria repo)
        {
            _repo = repo;
        }

        public void Execute(AuditoriaDto auditoriaDto)
        {
            _repo.Add(AuditoriaMapper.FromDto(auditoriaDto));
        }
    }
}
