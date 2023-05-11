using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
	    public ArticleQueryView Article { get; set; }
	    private readonly IArticleQuery _query;

	    public ArticleDetailsModel(IArticleQuery query)
	    {
		    _query = query;
	    }

	    public void OnGet(long id)
	    {
		    Article = _query.GetArticle(id);
	    }
    }
}
