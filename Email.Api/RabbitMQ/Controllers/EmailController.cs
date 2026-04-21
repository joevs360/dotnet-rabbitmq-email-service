using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Models;
using RabbitMQ.Services.Interfaces;

namespace RabbitMQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailQueueService queueService;

        public EmailController(IEmailQueueService queueService)
        {
            this.queueService = queueService;
        }

        [HttpPost]
        public IActionResult Send([FromBody] EmailRequest email) {
            if (string.IsNullOrEmpty(email.To))
                return BadRequest();

            this.queueService.Publish(email);
            return Ok("Email enviado para fila");
        }
    }
}
