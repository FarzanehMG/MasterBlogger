using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using MB.Domain.CommentAgg;
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
			return _context.Articles.Include(x=>x.Comments).Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
			{
				Id = x.Id,
				Title = x.Title,
				AuthoerName = x.AuthorName,
				Image = x.Image,
				ShortDescription = x.ShortDescription,
				Content = x.Content,
				ArticleCategory = x.ArticleCategory.Title,
				CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
				IsDeleted = x.IsDeleted,
				CommentCount = x.Comments.Count(z=>z.Status == Statuses.Confirmed)
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
				CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
				CommentCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
				CommentQuery = MapComments(x.Comments.Where(z=>z.Status == Statuses.Confirmed))
			}).FirstOrDefault(x => x.Id == id);
		}

		private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
		{
			return comments.Select(comment => new CommentQueryView
			{
				Name = comment.Name,
				CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
				Message = comment.Message
			}).ToList();
		}
	}
}
