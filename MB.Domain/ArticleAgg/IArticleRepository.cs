using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
	public interface IArticleRepository
	{
		List<ArticleViewModel> GetArticle();
		void CreateAndSave(Article entity);
		void Save();
		Article Get(long id);
		bool Exists(string title);
	}
}
