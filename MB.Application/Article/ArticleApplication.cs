using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application.Article
{
	public class ArticleApplication :IArticleApplication
	{
		private readonly IArticleRepository _articleRepository;

		public ArticleApplication(IArticleRepository articleRepository)
		{
			_articleRepository = articleRepository;
		}

		public List<ArticleViewModel> GetArticles()
		{
			return _articleRepository.GetArticle();
		}

		public void Create(CreateArticle command)
		{
			var article = new Domain.ArticleAgg.Article(command.Title, command.Image, command.ShortDescription,
				command.Content, command.ArticleCategoryId);
			_articleRepository.CreateAndSave(article);
			_articleRepository.Save();
		}

		public void Edit(EditArticle command)
		{
			var article = _articleRepository.Get(command.Id);
			article.Edit(command.Title,command.Image,command.ShortDescription,command.Content,command.ArticleCategoryId);
			_articleRepository.Save();
		}

		public EditArticle Get(long id)
		{
			var article = _articleRepository.Get(id);
			return new EditArticle
			{
				Id = article.Id,
				Title = article.Title,
				ArticleCategoryId = article.ArticleCategoryId,
				Content = article.Content,
				Image = article.Image,
				ShortDescription = article.ShortDescription
			};
		}

		public void Remove(long id)
		{
			var articleCategory = _articleRepository.Get(id);
			articleCategory.Remove();
			_articleRepository.Save();
		}

		public void Activate(long id)
		{
			var articleCategory = _articleRepository.Get(id);
			articleCategory.Activate();
			_articleRepository.Save();
		}
	}
}
