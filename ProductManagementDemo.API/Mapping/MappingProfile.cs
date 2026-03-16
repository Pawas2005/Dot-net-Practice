using AutoMapper;
using System.Text.Json;
using ProductManagementDemo.API.DTOs;
using ProductManagementDemo.API.Entities;

namespace ProductManagementDemo.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateProductDto → Product
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.SKU,
                    opt => opt.MapFrom(src => src.Sku))
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => JsonSerializer.Serialize(src.Tags, (JsonSerializerOptions?)null)))
                .ForMember(dest => dest.Specifications,
                    opt => opt.MapFrom(src => JsonSerializer.Serialize(src.Specifications ?? new(), (JsonSerializerOptions?)null)));

            // UpdateProductDto → Product (skip nulls)
            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Tags,
                    opt => opt.PreCondition(src => src.Tags != null))
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => JsonSerializer.Serialize(src.Tags, (JsonSerializerOptions?)null)))
                .ForMember(dest => dest.Specifications,
                    opt => opt.PreCondition(src => src.Specifications != null))
                .ForMember(dest => dest.Specifications,
                    opt => opt.MapFrom(src => JsonSerializer.Serialize(src.Specifications, (JsonSerializerOptions?)null)))
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
