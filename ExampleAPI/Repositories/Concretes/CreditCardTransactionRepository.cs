using ExampleAPI.Contexts;
using ExampleAPI.Core;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;

namespace ExampleAPI.Repositories.Concretes
{
	public class CreditCardTransactionRepository : BaseRepository<CreditCardTransaction>, ICreditCardTransactionRepository
	{
		public CreditCardTransactionRepository(ExampleDbContext context) : base(context)
		{
		}
	}
}
