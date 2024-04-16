using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Results.OrderingResults
{
	public class GetOrderingQueryResult
	{
		public int OrderingID { get; set; }
		public string UserId { get; set; }
		public decimal TotalPRice { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
