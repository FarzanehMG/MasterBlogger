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
			_masterBloggerContext.SaveChanges();
		}

		public List<ArticleCategory> GetAll()
		{
			return _masterBloggerContext.ArticleCategories.OrderByDescending(x=>x.Id).ToList();
		}
	}

}