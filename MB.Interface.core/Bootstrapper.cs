﻿using FrameWork.Infrastructure;
using MB.Application.Article;
using MB.Application.ArticleCategory;
using MB.Application.Comment;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Application.Contracts.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repository;
using MB.Infrastructure.Query;
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
			services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

			services.AddTransient<IArticleApplication, ArticleApplication>();
			services.AddTransient<IArticleRepository,ArticleRepository>();
			services.AddTransient<IArticleValidatorService, ArticleValidatorService>();

			services.AddTransient<IArticleQuery, ArticleQuery>();

			services.AddTransient<ICommentApplication,CommentApplication>();
			services.AddTransient<ICommentRepository,CommentRepository>();

			services.AddTransient<IUnitOfWork,UnitOfWorkEf>();

			services.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(connectionString));
		}
	}
}