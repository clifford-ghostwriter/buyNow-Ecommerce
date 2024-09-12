using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buyNow.DAL.Entities;

namespace buyNow.BAL.Models
{

	public class ApplicationViewModel
	{


		public Category? Category { get; set; }

		public Product? Product { get; set; }

		public Review? Review { get; set; }

		public IEnumerable<Category>? Categories { get; set; }

		public IEnumerable<Product>? Products { get; set; }
		public IEnumerable<Review>? Reviews { get; set; }

		public RegistrationModel? Registration { get; set; }

		public LoginModel? Login { get; set; }

		public NotificationsModel? Notifications { get; set; }



	}
}
