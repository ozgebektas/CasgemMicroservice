using AutoMapper;
using AutoMapper.Configuration;
using CasgemMicroservice.Services.Discount.Dtos;
using CasgemMicroservice.Services.Discount.Models;
using System.Runtime;

namespace CasgemMicroservice.Services.Discount.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<DiscountCoupons, ResultDiscountDto>().ReverseMap();
            CreateMap<DiscountCoupons, UpdateDiscountDto>().ReverseMap();
            CreateMap<DiscountCoupons, CreateDiscountDto>().ReverseMap();
        }
    }
}
