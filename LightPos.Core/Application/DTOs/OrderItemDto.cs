﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Core.Application.DTOs;
public class OrderItemDto
{
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public string Name { get; set; }
	public string PaymentMethod { get; set; }
}
