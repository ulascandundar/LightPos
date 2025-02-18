using AutoMapper;
using LightPos.Core.Application.DTOs;
using LightPos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Infrastructure.Mapping.Profiles;
public class ProductCategoryProfile : Profile
{
	public ProductCategoryProfile()
	{
		CreateMap<Product, ProductDto>();
		CreateMap<Category, CategoryDto>();
		CreateMap<Category, CategoryWithProductDto>()
				.ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Product)));
	}
}
