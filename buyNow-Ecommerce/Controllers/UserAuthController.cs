using buyNow.BAL.Models;
using buyNow.DAL.Entities;
using buyNow_Ecommerce.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace buyNow_Ecommerce.Controllers
{
	public class UserAuthController : Controller
	{

		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _context;
		private readonly ApplicationViewModel _viewModel;



		public UserAuthController(ApplicationDbContext context,
								  UserManager<ApplicationUser> userManager,
								  SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			_viewModel = new ApplicationViewModel();
		}
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(ApplicationViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (model.Registration != null)
				{
					ApplicationUser user = new ApplicationUser
					{
						FirstName = model.Registration.FirstName,
						LastName = model.Registration.LastName,
						Email = model.Registration.Email,
						UserName = model.Registration.Email,
					};
					var result = await _userManager.CreateAsync(user, model.Registration.Password);


					_viewModel.Notifications = new NotificationsModel();




					if (result.Succeeded)
					{
						_viewModel.Notifications.status = true;
						_viewModel.Notifications.message = "successfully registered";
						//return RedirectToAction("index", "Home");

						//return PartialView("_NotificationPartial", _viewModel);

						TempData["AlertMessage"] = "Form submitted successfully!";
						TempData["AlertType"] = "success"; // You can pass an alert type like 'success', 'danger', etc.

						return RedirectToAction("index", "Home");
					}
					else AddErrorsToModelState(result);
				}



			}
			return View();
		}




		public IActionResult Login()
		{
			return View();
		}



		private void AddErrorsToModelState(IdentityResult result)
		{
			foreach (var error in result.Errors)
				ModelState.AddModelError(string.Empty, error.Description);
		}
	}
}
