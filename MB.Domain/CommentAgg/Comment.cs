using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
	public class Comment
	{
		public long Id { get; private set; }
		public string Name { get; private set; }
		public string Email { get; private set; }
		public string Message { get; private set; }
		public int Status { get; private set; }
		public DateTime CreationDate { get; private set; }
		public long ArticleId { get; private set; }
		public Article Article { get; private set; }

		public Comment(string name, string email, string message, long articleId)
		{
			Name = name;
			Email = email;
			Message = message;
			CreationDate = DateTime.Now;
			ArticleId = articleId;
			Status = 0;
		}
		protected Comment(){}

		public static class Statuses
		{
			public const int New = 0;
			public const int Confirmed = 1;
			public const int Canceled = 2;
		}
	}
}
