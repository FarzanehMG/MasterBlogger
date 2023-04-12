using MB.Application.ArticleCategory;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Interface.core
{
	public class Bootstrapper
	{
		public static void Configure(IServiceCollection services, string connectionString)
		{
			services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
			services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

			services.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(connectionString));
		}
	}
}