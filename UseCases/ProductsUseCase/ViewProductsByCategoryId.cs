using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCase;

public class ViewProductsByCategoryId : IViewProductsByCategoryId
{
    private readonly IProductRepository productRepository;

    public ViewProductsByCategoryId(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public IEnumerable<Product> GetProducts(int categoryId)
    {
        return productRepository.GetProductsByCategoryId(categoryId);
    }
}
