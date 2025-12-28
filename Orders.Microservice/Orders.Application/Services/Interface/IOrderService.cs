using Orders.Application.DTOs;
using Orders.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Services.Interface
{
    public interface IOrderService
    {
        Task<OrderDto?> GetByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<IEnumerable<OrderDto>> GetActiveOrdersAsync();
        Task<IEnumerable<OrderDto>> GetByStatusAsync(OrderStatusEnum status);
        Task<OrderDto> CreateAsync(CreateOrderDto dto);
        Task<OrderDto> UpdateStatusAsync(int id, UpdateOrderStatusDto dto);
        Task<OrderDto> SetPaymentIdAsync(int id, SetPaymentIdDto dto);
        Task<bool> DeleteAsync(int id);
    }
}