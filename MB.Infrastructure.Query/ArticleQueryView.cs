﻿namespace MB.Infrastructure.Query
{
	public class ArticleQueryView
	{
		public long Id { get; set; }
		public string AuthoerName { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Image { get; set; }
		public string Content { get; set; }
		public string ArticleCategory { get; set; }
		public string CreationDate { get; set; }
		public bool IsDeleted { get; set; }
		public long ArticleId { get; set; }
		public long CommentCount { get; set; }
		public List<CommentQueryView> CommentQuery { get; set; }
	}
}