﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using buyNow.DAL.Entities;
using buyNow_Ecommerce.Data;
using System.Diagnostics;
using buyNow.DAL.Implementation;

namespace buyNow_Ecommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CategoryRepository _category;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
            _category = new CategoryRepository(_context);
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Categories.ToListAsync());

            return View(await _category.GetAll());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)
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
                _category.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
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
