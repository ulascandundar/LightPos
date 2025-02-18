using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Core.Application.DTOs;
public class CategoryWithProductDto : CategoryDto
{
	public List<ProductDto> Products { get; set; }
}
