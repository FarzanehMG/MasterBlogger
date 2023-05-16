using FrameWork.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application.Article
{
	public class ArticleApplication :IArticleApplication
	{
		private readonly IArticleRepository _articleRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
		{
			_articleRepository = articleRepository;
			_unitOfWork = unitOfWork;
		}

		public List<ArticleViewModel> GetArticles()
		{
			return _articleRepository.GetList();
		}

		public void Create(CreateArticle command)
		{
			_unitOfWork.BeginTran();
			var article = new Domain.ArticleAgg.Article(command.Title, command.Image, command.ShortDescription,
				command.Content, command.ArticleCategoryId,command.authorName);
			_articleRepository.Create(article);
			_unitOfWork.CommitTran();
		}

		public void Edit(EditArticle command)
		{
			_unitOfWork.BeginTran();
			var article = _articleRepository.Get(command.Id);
			article.Edit(command.Title,command.Image,command.ShortDescription,command.Content,command.ArticleCategoryId,command.authorName);
			_unitOfWork.CommitTran();
		}

		public EditArticle Get(long id)
		{
			var article = _articleRepository.Get(id);
			return new EditArticle
			{
				Id = article.Id,
				Title = article.Title,
				ArticleCategoryId = article.ArticleCategoryId,
				Content = article.Content,
				Image = article.Image,
				ShortDescription = article.ShortDescription,
				authorName = article.AuthorName
			};
		}

		public void Remove(long id)
		{
			_unitOfWork.BeginTran();
			var articleCategory = _articleRepository.Get(id);
			articleCategory.Remove();
			_unitOfWork.CommitTran();
		}

		public void Activate(long id)
		{
			_unitOfWork.BeginTran();
			var articleCategory = _articleRepository.Get(id);
			articleCategory.Activate();
			_unitOfWork.CommitTran();
		}
	}
}
