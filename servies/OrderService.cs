
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> CreateNewOrder(Order order)
        {
            return await _orderRepository.CreateNewOrder(order);
        }
    }
}

