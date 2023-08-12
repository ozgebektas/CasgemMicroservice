using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Dtos.OrderDetailDtos;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Order.Core.Application.Mappings
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Ordering,ResultOrderDetailDto>().ReverseMap();
            CreateMap<Ordering,UpdateOrderDetailDto>().ReverseMap();
            CreateMap<Ordering,CreateOrderDetailDto>().ReverseMap();

        }
    }
}
