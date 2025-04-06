namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioGetById<T>
    {
        T GetById(int id);
    }
}