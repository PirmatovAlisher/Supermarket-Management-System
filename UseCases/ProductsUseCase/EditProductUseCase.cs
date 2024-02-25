using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCase
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private IProductRepository productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void EditProduct(Product product)
        {
            productRepository.EditProduct(product);
        }
    }
}
