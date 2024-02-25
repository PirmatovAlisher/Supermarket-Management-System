using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class TransactionRepository : ITransactionRepository
{
	private readonly MarketContext context;

	public TransactionRepository(MarketContext context)
	{
		this.context = context;
	}

	public IEnumerable<Transaction> Get(string cashierName)
	{
		return context.Transactions.Where(t => t.CashierName == cashierName).ToList();
	}

	public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
	{
		if (string.IsNullOrWhiteSpace(cashierName))
		{
			return context.Transactions.Where(x => x.TimeShtamp.Date == date.Date);
		}
		else
		{
			return context.Transactions.Where(x => x.CashierName.ToLower() == cashierName.ToLower() &&
											  x.TimeShtamp.Date == date.Date);
		}

		//return context.Transactions.Where(t => t.CashierName == cashierName && t.TimeShtamp.Date == date.Date).ToList();
	}

	public void Save(string cashierName, int productId, string productName, double? price, int beforeQty, int soldQty)
	{
		var transaction = new Transaction()
		{
			ProductId = productId,
			ProductName = productName,
			TimeShtamp = DateTime.Now,
			Price = price.Value,
			BeforeQuantity = beforeQty,
			SoldQuantity = soldQty,
			CashierName = cashierName,

		};

		context.Transactions.Add(transaction);
		context.SaveChanges();
	}

	public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
	{
		if (string.IsNullOrWhiteSpace(cashierName))
		{
			return context.Transactions.Where(x => x.TimeShtamp.Date >= startDate.Date && x.TimeShtamp.Date <= endDate.Date.AddDays(1).Date);
		}
		else
		{
			return context.Transactions.Where(x => x.CashierName.ToLower() == cashierName.ToLower() &&
									  x.TimeShtamp.Date >= startDate.Date && x.TimeShtamp.Date <= endDate.Date.AddDays(1).Date);
		}
	}
}
