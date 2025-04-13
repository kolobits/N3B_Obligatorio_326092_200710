using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.Infraestructura.AccesoDatos.Lista
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private static List<Usuario> _usuarios = new List<Usuario>();

        public void Add(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException("Esta vacio");
            }
            usuario.Validar();
            if (_usuarios.Contains(usuario))
            {
                throw new EmailRepetidoException("esta repetido");
            }
            _usuarios.Add(usuario);
        }

        public void Remove(int id)
        {
            Usuario usuarioEliminar = GetById(id);
            _usuarios.Remove(usuarioEliminar);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarios;
        }

        public Usuario GetById(int id)
        {
            Usuario usuarioEliminar = null;
            foreach (var usuario in _usuarios)
            {
                if (usuario.Id == id)
                    usuarioEliminar = usuario;
            }
            return usuarioEliminar;
        }


        public void Update(int id, Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Usuario GetByEmail(string email)
        {
            Usuario usuarioAEncontrar = null;
            foreach (var usuario in _usuarios)
            {
                if (usuario.Email.Value == email)
                    usuarioAEncontrar = usuario;
            }
            return usuarioAEncontrar;
        }
    }
    
}

