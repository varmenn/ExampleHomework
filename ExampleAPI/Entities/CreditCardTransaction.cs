using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class CreditCardTransaction : Entity<Guid>
{
	public Guid CreditCardId { get; set; }
	public decimal Amount { get; set; }
	public DateTime TransactionDate { get; set; }

	public virtual CreditCard CreditCard { get; set; }
}