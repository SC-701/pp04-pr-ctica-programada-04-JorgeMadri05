using Abstracciones.Interfaces.DA;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DA.Repositorios
{
    public class RepositorioDapper : IRepositarioDapper
    {
        private readonly IConfiguration _configuracion;
        private readonly SqlConnection _conexionBaseDeDatos;

        public RepositorioDapper(IConfiguration configuracion)
        {
            _configuracion = configuracion;
            _conexionBaseDeDatos = new SqlConnection(_configuracion.GetConnectionString("BD"));
        }
        public SqlConnection ObtenerRepositorio()
        {
            return _conexionBaseDeDatos;
            throw new NotImplementedException();
        }


    }
}
