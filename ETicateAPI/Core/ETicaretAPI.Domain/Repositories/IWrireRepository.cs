using System;
using ETicateAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
	public interface IWrireRepository<T> : IRepository<T> where T : BaseEntitiy
    {
		 Task<bool> AddAsync(T model);
		 Task<bool> AddAsync(List<T> model);
		 bool Remove(T model);
		 Task<bool> RemoveAsync(int id);
		 bool Update(T model);
		Task<int> SaveAsync();
		

	}
}

