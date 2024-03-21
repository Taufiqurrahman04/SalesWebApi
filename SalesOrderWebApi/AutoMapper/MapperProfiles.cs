using AutoMapper;
using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataModifyViewModels;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;

namespace Net.AutoMapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() 
        {
            CreateMap<Customer, customer>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.address, opt => opt.MapFrom(s => s.Address))
                .ForMember(dest => dest.customer_type, opt => opt.MapFrom(s => s.CustomerType))
                .ForMember(dest => dest.customer_no, opt => opt.MapFrom(s => s.CustomerNo))
                .ForMember(dest => dest.customer_name, opt => opt.MapFrom(s => s.CustomerName))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(s => s.Phone))
                .ReverseMap();

            CreateMap<MarketingArea, marketing_area>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.code, opt => opt.MapFrom(s => s.Code))
                .ForMember(dest => dest.description, opt => opt.MapFrom(s => s.Description))
                .ReverseMap();

            CreateMap<Order, order>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.store_id, opt => opt.MapFrom(s => s.StoreId))
                .ForMember(dest => dest.customer_id, opt => opt.MapFrom(s => s.CustomerId))
                .ForMember(dest => dest.order_date, opt => opt.MapFrom(s => s.OrderDate))
                .ForMember(dest => dest.order_type, opt => opt.MapFrom(s => s.OrderType))
                .ForMember(dest => dest.total_amount, opt => opt.MapFrom(s => s.TotalAmount))
                .ReverseMap();

            CreateMap<Order, CreateOrder>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.store_id, opt => opt.MapFrom(s => s.StoreId))
                .ForMember(dest => dest.customer_id, opt => opt.MapFrom(s => s.CustomerId))
                .ForMember(dest => dest.order_date, opt => opt.MapFrom(s => s.OrderDate))
                .ForMember(dest => dest.order_type, opt => opt.MapFrom(s => s.OrderType))
                .ForMember(dest => dest.total_amount, opt => opt.MapFrom(s => s.TotalAmount))
                .ReverseMap();

            CreateMap<Order, UpdateOrder>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.store_id, opt => opt.MapFrom(s => s.StoreId))
                .ForMember(dest => dest.customer_id, opt => opt.MapFrom(s => s.CustomerId))
                .ForMember(dest => dest.order_date, opt => opt.MapFrom(s => s.OrderDate))
                .ForMember(dest => dest.order_type, opt => opt.MapFrom(s => s.OrderType))
                .ForMember(dest => dest.total_amount, opt => opt.MapFrom(s => s.TotalAmount))
                .ReverseMap();

            CreateMap<base_order, UpdateOrder>()
                .ReverseMap();              
                                            
            CreateMap<base_order, CreateOrder>()
                .ReverseMap();

            CreateMap<OrderItem, order_item>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.order_id, opt => opt.MapFrom(s => s.OrderId))
                .ForMember(dest => dest.product_sparepart_id, opt => opt.MapFrom(s => s.ProductSparepartId))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(dest => dest.total_price, opt => opt.MapFrom(s => s.TotalPrice))
                .ForMember(dest => dest.unit_price, opt => opt.MapFrom(s => s.UnitPrice))
                .ReverseMap();

            CreateMap<order_item, base_order_item>()
                .ReverseMap();

            CreateMap<OrderItem, UpdateOrderItem>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.order_id, opt => opt.MapFrom(s => s.OrderId))
                .ForMember(dest => dest.product_sparepart_id, opt => opt.MapFrom(s => s.ProductSparepartId))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(dest => dest.total_price, opt => opt.MapFrom(s => s.TotalPrice))
                .ForMember(dest => dest.unit_price, opt => opt.MapFrom(s => s.UnitPrice))
                .ReverseMap();

            CreateMap<base_order_item, UpdateOrderItem>()
                .ReverseMap();

            CreateMap<base_order_item, CreateOrderItem>()
                .ReverseMap();

            CreateMap<ProductSparepart, product_sparepart>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.brand, opt => opt.MapFrom(s => s.Brand))
                .ForMember(dest => dest.code, opt => opt.MapFrom(s => s.Code))
                .ForMember(dest => dest.cogs, opt => opt.MapFrom(s => s.COGS))
                .ForMember(dest => dest.description, opt => opt.MapFrom(s => s.Description))
                .ForMember(dest => dest.type, opt => opt.MapFrom(s => s.Type))
                .ForMember(dest => dest.uom, opt => opt.MapFrom(s => s.UOM))
                .ReverseMap();

            CreateMap<Store, store>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dest => dest.address, opt => opt.MapFrom(s => s.Address))
                .ForMember(dest => dest.code, opt => opt.MapFrom(s => s.Code))
                .ForMember(dest => dest.description, opt => opt.MapFrom(s => s.Description))
                .ForMember(dest => dest.marketing_area_id, opt => opt.MapFrom(s => s.MarketingAreaId))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(s => s.Phone))
                .ReverseMap();
        }
    }
}
