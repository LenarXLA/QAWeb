using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QAWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleContext _artContext;

        public ArticlesController(ArticleContext artContext)
        {
            _artContext = artContext;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            return await _artContext.Articles
                .ToListAsync();
        }

        // GET: api/Articles/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(Guid id)
        {
            Article? article = await _artContext.Articles
                .FirstOrDefaultAsync(u => u.Id == id);

            if (article == null) return NotFound(new { message = "Пользователь не найден" });

            return article;
        }


    }
}
