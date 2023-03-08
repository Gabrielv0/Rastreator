using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using SalvaRastreamento;

var factory = new ConnectionFactory()
{
    HostName = "142.93.173.18",
    UserName = "admin",
    Password = "devintwitter"
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "SalvaRastreamento",
                           durable: true,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    User user = JsonConvert.DeserializeObject<User>(message);
    Console.WriteLine($"Recebido com sucesso a encomenda {user.NomeDoProduto}");
    await SalvaRastreio(user);
    
};

channel.BasicConsume(queue: "SalvaRastreamento",
                        autoAck: true,
                        consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

async Task SalvaRastreio(User user)
{
    using var ctx = new SalvaRastreamentoContext();
    var pedido = new User
    {
        NomeDoProduto = user.NomeDoProduto,
        Empresa = user.Empresa,
        CodigoRastreio = user.CodigoRastreio,
        DataDeCompra = user.DataDeCompra,

    };
    ctx.Users.Add(user); 
   await ctx.SaveChangesAsync();
    Console.WriteLine($"O produto {user.NomeDoProduto} foi salvo para rastreio no banco de dados...");
        
    
}