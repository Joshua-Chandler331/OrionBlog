using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionBlog.Data;
using OrionBlog.Models;
using System.ComponentModel.DataAnnotations;

namespace OrionBlog.Controllers
{
    public class CategoryPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryPosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CategoryPost.Include(c => c.BlogCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult CategoryIndex(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var posts = _context.CategoryPost.Where(c => c.BlogCategoryId == id);
            return View("Index", posts);
        }

        // GET: CategoryPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryPost = await _context.CategoryPost
                .Include(c => c.BlogCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryPost == null)
            {
                return NotFound();
            }

            return View(categoryPost);
        }

        // GET: CategoryPosts/Create
        public IActionResult Create()
        {
            ViewData["BlogCategoryId"] = new SelectList(_context.BlogCategory, "Id", "Name");
            return View();
            //return View(await _context.CategoryPost.ToList());
        }

        // POST: CategoryPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BlogCategoryId,Title,Abstract,PostBody,IsProductionReady,Slug,Created,Updated")] CategoryPost categoryPost)
        {
            if (ModelState.IsValid)
            {
                var dateTime = DateTime.Now; //Added
                categoryPost.Created = DateTime.Now; //Added
                _context.Add(categoryPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogCategoryId"] = new SelectList(_context.BlogCategory, "Id", "Name", categoryPost.BlogCategoryId);
            return View(categoryPost);
        }

        // GET: CategoryPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryPost = await _context.CategoryPost.FindAsync(id);
            if (categoryPost == null)
            {
                return NotFound();
            }
            ViewData["BlogCategoryId"] = new SelectList(_context.BlogCategory, "Id", "Name", categoryPost.BlogCategoryId);
            return View(categoryPost);
        }

        // POST: CategoryPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BlogCategoryId,Title,Abstract,PostBody,IsProductionReady,Slug,Created,Updated")] CategoryPost categoryPost)
        {
            if (id != categoryPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dateTime2 = DateTime.Now;
                    categoryPost.Updated = DateTime.Now; //Added
                    _context.Update(categoryPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryPostExists(categoryPost.Id))
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
            ViewData["BlogCategoryId"] = new SelectList(_context.BlogCategory, "Id", "Name", categoryPost.BlogCategoryId);
            return View(categoryPost);
        }

        // GET: CategoryPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryPost = await _context.CategoryPost
                .Include(c => c.BlogCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryPost == null)
            {
                return NotFound();
            }

            return View(categoryPost);
        }

        // POST: CategoryPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryPost = await _context.CategoryPost.FindAsync(id);
            _context.CategoryPost.Remove(categoryPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryPostExists(int id)
        {
            return _context.CategoryPost.Any(e => e.Id == id);
        }
    }
}
