
namespace Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario
{
    public interface ILogin<T>
    {
        T Execute(string email, string password);
    }


}
