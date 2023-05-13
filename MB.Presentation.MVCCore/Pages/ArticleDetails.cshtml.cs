using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
	    public ArticleQueryView Article { get; set; }
	    private readonly IArticleQuery _query;
	    private readonly ICommentApplication _commentApplication;

	    public ArticleDetailsModel(IArticleQuery query, ICommentApplication commentApplication)
	    {
		    _query = query;
		    _commentApplication = commentApplication;
	    }

	    public void OnGet(long id)
	    {
		    Article = _query.GetArticle(id);
	    }

	    public RedirectToPageResult OnPost(AddComment command)
	    {
			_commentApplication.Add(command);
			return RedirectToPage("./ArticleDetails", new { id = command.ArticleId });
	    }
    }
}
