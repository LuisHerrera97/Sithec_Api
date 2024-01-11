using Sithec_Prueba.Entities;
using Sithec_Prueba.Utils;

namespace Sithec_Prueba.Bussines.Interfaces
{
    public interface IBusOperaciones
    {
        Task<SithecResponse<double>> BRealizarOperacion(EntOperacion entOperacion);
    }
}
