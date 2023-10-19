using AccountManagementService.Enums;
using AccountManagementService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQServices.Interfaces;

namespace AccountManagementService.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountManagementServiceDbContext _context;
        private readonly IRabitMQProducer _rabitMQProducer;

        public AccountController(AccountManagementServiceDbContext context, IRabitMQProducer rabitMQProducer)
        {
            this._context = context;
            this._rabitMQProducer = rabitMQProducer;
        }

        [HttpPost]
        [Route("createAccount")]
        public ActionResult<Account> CreateOrder([FromBody] Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            if (account.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            _rabitMQProducer.SendMessage(account, "ob_account_create");

            return Ok(account);
        }

        [HttpPost]
        [Route("debit")]
        public ActionResult<AccountBalance> Debit([FromBody] AccountBalance accountBalance)
        {
            accountBalance.BalanceType = BalanceType.Debit;
            _context.AccountBalances.Add(accountBalance);
            _context.SaveChanges();
            if (accountBalance.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            _rabitMQProducer.SendMessage(accountBalance, "ob_account_debit");

            return Ok(accountBalance);
        }

        [HttpPost]
        [Route("credit")]
        public ActionResult<AccountBalance> Credit([FromBody] AccountBalance accountBalance)
        {
            accountBalance.BalanceType = BalanceType.Credit;
            _context.AccountBalances.Add(accountBalance);
            _context.SaveChanges();
            if (accountBalance.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            _rabitMQProducer.SendMessage(accountBalance, "ob_account_credit");

            return Ok(accountBalance);
        }
    }
}
