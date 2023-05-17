using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurWebsite {
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<UserNoPWDTO, User>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();


            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductDTO>()
                .ForMember(productDto => productDto.CategoryId,
                opt => opt.MapFrom(product => product.CategoryId));

            //CreateMap<Category, CategoryDTO>();

            //CreateMap<ProductDTO, ProductDTO>()
            //    .ForMember(dest => dest.CategoryName,
            //    opts => opts.MapFrom(src=>src.CategoryName)
            // );

            //CreateMap<Order, OrderDTO>()
            //    .ForMember(dest => dest.UserN,
            //    opts => opts.MapFrom(src => src.User.FirstName));

            //CreateMap<User, UserDTO>();
            //CreateMap<OrderItem, OrderItemDTO>()
            //    .ForMember(dest => dest.ProductName,
            //    opts => opts.MapFrom(src => src.Product.ProductName));

            //CreateMap<OrderItem, OrderItemDTO>();

        }
    }
}
