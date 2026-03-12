using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;

namespace Abstracciones.Interfaces.DA
{
    public interface IVehiculoDA
    {
        Task<IEnumerable<VehiculoResponse>> Obtener();
        Task<VehiculoDetalle> Obtener(Guid Id);
        Task<Guid> Agregar(VehiculoRequest vehiculo);
        Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo);
        Task<Guid> Eliminar(Guid Id);
        Task<IEnumerable<Modelo>> ObtenerModelos(Guid IdMarca);
        Task<IEnumerable<Marca>> ObtenerMarcas();
    }
}
