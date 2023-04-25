using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
	public interface IArticleRepository
	{
		List<ArticleViewModel> GetArticle();
		void Create(Article entity);
		void Save();
	}
}
