using LargeScaleAccountingSystemAPI.Data;
using LargeScaleAccountingSystemAPI.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LargeScaleAccountingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class TransactionManagementController : Controller
    {
        private readonly AccountingSystemDBContext _DBContext;

        public TransactionManagementController(AccountingSystemDBContext accountingSystemDBContext)
        {
            this._DBContext = accountingSystemDBContext;
        }             

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _DBContext.Transactions.ToListAsync();
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionAccount([FromBody] Transaction transaction)
        {
            transaction.Id = Guid.NewGuid();
            await _DBContext.Transactions.AddAsync(transaction);
            await _DBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTransaction([FromRoute] Guid id)
        {
            var transaction = await _DBContext.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPut]
        [Route("{id:Guid}")]// Transaction
        public async Task<IActionResult> UpdateTransaction([FromRoute] Guid id, Transaction updateTransaction)
        {
            var transactions = await _DBContext.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }
            transactions.AccountNumber = updateTransaction.AccountNumber;
            transactions.Amount = updateTransaction.Amount;
            transactions.CurrencyCode = updateTransaction.CurrencyCode;
            transactions.DrCr=updateTransaction.DrCr;         

            await _DBContext.SaveChangesAsync();
            return Ok(transactions);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] Guid id)
        {
            var transaction = await _DBContext.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound(id);
            }
            _DBContext.Transactions.Remove(transaction);
            await _DBContext.SaveChangesAsync();
            return Ok(transaction);
        }







    }
}
