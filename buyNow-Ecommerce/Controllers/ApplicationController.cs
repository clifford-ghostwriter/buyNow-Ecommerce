using buyNow.BAL.Models;
using buyNow.DAL.Entities;
using buyNow.DAL.Implementation;
using buyNow.DAL.Interface;
using buyNow_Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace buyNow_Ecommerce.Controllers
{
    public class ApplicationController : Controller

    {
        private readonly ApplicationDbContext _context;
        private readonly CategoryRepository _category;
        private readonly ApplicationViewModel _applicationviewmodel;
 

        public ApplicationController(ApplicationDbContext context)
        {
            _context = context;
            _category = new CategoryRepository(_context);
            _applicationviewmodel = new ApplicationViewModel();
        }
        public IActionResult Index()
        {
            return View();
        }


        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ApplicationViewModel model)
        {



            //ModelState.Remove("Category.Categories");

            //_applicationviewmodel.Category = new Category();
            //_applicationviewmodel.Category.Name = model.Category.Name;
            //_applicationviewmodel.Category.Description = model.Category.Description;


            if (ModelState.IsValid)

            {

                //// Iterate through the ModelState errors
                //foreach (var state in ModelState)
                //{
                //    foreach (var error in state.Value.Errors)
                //    {
                //        // Log the error message (e.g., to the console, a file, or debug window)
                //        Console.WriteLine($"Property: {state.Key}, Error: {error.ErrorMessage}");
                //        Console.ReadLine();
                //    }
                //}


                //Console.WriteLine(ModelState);
                //Console.ReadLine();
                //_context.Add(category);

                if (model.Category != null) {

                    _category.Add(model.Category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
               
            }


            return View();
        }
    }
}
