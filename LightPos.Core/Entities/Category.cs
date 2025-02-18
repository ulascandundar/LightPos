using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Core.Entities;
public class Category : BaseEntity
{
	public string Name { get; set; }
	public List<ProductCategory> ProductCategories { get; set; }
}
