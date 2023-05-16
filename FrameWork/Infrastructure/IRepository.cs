using System.Linq.Expressions;
using FrameWork.Domain;

namespace FrameWork.Infrastructure
{
	public interface IRepository<in TKey,T> where T :DomainBase<TKey>
	{
		List<T> GetAll();
		T Get(TKey id);
		void Create(T entity);
		bool Exists(Expression<Func<T,bool>> expression);
	}
}
