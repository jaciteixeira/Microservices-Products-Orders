using Orders.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Services.Interface
{
    public interface IPaymentService
    {
        Task<PaymentWebhookResponseDto> ProcessWebhookAsync(PaymentWebhookDto webhookDto);
    }
}