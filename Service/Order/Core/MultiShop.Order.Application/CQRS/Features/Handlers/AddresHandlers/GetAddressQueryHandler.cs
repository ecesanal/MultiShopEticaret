﻿using MultiShop.Order.Application.CQRS.Features.Results.AddresResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.CQRS.Features.Handlers.AddresHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository ;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressByIdQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressByIdQueryResult{
                AddressId = x.AddressId,
                City = x.City,
                Detail= x.Detail,
                District = x.District,
                UserId= x.UserId
            }).ToList();
        }
    }
}
