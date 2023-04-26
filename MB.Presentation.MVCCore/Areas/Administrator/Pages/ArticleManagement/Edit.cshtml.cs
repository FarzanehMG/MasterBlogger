using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
	    public EditArticle EditArticle { get; set; }
	    public List<SelectListItem> ArticleCategories { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _categoryApplication;

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication categoryApplication)
        {
	        _articleApplication = articleApplication;
	        _categoryApplication = categoryApplication;
        }

        public void OnGet(long id)
        {
	        EditArticle = _articleApplication.Get(id);
            ArticleCategories = _categoryApplication.List().Select(x=> new SelectListItem(x.Title,x.Id.ToString())).ToList();
        }

        public RedirectToPageResult OnPost()
        {
            _articleApplication.Edit(EditArticle);
            return RedirectToPage("./List");
        }
    }
}
