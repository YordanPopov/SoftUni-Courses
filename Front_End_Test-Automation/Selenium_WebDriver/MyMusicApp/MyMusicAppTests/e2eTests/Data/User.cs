using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e2eTests.Data
{
	public class User
	{
		public string UserEmail { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }

		public User(string email, string pass)
		{
			UserEmail = email;
			Password = pass;
			ConfirmPassword = pass;
		}
	}
}
