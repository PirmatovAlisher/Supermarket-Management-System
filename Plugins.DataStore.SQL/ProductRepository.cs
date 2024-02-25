using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class ProductRepository : IProductRepository
{
	private readonly MarketContext context;

	public ProductRepository(MarketContext context)
	{
		this.context = context;
	}

	public void AddProduct(Product product)
	{
		context.Products.Add(product);
		context.SaveChanges();
	}

	public void DeleteProduct(int productId)
	{
		var product = GetProductById(productId);
		context.Products.Remove(product);
		context.SaveChanges();
	}

	public void EditProduct(Product product)
	{
		var productToUpdate = context.Products.Find(product.ProductId);
		productToUpdate.CategoryId = product.CategoryId;
		productToUpdate.Name = product.Name;
		productToUpdate.Price = product.Price;
		productToUpdate.Quantity = product.Quantity;
		context.SaveChanges();
	}

	public Product GetProductById(int productId)
	{
		return context.Products.Find(productId);
	}

	public IEnumerable<Product> GetProducts()
	{
		return context.Products.ToList();
	}

	public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
	{
		var products = context.Products.Where(p => p.CategoryId == categoryId);
		return products;
	}
}
