using System;
namespace ETicateAPI.Domain.Entities.Common
{
	public class BaseEntitiy
	{
		public int Id { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime UpdatedTime { get; set; }	
	}
}

//Bu sınıf sayesınde entitiyler için ortak olan proplar burada tutulur ve buradan kalıtım alır.