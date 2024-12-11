
using Charlie.Customer.Shared.DTOs;
using System.Text.Json;

namespace Charlie.Customer.API
{
	public class CustomerResponseListener : BackgroundService
	{
		private readonly RabbitMqClient _rabbitMqClient;
		private readonly ILogger<CustomerResponseListener> _logger;

		public CustomerResponseListener(RabbitMqClient rabbitMqClient, ILogger<CustomerResponseListener> logger)
		{
			_rabbitMqClient = rabbitMqClient;
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			await _rabbitMqClient.SubscribeAsync("customer.responses", async message =>
			{
				try
				{
					var response = JsonSerializer.Deserialize<CustomerResponseDTO>(message);

					if (response != null)
					{
						_logger.LogInformation($"Recieved response for CorrelationId: {response.CorrelationId}, Status: {response.Status}");
					}
				}
				catch (Exception ex)
				{
					_logger.LogError($"Error processing message: {ex.Message}");
				}
			}, stoppingToken);
		}
	}
}
