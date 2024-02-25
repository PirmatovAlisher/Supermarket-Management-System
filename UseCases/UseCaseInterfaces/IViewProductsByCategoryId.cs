using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductsByCategoryId
    {
        IEnumerable<Product> GetProducts(int categoryId);
    }
}