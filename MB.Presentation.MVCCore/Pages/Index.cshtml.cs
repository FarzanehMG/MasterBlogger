using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
	public class IndexModel : PageModel
	{
		public List<ArticleQueryView> ArticleQueryViews { get; set; }
		private readonly IArticleQuery _query;
		public IndexModel(IArticleQuery query)
		{
			_query = query;
		}
		public void OnGet()
		{
			ArticleQueryViews = _query.GetArticles();
		}
	}
}