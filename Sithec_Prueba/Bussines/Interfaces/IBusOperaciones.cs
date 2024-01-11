using Entities;
using Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Bussines.Interfaces
{
    public interface IBusOperaciones
    {
        Task<SithecResponse<double>> BRealizarOperacionWithHeader(double Numero1, double Numero2, OperacionEnum operacionEnum);
        Task<SithecResponse<double>> BRealizarOperacion(EntOperacion entOperacion);
    }
}

