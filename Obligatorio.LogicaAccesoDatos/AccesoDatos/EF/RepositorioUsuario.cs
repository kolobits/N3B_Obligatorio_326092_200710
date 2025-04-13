
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Vo;

namespace Obligatorio.Infraestructura.AccesoDatos.EF
{
	public class RepositorioUsuario : IRepositorioUsuario
	{
		private ObligatorioContext _context;

		public RepositorioUsuario(ObligatorioContext context)
		{
			_context = context;
		}
		public void Add(Usuario obj)
		{
			_context.Usuarios.Add(obj);
			_context.SaveChanges();
		}

		public IEnumerable<Usuario> GetAll()
		{
			return _context.Usuarios.ToList();
		}

		public Usuario GetById(int id)
		{
			Usuario usuarioEliminar = null;
			foreach (Usuario usuario in _context.Usuarios)
			{
				if (usuario.Id == id)
				{
					usuarioEliminar = usuario;
				}
			}
			return usuarioEliminar;
		}

		public void Remove(int id)
		{
			Usuario usuarioELiminar = GetById(id);
			_context.Usuarios.Remove(usuarioELiminar);
			_context.SaveChanges();
		}

        public void Update(int id, Usuario obj)
        {
            Usuario unU = GetById(id);
			unU.Update(obj);
			_context.Usuarios.Update(unU);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetByEmail(string value)
        {
            return _context.Usuarios
                .Where(usuario => usuario.Email.Value.ToLower().Contains(value.ToLower()));
        }

        Usuario IRepositorioGetByEmail<Usuario>.GetByEmail(string email)
        {
            Usuario usuarioAEncontrar = null;
            foreach (Usuario usuario in _context.Usuarios)
            {
                if (usuario.Email.Value == email)
                {
                    usuarioAEncontrar = usuario;
                }
            }
            return usuarioAEncontrar;
        }

        
    }
}
