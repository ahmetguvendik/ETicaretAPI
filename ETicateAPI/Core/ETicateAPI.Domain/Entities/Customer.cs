using System;
using ETicateAPI.Domain.Entities.Common;

namespace ETicateAPI.Domain.Entities
{
	public class Customer : BaseEntitiy
	{
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}

