using MB.Domain.ArticleCategoryAgg;
namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
	{
		private readonly MasterBloggerContext _masterBloggerContext;

		public ArticleCategoryRepository(MasterBloggerContext masterBloggerContext)
		{
			_masterBloggerContext = masterBloggerContext;
		}

		public void Add(ArticleCategory entity)
		{
			_masterBloggerContext.ArticleCategories.Add(entity);
			Save();
		}

		public List<ArticleCategory> GetAll()
		{
			return _masterBloggerContext.ArticleCategories.OrderByDescending(x=>x.Id).ToList();
		}

		public ArticleCategory Get(long id)
		{
			return _masterBloggerContext.ArticleCategories.First(x => x.Id == id);
		}

		public void Save()
		{
			_masterBloggerContext.SaveChanges();
		}

		public bool Exists(string title)
		{
			return _masterBloggerContext.ArticleCategories.Any(x => x.Title == title);
		}
	}

}