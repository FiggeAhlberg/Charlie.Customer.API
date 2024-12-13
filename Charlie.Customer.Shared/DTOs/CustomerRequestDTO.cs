using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlie.Customer.Shared.DTOs
{
	public class CustomerRequestDTO
	{
		public string CorrelationId { get; set; }
		public string CustomerName { get; set; }
		public string Details { get; set; }
	}
}
