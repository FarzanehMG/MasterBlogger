using FrameWork.Infrastructure;
using MB.Domain.ArticleCategoryAgg;
namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : BaseRepository<long,ArticleCategory>,IArticleCategoryRepository
	{
		private readonly MasterBloggerContext _context;

		public ArticleCategoryRepository(MasterBloggerContext context) : base(context)
		{
			_context = context;
		}
		public void Save()
		{
			_context.SaveChanges();
		}

	}

}