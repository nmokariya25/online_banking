using AuditService.Models;
using AuditService.MQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Controllers
{
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly AuditServiceDbContext _context;
        private readonly IRabitMQProducer _rabitMQProducer;

        public AuditController(AuditServiceDbContext context, IRabitMQProducer rabitMQProducer)
        {
            this._context = context;
            this._rabitMQProducer = rabitMQProducer;
        }

        [HttpPost]
        [Route("logActivity")]
        public ActionResult LogActivity([FromBody] Audit audit)
        {
            _context.Audits.Add(audit);
            _context.SaveChanges();
            if (audit.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            _rabitMQProducer.SendMessage(audit, "ob_transaction_event");

            return Ok(audit);
        }

    }
}
