using Sithec_Prueba.Bussines.Interfaces;
using Sithec_Prueba.Data.Interfaces;
using Sithec_Prueba.Entities;
using Sithec_Prueba.Utils;

namespace Sithec_Prueba.Bussines
{
    public class BusHumano:IBusHumano
    {
        private readonly IDatHumano datHumano;

        public BusHumano(IDatHumano datHumano)
        {
            this.datHumano = datHumano;
        }

        public async Task<SithecResponse<bool>> BSaveHumano(EntHumano entHumano)
        {
            SithecResponse<bool> response = new SithecResponse<bool>();

            try
            {
                var existName = await datHumano.AnyExistName(entHumano);
                if (existName.Result)
                {
                    response.SetError(existName.Message);
                    return response;
                }
                response = await datHumano.SaveHumano(entHumano);
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        public async Task<SithecResponse<bool>> BUpdateHumano(EntHumano entHumano)
        {
            SithecResponse<bool> response = new SithecResponse<bool>();
            try
            {
                Guid uIdHumano = (Guid)entHumano.Id;
                var existKey = await datHumano.AnyExistKey(uIdHumano);
                var existName = await datHumano.AnyExistName(entHumano);
                if (!existKey.Result || existName.Result)
                {
                    response.SetError("Dato ya existente, no es posible continuar con la actualizacion");
                    return response;
                }
                var result = await datHumano.UpdateHumano(entHumano);

                if (result.Result)
                {
                    response.SetSuccess(true, result.Message);
                }
                else
                {
                    response.SetError(result.Message);
                }

            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }
        public async Task<SithecResponse<bool>> BDeleteHumano(Guid ikey)
        {
            SithecResponse<bool> response = new SithecResponse<bool>();
            try
            {
                var existKey = await datHumano.AnyExistKey(ikey);
                if (!existKey.Result)
                {
                    response.SetError("No existe registro");
                    return response;
                }
                response = await datHumano.DeleteHumano(ikey);

            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }
            return response;
        }
        public async Task<SithecResponse<List<EntHumano>>> bGetAll()
        {
            SithecResponse<List<EntHumano>> response = new SithecResponse<List<EntHumano>>();
            try
            {
                var result = await datHumano.Get();
                response.SetSuccess(result.Result);
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }
            return response;

        }
        public async Task<SithecResponse<List<EntHumano>>> bGetHumanosMock()
        {
            SithecResponse<List<EntHumano>> response = new SithecResponse<List<EntHumano>>();
            try
            {
                var humanos = new List<EntHumano>
                {

                    new EntHumano { Id = Guid.NewGuid(), Nombre = "Gissel", Sexo = "Mujer", Edad = 25, Altura = 1.60, Peso = 70 },
                    new EntHumano { Id = Guid.NewGuid(), Nombre = "Yolanda", Sexo = "Mujer", Edad = 47, Altura = 160.0, Peso =70 },

                };
                response.SetSuccess(humanos);
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }
            return response;

        }
        public async Task<SithecResponse<EntHumano>> bGetHumanoById(Guid uIdKey)
        {
            SithecResponse<EntHumano> response = new SithecResponse<EntHumano>();
            try
            {
                var result = await datHumano.GetHumanoById(uIdKey);
                response.SetSuccess(result.Result);
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }
            return response;

        }
    }
}
