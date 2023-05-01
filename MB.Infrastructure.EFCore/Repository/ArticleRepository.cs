using System.Globalization;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
	public class ArticleRepository : IArticleRepository
	{
		private readonly MasterBloggerContext _context;

		public ArticleRepository(MasterBloggerContext context)
		{
			_context = context;
		}


		public List<ArticleViewModel> GetArticle()
		{
			return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
			{
				Id = x.Id,
				Title = x.Title,
				ArticleCategory = x.ArticleCategory.Title,
				CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
				IsDeleted = x.IsDeleted
			}).ToList();
		}

		public void CreateAndSave(Article entity)
		{
			_context.Articles.Add(entity);
			Save();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public Article Get(long id)
		{
			return _context.Articles.FirstOrDefault(x => x.Id == id);
		}

		public bool Exists(string title)
		{
			return _context.ArticleCategories.Any(x => x.Title == title);
		}
	}
}
