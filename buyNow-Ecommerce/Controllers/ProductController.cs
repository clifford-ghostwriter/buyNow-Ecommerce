using System.Collections.Generic;
using buyNow.BAL.Models;
using buyNow.DAL.Entities;
using buyNow.DAL.Implementation;
using buyNow.UTILITY;
using buyNow_Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace buyNow_Ecommerce.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ProductRepository _product;
		private readonly ApplicationViewModel _viewModel;
		private readonly CategoryRepository _category;

		public ProductController(ApplicationDbContext context)
		{
			_context = context;
			_product = new ProductRepository(_context);
			_viewModel = new ApplicationViewModel();
			_category = new CategoryRepository(_context);
		}

		// GET: Category
		public async Task<IActionResult> Index()
		{

			_viewModel.Products = await _product.GetAll();
			return View(_viewModel);
		}

		// GET: Category/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = _product.GetById(id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Category/Create
		public async Task<IActionResult> Create()
		{
			IEnumerable<Category> categories = await _category.GetAll();

			Product product = new Product
			{
				Categories = categories.ConvertToSelectList(0)

			};
			_viewModel.Product = product;

			return View(_viewModel);
		}

		// POST: Category/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ApplicationViewModel model)
		{

			ModelState.Remove("Categories");
			//if (!ModelState.IsValid)
			//{
			//    // Iterate through the ModelState errors
			//    foreach (var state in ModelState)
			//    {
			//        foreach (var error in state.Value.Errors)
			//        {
			//            // Log the error message (e.g., to the console, a file, or debug window)
			//            Console.WriteLine($"Property: {state.Key}, Error: {error.ErrorMessage}");
			//        }
			//    }

			//    return View(); // Return the view with validation messages
			//}


			//Console.WriteLine(category.Description);
			//Console.WriteLine(category.Name);
			//Console.ReadLine();



			if (ModelState.IsValid)
			{

				//Console.WriteLine(ModelState);
				//Console.ReadLine();
				//_context.Add(category);
				if (model.Product != null)
				{
					_product.Add(model.Product);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}

			}


			return View();
		}

		// GET: Category/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = _product.GetById(id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		// POST: Category/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Product product)
		{
			if (id != product.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_product.Update(product);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CategoryExists(product.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(product);
		}

		// GET: Category/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = _product.GetById(id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: Category/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = _product.GetById(id);
			if (product != null)
			{
				_product.Delete(product);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CategoryExists(int id)
		{
			return _context.Categories.Any(e => e.Id == id);
		}
	}
}
