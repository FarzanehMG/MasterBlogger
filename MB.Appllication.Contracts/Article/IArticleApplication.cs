namespace MB.Application.Contracts.Article
{
	public interface IArticleApplication
	{
		List<ArticleViewModel> GetArticles();
		void Create(CreateArticle command);
	}
}
