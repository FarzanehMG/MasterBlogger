using System.Globalization;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
	public class CommentRepository : ICommentRepository
	{
		private readonly MasterBloggerContext _context;

		public CommentRepository(MasterBloggerContext context)
		{
			_context = context;
		}

		public void CreateAndSave(Comment entity)
		{
			_context.Comments.Add(entity);
			Save();
		}

		public List<CommentViewModel> GetList()
		{
			return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
			{
				Id = x.Id,
				Name = x.Name,
				Email = x.Email,
				Message = x.Message,
				Status = x.Status,
				CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
				Article = x.Article.Title
			}).ToList();
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public Comment Get(long id)
		{
			return _context.Comments.FirstOrDefault(x => x.Id == id);

		}
	}
}
