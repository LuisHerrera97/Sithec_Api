using Sithec_Prueba.Entities;
using Sithec_Prueba.Utils;

namespace Sithec_Prueba.Data.Interfaces
{
    public interface IDatHumano
    {
        Task<SithecResponse<bool>> SaveHumano(EntHumano entHumano);
        Task<SithecResponse<bool>> UpdateHumano(EntHumano entHumano);
        Task<SithecResponse<bool>> DeleteHumano(Guid iKey);
        Task<SithecResponse<bool>> AnyExistKey(Guid uidKey);
        Task<SithecResponse<bool>> AnyExistName(EntHumano entHumano);
        Task<SithecResponse<List<EntHumano>>> Get();
        Task<SithecResponse<EntHumano>> GetHumanoById(Guid iKey);
    }
}
