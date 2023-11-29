using AutoMapper;
using DTO;
using Entities;

namespace project

{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<UserLosinDto, User >();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<Category, CtegoryDto>();
        }


    }
}

