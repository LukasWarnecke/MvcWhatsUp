using Microsoft.AspNetCore.Mvc;
using MvcWhatsUp.Models;
using MvcWhatsUp.Repositories;

namespace MvcWhatsUp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            List<User> users = _usersRepository.GetAll();
            return View(users);
        }

        //make a new controller for message to make it cleaner

        public class SimpleMessage
        {
            public string Name { get; set; }
            public string MessageText { get; set; }

            public SimpleMessage()
            {
                Name = "";
                MessageText = "";
            }

            public SimpleMessage(string name, string messageText)
            {
                Name = name;
                MessageText = messageText;
            }
        }

        [HttpPost]
        public string SendMessage(SimpleMessage message)
        {
            return $"Message {message.MessageText} has been send by this Person: {message.Name}";
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                //add user via repo
                _usersRepository.Add(user);

                //go back to user list (via Index)
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //smt went wrong, go back to view with user
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //get user via repo
            User? user = _usersRepository.GetById((int)id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                //update user via repo
                _usersRepository.Update(user);

                //go back to user list (via Index)
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //smt wring, go back to view user
                return View(user);
            }
        }

        [HttpGet]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			//get user via repo
			User? user = _usersRepository.GetById((int)id);
			return View(user);
		}

		[HttpPost]
        public ActionResult Delete(User user)
        {
            try
            {
                _usersRepository.Delete(user.UserId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(user);
            }
        }
    }
}
