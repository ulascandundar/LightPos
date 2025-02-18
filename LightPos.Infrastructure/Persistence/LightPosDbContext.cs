using LightPos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Infrastructure.Persistence;
public class LightPosDbContext : DbContext
{
	public LightPosDbContext(DbContextOptions<LightPosDbContext> options)
		: base(options)
	{
	}
	public DbSet<User> Users { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<ProductCategory> ProductCategories { get; set; }

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		foreach (var entry in ChangeTracker.Entries<BaseEntity>())
		{
			DateTime utcTime = DateTime.UtcNow;
			switch (entry.State)
			{
				case EntityState.Added:
					entry.Entity.CreatedDate = utcTime;
					break;

				case EntityState.Modified:
					entry.Entity.UpdatedDate = utcTime;
					break;
			}
		}
		return base.SaveChangesAsync(cancellationToken);
	}
}
