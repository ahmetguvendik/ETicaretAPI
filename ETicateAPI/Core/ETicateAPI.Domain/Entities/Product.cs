using System;
using ETicateAPI.Domain.Entities.Common;

namespace ETicateAPI.Domain.Entities
{
	public class Product : BaseEntitiy
	{
		public string Name { get; set; }
		public int Stock { get; set; }
		public long Price { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}

