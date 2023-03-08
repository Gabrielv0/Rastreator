using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Channels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace createApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ConnectionFactory _factory;

        public UserController()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "142.93.173.18",
                UserName = "admin",
                Password = "devintwitter"
            }; 
        }

        // POST api/<PostController>
        [HttpPost]
        public ActionResult Post([FromBody] User post)
        {
            if (post == null)
            {
                return BadRequest();
            }
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            try
            {
                PublicaPost(post, channel);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }



        private void PublicaPost(User post, IModel channel)
        {
            channel.QueueDeclare(queue: "SalvaRastreamento",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = JsonConvert.SerializeObject(post);

            var postBytes = Encoding.UTF8.GetBytes(body);

            channel.BasicPublish(exchange: string.Empty,
                            routingKey: "SalvaRastreamento",
                            basicProperties: null,
                            body: postBytes);
        }

    }
}
