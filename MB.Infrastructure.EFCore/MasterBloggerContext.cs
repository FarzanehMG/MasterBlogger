using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore
{
	public class MasterBloggerContext : DbContext
	{
		public DbSet<ArticleCategory> ArticleCategories { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public MasterBloggerContext(DbContextOptions options) : base(options)
		{
		}

		protected MasterBloggerContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var assembly = typeof(ArticleMapping).Assembly;
			modelBuilder.ApplyConfigurationsFromAssembly(assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
