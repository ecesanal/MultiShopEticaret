using MultiShop.Order.Application.CQRS.Features.Queries.AddresQueries;
using MultiShop.Order.Application.CQRS.Features.Results.AddresResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.CQRS.Features.Handlers.AddresHandlers
{
    public class GetAdressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAdressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId
            };
        }
    }
}
