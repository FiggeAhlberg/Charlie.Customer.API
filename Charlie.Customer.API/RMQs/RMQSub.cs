using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace Charlie.Customer.API.RMQs
{
	//public class RMQSub : BackgroundService
	//{
	//	private readonly ILogger<RMQSub> _logger;
	//	private IConnection _connection;
	//	private IChannel _channel;
	//	private readonly IServiceProvider _serviceProvider;

	//	public RMQSub(ILogger<RMQSub> logger, IServiceProvider serviceProvider)
	//	{
	//		_logger = logger;
	//		_serviceProvider = serviceProvider;
	//		InitializeRabbitMQ();
	//	}

	//	private async Task InitializeRabbitMQ()
	//	{
	//		var factory = new ConnectionFactory() { HostName = "localhost" };
	//		_connection = await factory.CreateConnectionAsync();
	//		_channel = await _connection.CreateChannelAsync();
	//		_channel.QueueDeclareAsync(queue: "customer",
	//								durable: false,
	//								exclusive: false,
	//								autoDelete: false,
	//								arguments: null);
	//	}

	//	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	//	{
	//		while (!stoppingToken.IsCancellationRequested)
	//		{
	//			var consumer = new AsyncEventingBasicConsumer(_channel);
	//			consumer.ReceivedAsync += async (model, ea) =>
	//			{
	//				var body = ea.Body.ToArray();
	//				var message = Encoding.UTF8.GetString(body);

	//				// Bearbeta meddelandet
	//				using (var scope = _serviceProvider.CreateScope())
	//				{
	//					var customerRmqService = scope.ServiceProvider.GetRequiredService<RabbitMqClient>();
	//					await customerRmqService.AddCustomersAsync(message);
	//					await customerRmqService.Get(message);

	//				}
	//			};

	//			_channel.BasicConsumeAsync(queue: "payment.process",
	//				autoAck: true,
	//				consumer: consumer);

	//			return Task.CompletedTask;
	//		}
	//	}
	//}
}
