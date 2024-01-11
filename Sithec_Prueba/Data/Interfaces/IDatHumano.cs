using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Data.Interfaces
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
