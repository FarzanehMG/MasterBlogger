using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
	public class IndeModel : PageModel
	{
		private readonly ILogger<IndeModel> _logger;

		public IndeModel(ILogger<IndeModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{

		}
	}
}