using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces;

public interface ITransactionRepository
{
	void Save(string cashierName, int productId, string productName, double? price,int beforeQty, int soldQty);
	IEnumerable<Transaction> GetByDay(string cashierName, DateTime date);
	IEnumerable<Transaction> Get(string cashierName);
	IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
}
