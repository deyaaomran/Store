using AutoMapper;
using StoreP.Core.Dtos.Baskets;
using StoreP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Core.Mapping.Baskets
{
    public class BasketProfile : Profile
    {
        public BasketProfile( )
        {
            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();

        }
    }
}
