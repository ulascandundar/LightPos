using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Core.Entities;
public class OrderItem : BaseEntity
{
	public int Quantity { get; set; }
	public decimal TotalPrice { get; set; }
	public Guid ProductId { get; set; }
	public Product Product { get; set; }
	public Guid OrderId { get; set; }
	public Order Order { get; set; }
}
