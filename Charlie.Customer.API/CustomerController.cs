using Charlie.Customer.API.RMQs;
using Charlie.Customer.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Charlie.Customer.API
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly RabbitMqClient _rabbitMqClient;

		public CustomerController(RabbitMqClient rabbitMqClient)
		{
			_rabbitMqClient = rabbitMqClient;
		}

		[HttpGet("{customerId}")]
		public async Task<IActionResult> GetCustomerByIdAsync(int customerId)
		{
			if (customerId == null)
			{
				return BadRequest("Customer Id is null");
			}
			var correlationId = Guid.NewGuid().ToString();
			var message = new
			{
				CorrelationId = correlationId,
				Operation = "Read",
				Payload = new { CustomerId = customerId }
			};
			await _rabbitMqClient.PublishAsync("customer.operations", message);
			return Accepted(new { Message = "Customer retrieval started.", CorrelationId = correlationId });
		}

	
		[HttpPost]
		public async Task<IActionResult> AddCustomerAsync([FromBody] CustomerDTO customerDTO)
		{
			if (customerDTO == null)
			{
				return BadRequest("Customer is null");
			}

			var correlationId = Guid.NewGuid().ToString();

			var message = new
			{
				CorrelationId = correlationId,
				Operation = "Create",
				Payload = customerDTO
			};

			
			await _rabbitMqClient.PublishAsync("customer.operations", message);
			return Accepted(new { Message = "Customer creation started.", CorrelationId = correlationId });
		}


		//[HttpPut]
		//public async Task<IActionResult> UpdateCustomer(Customer customer)
		//{
		//	if (customer == null)
		//	{
		//		return BadRequest("Customer is null");
		//	}

		//	try
		//	{
		//		_customerService.UpdateAsync(customer);

		//		return Ok($"Customer with ID {customer.Id} updated successfully.");

		//	}
		//	catch (Exception ex)
		//	{
		//		return StatusCode(500, $"Internal server error: {ex.Message}");
		//	}
		//}
		//[HttpGet]
		//public async Task<IActionResult> GetAllCustomers()
		//{
		//	try
		//	{
		//		var result = await _customerService.GetAllAsync();
		//		return Ok(result);
		//	}
		//	catch (Exception ex)
		//	{
		//		return StatusCode(500, $"Internal server error: {ex.Message}");
		//	}

		//}
	}
}
