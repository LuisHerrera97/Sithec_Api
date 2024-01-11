using Azure.Core;
using Sithec_Prueba.Bussines.Interfaces;
using Sithec_Prueba.Entities;
using Sithec_Prueba.Entities.enums;
using Sithec_Prueba.Utils;

namespace Sithec_Prueba.Bussines
{
    public class BusOperaciones:IBusOperaciones
    {
        public async Task<SithecResponse<double>> BRealizarOperacion(EntOperacion entOperacion)
        {
            SithecResponse<double> response = new SithecResponse<double>();

            try
            {
                double resultado = 0;

                switch (entOperacion.Operacion)
                {
                    case OperacionEnum.Suma:
                        resultado = entOperacion.Numero1 + entOperacion.Numero2;
                        break;
                    case OperacionEnum.Resta:
                        resultado = entOperacion.Numero1 - entOperacion.Numero2;
                        break;
                    case OperacionEnum.Multiplicacion:
                        resultado = entOperacion.Numero1 * entOperacion.Numero2;
                        break;
                    case OperacionEnum.Division:
                        resultado = entOperacion.Numero1 / entOperacion.Numero2;
                        break;
                }

                response.SetSuccess(resultado);
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }
    }
}
