using Microsoft.AspNetCore.Mvc;
using RabbitMQServices.Interfaces;

namespace FraudDetectionService.Controllers
{
    [ApiController]
    public class FraudController : ControllerBase
    {
        private readonly IRabitMQProducer _rabitMQProducer;

        public FraudController(IRabitMQProducer rabitMQProducer)
        {
            this._rabitMQProducer = rabitMQProducer;
        }

        [HttpPost]
        [Route("analyzeTransaction")]
        public ActionResult AnalyzeTransaction()
        {
            var activity = new
            {

            };
            _rabitMQProducer.SendMessage(activity, "ob_suspicious_activity_event");
            return Ok();
        }
    }
}
