using LightPos.Core.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Core.Application.IServices;
public interface ISelfService
{
	Task<List<CategoryWithProductDto>> GetCategories();
	Task CreateOrder(CreateOrderDto createOrderDto);
}
