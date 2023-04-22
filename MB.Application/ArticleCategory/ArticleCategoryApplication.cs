using System.Globalization;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application.ArticleCategory
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
		private readonly IArticleCategoryRepository _articleCategoryRepository;

		public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
		{
			_articleCategoryRepository = articleCategoryRepository;
		}

		public List<ArticleCategoryViewModel> List()
		{
			var articleCategories = _articleCategoryRepository.GetAll();
			var result = new List<ArticleCategoryViewModel>();
			foreach (var articleCategory in articleCategories)
			{
				result.Add(new ArticleCategoryViewModel
				{
					Id = articleCategory.Id,
					Title = articleCategory.Title,
					IsDeleted = articleCategory.IsDeleted,
					CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
				});
			}
			return result;
		}

		public void Create(CreateArticleCategory command)
		{
			var articleCategory = new Domain.ArticleCategoryAgg.ArticleCategory(command.Title);
			_articleCategoryRepository.Add(articleCategory);
		}
    }
}