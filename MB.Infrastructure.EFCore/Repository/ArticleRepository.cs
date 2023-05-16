using System.Globalization;
using FrameWork.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
	public class ArticleRepository : BaseRepository<long,Article>,IArticleRepository
	{
		private readonly MasterBloggerContext _context;

		public ArticleRepository(MasterBloggerContext context) : base(context)
		{
			_context = context;
		}

		public List<ArticleViewModel> GetList()
		{
			return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
			{
				Id = x.Id,
				Title = x.Title,
				ArticleCategory = x.ArticleCategory.Title,
				CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
				IsDeleted = x.IsDeleted,
				authorName = x.AuthorName
			}).ToList();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

	}
}
