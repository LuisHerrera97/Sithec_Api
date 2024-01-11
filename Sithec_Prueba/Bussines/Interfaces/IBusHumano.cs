using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Bussines.Interfaces
{
    public interface IBusHumano
    {
        Task<SithecResponse<bool>> BSaveHumano(EntHumanoCreacion entHumanoCreacion);
        Task<SithecResponse<bool>> BUpdateHumano(EntHumano entIncomeSchedules);
        Task<SithecResponse<bool>> BDeleteHumano(Guid ikey);
        Task<SithecResponse<List<EntHumano>>> bGetAll();
        Task<SithecResponse<List<EntHumano>>> bGetHumanosMock();
        Task<SithecResponse<EntHumano>> bGetHumanoById(Guid uIdKey);
    }
}
