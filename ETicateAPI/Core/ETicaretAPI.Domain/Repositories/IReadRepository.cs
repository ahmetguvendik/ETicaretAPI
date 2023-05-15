using System;
using System.Linq.Expressions;
using ETicateAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : BaseEntitiy
    {
		 IQueryable<T> GetAll();
		 IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
		 Task<T> GetById(int id);

	}
}

