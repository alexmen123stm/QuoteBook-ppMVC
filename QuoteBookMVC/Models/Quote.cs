using Microsoft.AspNetCore.Mvc;

namespace QuoteBookMVC.Models
{
    public class Quote : Controller
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}