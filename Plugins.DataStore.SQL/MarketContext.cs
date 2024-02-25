using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL;

public class MarketContext : DbContext
{
	public MarketContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Transaction> Transactions { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p =>p.Category).HasForeignKey(p => p.CategoryId);


		// Seeding some date
		modelBuilder.Entity<Category>().HasData(
			new Category { CategoryId = 1, Name = "Fruits", Description = "Healthy and juicy fruits" },
			new Category { CategoryId = 2, Name = "Vegetables", Description = "Fresh and rich for vitamins" },
			new Category { CategoryId = 3, Name = "Meet", Description = "Halal and fatty meet" }
			);

		modelBuilder.Entity<Product>().HasData(
			new Product { CategoryId = 1, ProductId = 1, Name = "Banana", Price = 2.59, Quantity = 52 },
			new Product { CategoryId = 1, ProductId = 2, Name = "Apple", Price = 3.25, Quantity = 23 },
			new Product { CategoryId = 1, ProductId = 3, Name = "Orange", Price = 7.99, Quantity = 31 },

			new Product { CategoryId = 2, ProductId = 4, Name = "Tomato", Price = 1.59, Quantity = 12 },
			new Product { CategoryId = 2, ProductId = 5, Name = "Cucumber", Price = 2.25, Quantity = 32 },
			new Product { CategoryId = 2, ProductId = 6, Name = "Garlic", Price = 4.39, Quantity = 45 },

			new Product { CategoryId = 3, ProductId = 7, Name = "Stake", Price = 52.99, Quantity = 35 },
			new Product { CategoryId = 3, ProductId = 8, Name = "Lamb", Price = 43.25, Quantity = 65 },
			new Product { CategoryId = 3, ProductId = 9, Name = "Chicken", Price = 37.99, Quantity = 75 }
			);
	}
}
