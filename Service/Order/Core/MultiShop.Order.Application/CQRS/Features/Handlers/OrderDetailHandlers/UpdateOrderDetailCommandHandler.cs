using MultiShop.Order.Application.CQRS.Features.Commands.AddresCommands;
using MultiShop.Order.Application.CQRS.Features.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.CQRS.Features.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.OrderingId = command.OrderingId;
            values.ProductId = command.ProductId;
            values.ProductPrice = command.ProductPrice;
            values.ProductName = command.ProductName;
            values.ProductAmount = command.ProductAmount;
            values.ProductTotalPrice = command.ProductTotalPrice;
            await _repository.UpdateAsync(values);
        }
    }
}
