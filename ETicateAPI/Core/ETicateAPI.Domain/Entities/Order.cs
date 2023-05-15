using System;
using ETicateAPI.Domain.Entities.Common;

namespace ETicateAPI.Domain.Entities
{
	public class Order : BaseEntitiy
	{

		public string Description { get; set; }
		public string Adress { get; set; }
		public ICollection<Product> Products { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
	}
}

