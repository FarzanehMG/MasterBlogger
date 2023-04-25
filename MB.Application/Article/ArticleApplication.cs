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
			_articleRepository.Create(article);
			_articleRepository.Save();
		}
	}
}
