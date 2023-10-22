namespace Cuentoteca_netApi.Resultados.Usuarios
{
    public class ResultadoDelete : ResultadoBase
    {
        public int IdUsuario { get; set; }
        public string? Mensaje { get; set; }

        public void SetMensaje(string mensaje)
        {
            OK = true;
            Mensaje = mensaje;
        }

    }
}
