using MvcWhatsUp.Models;

namespace MvcWhatsUp.Repositories
{
	public class DummyUsersRepository : IUsersRepository
	{
		List<User> users =
		[
			new User(1, "Peter Sauber", "06-1234325", "pete.sauber@gmail.com", "Password1567"),
			new User(2, "Kathrin Bart", "04-2399805", "kathrin.bart@gmail.com", "kathrinmeyer312"),
			new User(3, "Morris Bellamy", "01-1782345", "morris.bellamy@gmail.com", "morrisiscool354"),
			new User(4, "Mary Bella", "02-2345", "mary.bella@gmail.com", "hallothisis890"),
			new User(5, "Ivan Neon", "05-19015926", "ivan.neon@gmail.com", "mybirrhday"),
			new User(6, "Eric Scherder", "09-583941", "eric.scherder@gmail.com", "hahahakv"),
			new User(7, "Jana Mueller", "04-829340123", "jana.mueller@gmail.com", "bellomydog534")
		];

		public List<User> GetAll()
		{
			return users;
		}

		public User? GetById(int userId)
		{
			/*
			for (int i = 0; i < users.Count; i++)
			{
				if (i == userId)
				{
					return users[i];
				}
			}
			*/

			// do not hand this in, have to use a loop(?)
			return users.FirstOrDefault(x => x.UserId == userId);
		}

		public void Add(User user)
		{
			users.Add(user);
		}

		public void Update(User user)
		{
			//user[user.UserId] = users.Add(user);
		}

		public void Delete(User user)
		{
			users.Remove(user);
		}

		public void Delete(int userId)
		{
			throw new NotImplementedException();
		}
	}
}
