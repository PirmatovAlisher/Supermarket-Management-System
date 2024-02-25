using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class RecordTransactionUseCase : IRecordTransactionUseCase
{
	private readonly ITransactionRepository transactionRepository;
	private readonly IProductRepository productRepository;

	public RecordTransactionUseCase(ITransactionRepository transactionRepository, IProductRepository productRepository)
	{
		this.transactionRepository = transactionRepository;
		this.productRepository = productRepository;
	}


	public void Execute(string cashierName, int productId, int qty)
	{
		var product = productRepository.GetProductById(productId);

		transactionRepository.Save(cashierName, productId, product.Name, product.Price, product.Quantity.Value, qty);
	}
}
