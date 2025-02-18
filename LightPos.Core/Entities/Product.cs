using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Core.Entities;
public class Product : BaseEntity
{
	public string Name { get; set; }
	public decimal Price { get; set; }
	public List<OrderItem> OrderItems { get; set; }
	public List<ProductCategory> ProductCategories { get; set; }
}
