using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCase;

public class AddProductUseCase : IAddProductUseCase
{
    private IProductRepository productRepository;

    public AddProductUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public void AddProduct(Product product)
    {
        productRepository.AddProduct(product);
    }
}
