using ExampleAPI.Core;
using System.ComponentModel.DataAnnotations;

namespace ExampleAPI.Entities;

public class CreditCard : Entity<Guid>
{
	[MaxLength(16)]
	public required string CardNumber { get; set; }

	public decimal Limit { get; set; }
	public decimal CurrentBalance { get; set; }

	public virtual ICollection<CreditCardTransaction> Transactions { get; set; }

	public CreditCard()
	{
		Transactions = new HashSet<CreditCardTransaction>();
	}
}

