
namespace Obligatorio.LogicaNegocio.Vo
{
    public record Nombre
    {
        public string Value { get; }

        public Nombre(string value)
        {
            Value = value;
        }
    }
}
