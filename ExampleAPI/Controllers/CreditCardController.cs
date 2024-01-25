using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Controllers;

[Route("api/[controller]")]
public class CreditCardsController : Controller
{
	private readonly IUserRepository _userRepository;
	private readonly ICreditCardRepository _creditCardRepository;
	private readonly ICreditCardTransactionRepository _creditCardTransactionRepository;

	public CreditCardsController(
		IUserRepository userRepository,
		ICreditCardRepository creditCardRepository,
		ICreditCardTransactionRepository creditCardTransactionRepository)
	{
		_userRepository = userRepository;
		_creditCardRepository = creditCardRepository;
		_creditCardTransactionRepository = creditCardTransactionRepository;
	}

	[HttpGet("GetAll")]
	public IActionResult GetAll()
	{
		return Ok(_creditCardRepository.GetAll());
	}

	[HttpGet("GetAllWithTransactions")]
	public IActionResult GetAllWithTransactions()
	{
		return Ok(_creditCardRepository.GetAll(include: creditCard => creditCard.Include(c => c.Transactions)));
	}

	[HttpGet("GetById/{id}")]
	public IActionResult Get(Guid id)
	{
		return Ok(_creditCardRepository.Get(creditCard => creditCard.Id == id));
	}

	[HttpPost("Add")]
	public IActionResult Add([FromBody] CreditCard creditCard)
	{
		return Ok(_creditCardRepository.Add(creditCard));
	}

	[HttpPost("AddTransaction")]
	public IActionResult AddTransaction([FromBody] CreditCardTransaction transaction)
	{
		var creditCard = _creditCardRepository.Get(card => card.Id == transaction.CreditCardId);
		if (creditCard == null)
		{
			return BadRequest("CreditCard not found");
		}

		if (transaction.Amount < 0 && Math.Abs(transaction.Amount) > creditCard.Limit - creditCard.CurrentBalance)
		{
			return BadRequest("insufficient balance ");
		}

		var addedTransaction = _creditCardTransactionRepository.Add(transaction);
		creditCard.CurrentBalance += transaction.Amount;
		_creditCardRepository.Update(creditCard);

		return Ok(addedTransaction);
	}

	[HttpPut("Update")]
	public IActionResult Update([FromBody] CreditCard creditCard)
	{
		return Ok(_creditCardRepository.Update(creditCard));
	}

	[HttpDelete("DeleteById/{id}")]
	public IActionResult Delete(Guid id)
	{
		var creditCard = _creditCardRepository.Get(card => card.Id == id);
		if (creditCard == null) return BadRequest("CreditCard not found");
		return Ok(_creditCardRepository.Delete(creditCard));
	}
}