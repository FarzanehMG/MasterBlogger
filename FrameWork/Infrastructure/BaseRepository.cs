using System.Linq.Expressions;
using FrameWork.Domain;
using Microsoft.EntityFrameworkCore;

namespace FrameWork.Infrastructure
{
	public class BaseRepository<TKey,T> : IRepository<TKey,T> where T : DomainBase<TKey>
	{
		private readonly DbContext _context;

		public BaseRepository(DbContext context)
		{
			_context = context;
		}

		public List<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public T Get(TKey id)
		{
			return _context.Find<T>(id);
		}

		public void Create(T entity)
		{
			_context.Add<T>(entity);
		}

		public bool Exists(Expression<Func<T, bool>> expression)
		{
			return _context.Set<T>().Any(expression);
		}
	}
}
