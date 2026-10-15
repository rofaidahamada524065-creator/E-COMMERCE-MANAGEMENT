using System.Drawing;
using AutoMapper;
using E_COMMERCE_MANAGEMENT.DTOs.Catigory;
using E_COMMERCE_MANAGEMENT.DTOs.Order;
using E_COMMERCE_MANAGEMENT.DTOs.Product;
using E_COMMERCE_MANAGEMENT.Model;

namespace E_COMMERCE_MANAGEMENT.Mapping
{
    public class AllProfail: Profile
    {
        public AllProfail()
        {
            CreateMap<Category,categoryDTO>().ReverseMap();
            CreateMap<Category,CreateUpdateCatigory>().ReverseMap();

            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Product,CreateUpdatePruduct>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();


        }
    }
}
