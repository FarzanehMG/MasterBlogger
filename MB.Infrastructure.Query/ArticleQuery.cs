using System.Globalization;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
	public class ArticleQuery : IArticleQuery
	{
		private readonly MasterBloggerContext _context;

		public ArticleQuery(MasterBloggerContext context)
		{
			_context = context;
		}

		public List<ArticleQueryView> GetArticles()
		{
			return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
			{
				Id = x.Id,
				Title = x.Title,
				AuthoerName = x.AuthorName,
				Image = x.Image,
				ShortDescription = x.ShortDescription,
				Content = x.Content,
				ArticleCategory = x.ArticleCategory.Title,
				CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
			}).ToList();
		}

		public ArticleQueryView GetArticle(long id)
		{
			return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
			{
				Id = x.Id,
				Title = x.Title,
				ArticleCategory = x.ArticleCategory.Title,
				AuthoerName = x.AuthorName,
				Image = x.Image,
				ShortDescription = x.ShortDescription,
				Content = x.Content,
				CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
			}).FirstOrDefault(x => x.Id == id);
		}
	}
}
