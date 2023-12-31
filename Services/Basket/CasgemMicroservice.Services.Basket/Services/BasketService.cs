﻿using CasgemMicroservice.Services.Basket.Dtos;
using CasgemMicroservice.Shared.Dtos;
using System.Text.Json;

namespace CasgemMicroservice.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> DeleteBasket(string UserID)
        {
            var status=await _redisService.GetDb().KeyDeleteAsync(UserID);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepet Bulunamadı", 404);
        }

        public async Task<Response<BasketDto>> GetBasket(string UserID)
        {
            var existBasket=await _redisService.GetDb().StringGetAsync(UserID);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("sepet bulunamadı", 404);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket),200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketdto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketdto.UserID, JsonSerializer.Serialize(basketdto));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepete Güncelleme veya Ekleme Yapılamadı", 500);
        }

    }
}
