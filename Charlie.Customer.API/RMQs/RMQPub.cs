using RabbitMQ.Client;
using System.Text;
using System.Xml.Serialization;
namespace Charlie.Customer.API.RMQs
{
    public class RMQPub
    {
		private IConnection _connection;
		private IChannel _channel;

		public RMQPub(string rabbitMqConnectionString)
		{
			InitializeAsync(rabbitMqConnectionString).GetAwaiter().GetResult();
		}

		private async Task InitializeAsync(string rabbitMqConnectionString)
		{
			var factory = new ConnectionFactory() { Uri = new Uri(rabbitMqConnectionString) };
			_connection = await factory.CreateConnectionAsync();
			_channel = await _connection.CreateChannelAsync();
		}

		public async Task Publish(string exchange, string routingKey, string message)
        {
			var properties = new BasicProperties();
			properties.Persistent = true;
			var body = Encoding.UTF8.GetBytes(message);
			await _channel.BasicPublishAsync(exchange: exchange, routingKey: routingKey, mandatory: true, basicProperties: properties, body: body);
		}

		public void Dispose()
		{
			_channel?.Dispose();
			_connection?.Dispose();
		}
	}
}
