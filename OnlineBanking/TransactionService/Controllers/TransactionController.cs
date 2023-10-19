using Microsoft.AspNetCore.Mvc;
using RabbitMQServices.Interfaces;
using TransactionService.Models;

namespace TransactionService.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionServiceDbContext _context;
        private readonly IRabitMQProducer _rabitMQProducer;


        public TransactionController(TransactionServiceDbContext context, IRabitMQProducer rabitMQProducer)
        {
            this._context = context;
            this._rabitMQProducer = rabitMQProducer;
        }

        [HttpPost]
        [Route("initiateTransaction")]
        public ActionResult<Transaction> InitiateTransaction([FromBody] Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            if (transaction.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            _rabitMQProducer.SendMessage(transaction, "ob_initiate_transaction");
            return Ok("Transaction has been initiated successfully..!!");
        }

        [HttpPost]
        [Route("completeTransaction")]
        public ActionResult<Transaction> CompleteTransaction([FromBody] Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            if (transaction.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            _rabitMQProducer.SendMessage(transaction, "ob_complete_transaction");
            return Ok("Transaction has been completed successfully..!!");
        }
    }
}
