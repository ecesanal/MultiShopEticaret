using MultiShop.Order.Application.Features.CQRS.Queries.AddresQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddresResults;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResault;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProductAmount = values.ProductAmount,
                OrderingId = values.OrderingId,
                ProductPrice = values.ProductPrice,
                ProductName = values.ProductName,
                ProductId = values.ProductId,
                ProductTotalPrice = values.ProductTotalPrice
            };
        }
    }
}
