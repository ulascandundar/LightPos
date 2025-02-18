using LightPos.Core.Entities;
using LightPos.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPos.Infrastructure.Persistence;
public static class SeedService
{
	public static async Task InitializeData(LightPosDbContext _db)
	{
		await SeedUsers(_db);
		await SeedCategories(_db);
		await SeedProducts(_db);
		await SeedProductCategories(_db);
	}

	private static async Task SeedUsers(LightPosDbContext _db)
	{
		var isAdminExist = _db.Users.Any(u => u.UserName == "admin");
		if (!isAdminExist)
		{
			var user = new User
			{
				UserName = "admin",
				PhoneNumber = "123456789",
				PasswordHashed = HashUtility.CalculateSHA256Hash("admin"),
			};
			_db.Users.Add(user);
			await _db.SaveChangesAsync();
		}
	}

	private static async Task SeedProducts(LightPosDbContext _db)
	{
		var isProductsExist = _db.Products.Any();
		if (!isProductsExist)
		{
			var products = new List<Product>
			{
				new Product
				{
					Name = "Product 1",
					Price = 100,
				},
				new Product
				{
					Name = "Product 2",
					Price = 200,
				},
				new Product
				{
					Name = "Product 3",
					Price = 300,
				},
			};
			_db.Products.AddRange(products);
			await _db.SaveChangesAsync();
		}
	}


	private static async Task SeedCategories(LightPosDbContext _db)
	{
		var isCategoriesExist = _db.Categories.Any();
		if (!isCategoriesExist)
		{
			var categories = new List<Category>
			{
				new Category
				{
					Name = "Category 1",
				},
				new Category
				{
					Name = "Category 2",
				},
				new Category
				{
					Name = "Category 3",
				},
			};
			_db.Categories.AddRange(categories);
			await _db.SaveChangesAsync();
		}
	}

	private static async Task SeedProductCategories(LightPosDbContext _db)
	{
		var isProductCategoriesExist = _db.ProductCategories.Any();
		if (!isProductCategoriesExist)
		{
			List<ProductCategory> productCategories = new List<ProductCategory>();
			var products = _db.Products.ToList();
			var categories = _db.Categories.ToList();
			foreach (var product in products)
			{
				foreach (var category in categories)
				{
					ProductCategory productCategory = new ProductCategory
					{
						ProductId = product.Id,
						CategoryId = category.Id,
					};
					productCategories.Add(productCategory);
				}
			}
			_db.ProductCategories.AddRange(productCategories);
			await _db.SaveChangesAsync();
		}
	}
}