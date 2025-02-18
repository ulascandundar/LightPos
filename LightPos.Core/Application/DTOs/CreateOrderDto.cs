using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Core.Application.DTOs;
public class CreateOrderDto
{
	public List<OrderItemDto> Items { get; set; }
}
