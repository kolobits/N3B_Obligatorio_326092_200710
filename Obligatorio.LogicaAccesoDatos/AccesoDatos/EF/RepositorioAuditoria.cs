using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
    public class RepositorioAuditoria
    {
        private ObligatorioContext _context;

        public RepositorioAuditoria(ObligatorioContext context)
        {
            _context = context;
        }
        public void Add(Auditoria obj)
        {
            _context.Auditorias.Add(obj);
            _context.SaveChanges();
        }
    }
}
