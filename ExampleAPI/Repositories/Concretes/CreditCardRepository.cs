using ExampleAPI.Contexts;
using ExampleAPI.Core;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;

namespace ExampleAPI.Repositories.Concretes
{
	public class CreditCardRepository : BaseRepository<CreditCard>, ICreditCardRepository
	{
		public CreditCardRepository(ExampleDbContext context) : base(context)
		{
		}
	}
}
