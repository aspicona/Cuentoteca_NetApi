namespace Cuentoteca_netApi.Resultados.Usuarios
{
    public class ResultadoRegistrar : ResultadoBase
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; } = null!;

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdRol { get; set; } = 0;

        public int IdNivelLector { get; set; } = 0;
    }
}
