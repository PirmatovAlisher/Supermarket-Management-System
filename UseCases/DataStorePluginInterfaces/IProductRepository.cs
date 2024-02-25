using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces;

public interface IProductRepository
{
	void AddProduct(Product product);
	void DeleteProduct(int productId);
	void EditProduct(Product product);
	Product GetProductById(int productId);
	IEnumerable<Product> GetProducts();
	IEnumerable<Product> GetProductsByCategoryId(int categoryId);
}
