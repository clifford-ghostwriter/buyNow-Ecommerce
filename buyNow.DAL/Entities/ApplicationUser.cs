using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace buyNow.DAL.Entities
{
	public class ApplicationUser : IdentityUser
	{

		[StringLength(100)]
		[Required]
		[DisplayName("First Name")]
		public string FirstName { get; set; }


		[StringLength(100)]
		[Required]
		[DisplayName("Last Name")]
		public string LastName { get; set; }

	


	}
}
