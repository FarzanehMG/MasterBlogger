using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application.Comment
{
	public class CommentApplication : ICommentApplication
	{
		private readonly ICommentRepository _comment;

		public CommentApplication(ICommentRepository comment)
		{
			_comment = comment;
		}
	}
}
