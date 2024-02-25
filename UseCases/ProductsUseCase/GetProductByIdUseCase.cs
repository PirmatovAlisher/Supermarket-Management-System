using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCase;

public class GetProductByIdUseCase : IGetProductByIdUseCase
{
    private readonly IProductRepository productRepository;

    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public Product GetProductById(int productId)
    {
        return productRepository.GetProductById(productId);
    }
}
