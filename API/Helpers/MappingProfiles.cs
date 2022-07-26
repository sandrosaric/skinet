using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDto>()
            .ForMember(dest => dest.ProductBrand,opt => {
                opt.MapFrom(src => src.ProductBrand.Name);
            })
            .ForMember(dest => dest.ProductType,opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(dest => dest.PictureUrl,opt => {
                opt.MapFrom<ProductUrlRespolver>();
            });
            CreateMap<Core.Entities.Identity.Address,AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
           CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s =>  s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s =>  s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s =>  s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl,o => o.MapFrom<OrderItemUrlResolver>());

        }
    }
}