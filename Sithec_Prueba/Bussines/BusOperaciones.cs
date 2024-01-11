using Entities.enums;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Bussines.Interfaces;

namespace Bussines
{
    public class BusOperaciones : IBusOperaciones
    {
        private async Task<SithecResponse<double>> BRealizarOperacionMatematica(EntOperacion entOperacion)
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

        public async Task<SithecResponse<double>> BRealizarOperacion(EntOperacion entOperacion)
        {
            SithecResponse<double> response = new SithecResponse<double>();

            try
            {
                var result = await BRealizarOperacionMatematica(entOperacion);
                response.SetSuccess(result.Result);
            }
            catch (Exception ex)
            {
                response.SetError(ex);
            }

            return response;
        }

        public async Task<SithecResponse<double>> BRealizarOperacionWithHeader(double Numero1, double Numero2, OperacionEnum operacionEnum)
        {
            SithecResponse<double> response = new SithecResponse<double>();

            try
            {
                EntOperacion entOperacion = new EntOperacion();
                entOperacion.Numero1 = Numero1;
                entOperacion.Numero2 = Numero2;
                entOperacion.Operacion = operacionEnum;
                var result = await BRealizarOperacionMatematica(entOperacion);
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
