using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.DTOs
{
    public record PaymentWebhookDto(
        string Status,      // "PAID", "REFUSED", "CANCELLED"
        string OrderId,     // ID do pedido (pode ser GUID ou int)
        string PaymentId    // ID do pagamento
    );
}