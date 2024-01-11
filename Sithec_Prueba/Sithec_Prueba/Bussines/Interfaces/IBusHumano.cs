using Sithec_Prueba.Entities;
using Sithec_Prueba.Utils;

namespace Sithec_Prueba.Bussines.Interfaces
{
    public interface IBusHumano
    {
        Task<SithecResponse<bool>> BSaveHumano(EntHumano entIncomeSchedules);
        Task<SithecResponse<bool>> BUpdateHumano(EntHumano entIncomeSchedules);
        Task<SithecResponse<bool>> BDeleteHumano(Guid ikey);
        Task<SithecResponse<List<EntHumano>>> bGetAll();
        Task<SithecResponse<List<EntHumano>>> bGetHumanosMock();
        Task<SithecResponse<EntHumano>> bGetHumanoById(Guid uIdKey);
    }
}
