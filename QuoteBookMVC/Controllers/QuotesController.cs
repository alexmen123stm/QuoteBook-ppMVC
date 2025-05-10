using Microsoft.AspNetCore.Mvc;
using QuoteBookMVC.Data;
using QuoteBookMVC.Models;

namespace QuoteBookMVC.Controllers
{
    public class QuotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Quotes.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Quotes.Add(quote);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(quote);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var quote = _context.Quotes.Find(id);
            if (quote == null)
                return NotFound();

            return View(quote);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var quote = _context.Quotes.Find(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
