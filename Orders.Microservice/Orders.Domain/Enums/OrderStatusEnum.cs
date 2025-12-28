using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Enums
{
    public enum OrderStatusEnum
    {
        RECEIVED = 1,        // Recebido
        IN_PREPARATION = 2,  // Em preparação
        READY = 3,           // Pronto
        FINALIZED = 4        // Finalizado
    }
}