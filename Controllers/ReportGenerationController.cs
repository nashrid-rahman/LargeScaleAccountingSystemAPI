using LargeScaleAccountingSystemAPI.Data;
using LargeScaleAccountingSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LargeScaleAccountingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportGenerationController : Controller
    {
        private readonly AccountingSystemDBContext _DBContext;

        public ReportGenerationController(AccountingSystemDBContext accountingSystemDBContext)
        {
            this._DBContext = accountingSystemDBContext;
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTotalExpense([FromRoute] Guid id)
        {
            var account = await _DBContext.GLAccounts.FirstOrDefaultAsync(x => x.Id == id);
            double totalExpense = 0;

            if (account == null)
            {
                return NotFound();
            }

            if (account.DrCr == "D")
            {
                var transactions = _DBContext.Transactions.Where(x =>
                x.AccountNumber == account.AccountNumber
                && x.DrCr == "D"
                );
                totalExpense = transactions.Sum(X => X.Amount);
            }

            else if (account.DrCr == "C")
            {
                var transactions = _DBContext.Transactions.Where(x =>
               x.AccountNumber == account.AccountNumber
               && x.DrCr == "C"
               );
                totalExpense = transactions.Sum(X => X.Amount);

                totalExpense = 0;

            }

            return Ok(totalExpense);
        }



    }
}
