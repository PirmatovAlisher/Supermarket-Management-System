using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
namespace Plugins.DataStore.InMemory;

public class TransactionInMemoryRepository : ITransactionRepository
{
	private List<Transaction> transactions;

	public TransactionInMemoryRepository()
	{
		transactions = new List<Transaction>();
	}

	public IEnumerable<Transaction> Get(string cashierName)
	{
		if (string.IsNullOrWhiteSpace(cashierName))
		{
			return transactions;
		}
		else
		{
			return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
		}
	}

	public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
	{
		if (string.IsNullOrWhiteSpace(cashierName))
		{
			return transactions.Where(x => x.TimeShtamp.Date == date.Date);
		}
		else
		{
			return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
			x.TimeShtamp.Date == date.Date);
		}
	}

	public void Save(string cashierName, int productId, string productName, double? price, int beforeQty, int soldQty)
	{
		int transactionId = 0;

		if (transactions != null && transactions.Count > 0)
		{
			int maxId = transactions.Max(x => x.TransactionId);
			transactionId = maxId + 1;
		}
		else
		{
			transactionId = 1;
		}
		transactions.Add(new Transaction()
		{
			TransactionId = transactionId,
			ProductId = productId,
			ProductName = productName,
			TimeShtamp = DateTime.Now,
			Price = price.Value,
			BeforeQuantity = beforeQty,
			SoldQuantity = soldQty,
			CashierName = cashierName

		});
	}

	public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
	{
		if (string.IsNullOrWhiteSpace(cashierName))
		{
			return transactions.Where(x => x.TimeShtamp.Date >= startDate.Date && x.TimeShtamp.Date <= endDate.Date.AddDays(1).Date);
		}
		else
		{
			return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
									  x.TimeShtamp.Date >= startDate.Date && x.TimeShtamp.Date <= endDate.Date.AddDays(1).Date);
		}
	}
}
