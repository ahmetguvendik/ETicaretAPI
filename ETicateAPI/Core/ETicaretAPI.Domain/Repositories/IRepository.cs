using System;
using System.Collections.Generic;
using ETicateAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Application.Repositories
{
	public interface IRepository<T> where T: BaseEntitiy
    {
		 DbSet<T> Table { get; }
	}
}

