using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Techo.Pages;
using Techo.Contracts;

namespace Techo.Pages
{
    public class IndexModel : ModelBase
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger) : base()
        {
            _logger = logger;
        }

        public void OnGet()
        {
            CheckLogin();
        }
    }
}