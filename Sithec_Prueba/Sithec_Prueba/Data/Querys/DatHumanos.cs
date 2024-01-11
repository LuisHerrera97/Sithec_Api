using Microsoft.EntityFrameworkCore;
using Sithec_Prueba.Data.Interfaces;
using Sithec_Prueba.Entities;
using Sithec_Prueba.Utils;

namespace Sithec_Prueba.Data.Querys
{
    public class DatHumanos: IDatHumano
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DatHumanos> _logger;

        public DatHumanos(ApplicationDbContext _context, ILogger<DatHumanos> _logger)
        {
            this._context = _context;
            this._logger = _logger;
        }

        public async Task<SithecResponse<bool>> SaveHumano(EntHumano entHumano)
        {
            SithecResponse<bool> response = new SithecResponse<bool>();
            try
            {
                entHumano.Id = Guid.NewGuid();
                _context.Humano.Add(entHumano);
                var exec = await _context.SaveChangesAsync();
                if (exec > 0)
                {
                    response.SetSuccess(true, "Agregado correctamente");
                }
                else
                {
                    response.SetError("Registro no agregado");
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                _logger.LogError("Error al insertar en DatHumanos.SaveHumano --" + ex.ToString());
            }
            return response;
        }

        public async Task<SithecResponse<bool>> UpdateHumano(EntHumano entHumano)
        {
            SithecResponse<bool> response = new SithecResponse<bool>();
            try
            {
                _context.Attach(entHumano);
                _context.Entry(entHumano).Property(x => x.Nombre).IsModified = true;
                _context.Entry(entHumano).Property(x => x.Sexo).IsModified = true;
                _context.Entry(entHumano).Property(x => x.Edad).IsModified = true;
                _context.Entry(entHumano).Property(x => x.Altura).IsModified = true;
                _context.Entry(entHumano).Property(x => x.Peso).IsModified = true;
                var exec = await _context.SaveChangesAsync();
                if (exec > 0)
                {
                    response.SetSuccess(true, "Actualizado correctamente");
                }
                else
                {
                    response.SetError("Registro no actualizado");
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                _logger.LogError("Error al actualizar en DatHumanos.UpdateHumano --" + ex.ToString());
            }
            return response;
        }
        public async Task<SithecResponse<bool>> DeleteHumano(Guid iKey)
        {
            SithecResponse<bool> response = new SithecResponse<bool>();
            try
            {
                var exec = await _context.Humano.Where(x => x.Id == iKey).ExecuteDeleteAsync();
                if (exec > 0)
                {
                    response.SetSuccess(true, "Eliminado correctamente");
                }
                else
                {
                    response.SetError("Registro no eliminado");
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                _logger.LogError("Error al eliminar en DatHumanos.DeleteHumano --" + ex.ToString());
            }
            return response;
        }
        public async Task<SithecResponse<bool>> AnyExistKey(Guid uidKey)
        {
            SithecResponse<bool> response = new SithecResponse<bool>();
            try
            {
                var existKey = await _context.Humano.AsNoTracking().AsQueryable().AnyAsync(i => i.Id == uidKey);

                response.SetSuccess(existKey, existKey ? "Existe registro con los mismos datos" : "No existe registro");
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                _logger.LogError("Error  en DatHumanos.AnyExistKey --" + ex.ToString());
            }
            return response;
        }
        public async Task<SithecResponse<bool>> AnyExistName(EntHumano entHumano)
        {
            SithecResponse<bool> response = new SithecResponse<bool>();
            try
            {
                var exist = await _context.Humano.AsNoTracking().AsQueryable().AnyAsync(i => i.Nombre==entHumano.Nombre);

                response.SetSuccess(exist, exist ? "Registro ya existente" : "No existe registro");
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                _logger.LogError("Error  en DatHumanos.AnyExistName --" + ex.ToString());
            }
            return response;
        }
        public async Task<SithecResponse<List<EntHumano>>> Get()
        {
            SithecResponse<List<EntHumano>> response = new SithecResponse<List<EntHumano>>();

            try
            {
                var result = await _context.Humano.AsNoTracking().AsQueryable().OrderByDescending(i => i.Nombre).ToListAsync();
                if (result.Count > 0)
                {
                    response.SetSuccess(result);
                }
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                _logger.LogError("Error  en DatHumanos.Get --" + ex.ToString());
            }

            return response;
        }
        public async Task<SithecResponse<EntHumano>> GetHumanoById(Guid uIdKey)
        {
            SithecResponse<EntHumano> response = new SithecResponse<EntHumano>();
            try
            {
                var result = await _context.Humano.AsNoTracking().FirstOrDefaultAsync(i => i.Id == uIdKey);

                EntHumano entHumanoMap = new EntHumano();
                entHumanoMap.Id = result.Id;
                entHumanoMap.Nombre = result.Nombre;
                entHumanoMap.Sexo = result.Sexo;
                entHumanoMap.Edad = result.Edad;
                entHumanoMap.Altura = result.Altura;
                entHumanoMap.Peso = result.Peso;

                response.SetSuccess(entHumanoMap);
                
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                _logger.LogError("Error  en DatHumanos.GetHumanoById --" + ex.ToString());
            }

            return response;

        }
    }
}
