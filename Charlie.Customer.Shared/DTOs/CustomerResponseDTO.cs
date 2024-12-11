using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlie.Customer.Shared.DTOs
{
	public class CustomerResponseDTO
	{
		public string CorrelationId { get; set; }
		public string Status { get; set; }
		public string Message { get; set; }
	}
}
