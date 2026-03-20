using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Numerics;

namespace DA
{
    public class VehiculoDA : IVehiculoDA
    {

        private IRepositarioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor
        public VehiculoDA(IRepositarioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new {
                Id = Guid.NewGuid(),
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            await ValidarVehiculoExiste(Id);
            string query = @"EditarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await ValidarVehiculoExiste(Id);
            string query = @"EliminarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoResponse>(query);
            return resultadoConsulta;
        }

        public async Task<VehiculoDetalle> Obtener(Guid Id)
        {
            string query = @"ObtenerVehiculo";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoDetalle>(query, new 
            { 
                Id = Id 
            });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<IEnumerable<Modelo>> ObtenerModelos(Guid IdMarca)
        {
            string query = @"ObtenerModelos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Modelo>(query, new 
            { 
                IdMarca = IdMarca
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<Marca>> ObtenerMarcas()
        {
            string query = @"ObtenerMarcas";
            var resultadoConsulta = await _sqlConnection.QueryAsync<Marca>(query);
            return resultadoConsulta;
        }
        #endregion

        #region Helpers
        private async Task ValidarVehiculoExiste(Guid Id)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(Id);
            if (resultadoConsultaVehiculo == null)
                throw new Exception("No se encontro el vehiculo.");
        }
        #endregion
    }
}
