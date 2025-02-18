using AutoMapper;
using LightPos.Core.Application.DTOs;
using LightPos.Core.Application.IServices;
using LightPos.Core.Entities;
using LightPos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Application.Services;
public class SelfService : ISelfService
{
	private readonly LightPosDbContext _db;
	private readonly IMapper _mapper;

	public SelfService(LightPosDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}

	public async Task CreateOrder(CreateOrderDto createOrderDto)
	{
		var productIds = createOrderDto.Items.Select(o => o.ProductId).ToList();
		var products = await _db.Products.Where(o => productIds.Contains(o.Id)).ToListAsync();
		Order order = new Order();
		order.OrderItems = await GenerateOrderItems(createOrderDto.Items, products);
		order.TotalPrice = order.OrderItems.Sum(o => o.TotalPrice);
		await _db.Orders.AddAsync(order);
		await _db.SaveChangesAsync();
	}

	public async Task<List<CategoryWithProductDto>> GetCategories()
	{
		var query = _db.Categories.Where(o=>!o.IsDeleted).Include(o=>o.ProductCategories).ThenInclude(o=>o.Product);
		var datas = await query.ToListAsync();
		var dtos = _mapper.Map<List<CategoryWithProductDto>>(datas);
		return dtos;
	}

	public async Task<List<OrderItem>> GenerateOrderItems(List<OrderItemDto> orderItemDtos, List<Product> products)
	{
		List<OrderItem> orderItems = new List<OrderItem>();
		foreach (var orderItemDto in orderItemDtos)
		{
			var product = products.FirstOrDefault(o => o.Id == orderItemDto.ProductId);
			OrderItem orderItem = new OrderItem();
			orderItem.ProductId = orderItemDto.ProductId;
			orderItem.Quantity = orderItemDto.Quantity;
			orderItem.TotalPrice = product.Price * orderItemDto.Quantity;
			orderItems.Add(orderItem);
		}
		return orderItems;
	}
}
