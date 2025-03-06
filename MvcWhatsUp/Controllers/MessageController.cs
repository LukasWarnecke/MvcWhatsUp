using Microsoft.AspNetCore.Mvc;

namespace MvcWhatsUp.Controllers
{
	public class MessageController : Controller
	{
		private readonly ApplicationDbContext _context;

		public MessageController(ApplicationDbContext _context)
		{
			_context = context;
		}
		public IActionResult Index()
		{

			var messages = _context.Messages.ToList();

			return View(messages);

		}
	}
}
