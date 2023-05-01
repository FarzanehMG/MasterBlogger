using MB.Domain.ArticleCategoryAgg;
using System.ComponentModel.DataAnnotations;

namespace MB.Domain.ArticleAgg
{
	public class Article
	{
		public long Id { get; private set; }
		public string Title { get; private set; }
		public string AuthorName { get; private set; }
		public string Image { get; private set; }
		public string ShortDescription { get; private set; }
		public string Content { get; private set; }
		public bool IsDeleted { get; private set; }
		public DateTime CreationDate { get; private set; }
		public long ArticleCategoryId { get; private set; }
		public ArticleCategory ArticleCategory { get; private set; }

		protected Article()
		{
		}

		public Article(string title, string image, string shortDescription, string content, long articleCategoryId, string authorName)
		{
			validate(title, articleCategoryId);
			Title = title;
			Image = image;
			ShortDescription = shortDescription;
			Content = content;
			ArticleCategoryId = articleCategoryId;
			AuthorName = authorName;
			IsDeleted = false;
			CreationDate = DateTime.Now;
		}

		private static void validate(string title, long articleCategoryId)
		{
			if (string.IsNullOrWhiteSpace(title))
			{
				throw new ArgumentNullException();
			}

			if (articleCategoryId == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
		}

		public void Edit(string title, string image, string shortDescription, string content, long articleCategoryId, string authorName)
		{
			validate(title, articleCategoryId);
			Title = title;
			Image = image;
			ShortDescription = shortDescription;
			Content = content;
			ArticleCategoryId = articleCategoryId;
			AuthorName = authorName;
		}
		public void Remove()
		{
			IsDeleted = true;
		}

		public void Activate()
		{
			IsDeleted = false;
		}
	}
}
