using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;

public class ProductInMemoryRepository : IProductRepository
{
	private List<Product> products;

	public ProductInMemoryRepository()
	{
		// Populate with some Initial Values;

		products = new List<Product>()
		{
			new() {CategoryId = 1 , ProductId = 1, Name ="Banana", Price = 2.59, Quantity = 52},
			new() {CategoryId = 1 , ProductId = 2, Name ="Apple", Price = 3.25, Quantity = 23},
			new() {CategoryId = 1 , ProductId = 3, Name ="Orange", Price = 7.99, Quantity = 31},

			new() {CategoryId = 2 , ProductId = 4, Name ="Tomato", Price = 1.59, Quantity = 12},
			new() {CategoryId = 2 , ProductId = 5, Name ="Cucumber", Price = 2.25, Quantity = 32},
			new() {CategoryId = 2 , ProductId = 6, Name ="Garlic", Price = 4.39, Quantity = 45},

			new() {CategoryId = 3 , ProductId = 7, Name ="Stake", Price = 52.99, Quantity = 35},
			new() {CategoryId = 3 , ProductId = 8, Name ="Lamb", Price = 43.25, Quantity = 65},
			new() {CategoryId = 3 , ProductId = 9, Name ="Chicken", Price = 37.99, Quantity = 75},
		};
	}

	public void AddProduct(Product product)
	{
		//if (products.Contains(product)) return;
		if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

		if (products != null && products.Count > 0)
		{
			var maxId = products.Max(x => x.ProductId);
			product.ProductId = maxId + 1;
		}
		else
		{
			product.ProductId = 1;
		}

		products!.Add(product);
	}

	public Product GetProductById(int productId)
	{
		var product = products.FirstOrDefault(x => x.ProductId == productId);
		return product ?? new Product();
	}


	public void EditProduct(Product product)
	{
		var productToUpdate = GetProductById(product.ProductId);
		if (productToUpdate != null)
		{
			productToUpdate.Name = product.Name;
			productToUpdate.Price = product.Price;
			productToUpdate.Quantity = product.Quantity;
			productToUpdate.CategoryId = product.CategoryId;
		}
	}

	public IEnumerable<Product> GetProducts()
	{
		return products;
	}

	public void DeleteProduct(int productId)
	{
		var product = GetProductById(productId);
		if (product != null)
		{
			products.Remove(product);
		}
	}

	public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
	{
		var productsByCategory = products.Where(x => x.CategoryId == categoryId);

		return productsByCategory;
	}
}
