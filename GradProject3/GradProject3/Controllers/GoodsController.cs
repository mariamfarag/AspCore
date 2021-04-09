using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradProject3.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GradProject3.Controllers
{
    public class GoodsController : Controller
    {
        private readonly ProductsContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GoodsController(ProductsContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
            var productsContext = _context.Goods.Include(g => g.IdoffersNavigation).Include(g => g.IdtgNavigation);
            return View(await productsContext.ToListAsync());
        }

        // GET: Goods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .Include(g => g.IdoffersNavigation)
                .Include(g => g.IdtgNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {

            ViewData["Idoffers"] = new SelectList(_context.Offers, "Id", "Id");
            ViewData["Idtg"] = new SelectList(_context.TypeGoods, "Id", "Type");
            return View();
            //return View(new Good());
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idtg,Name,Quantity,Size,Price,ExpireDate,ImagePath,Idoffers")] Good good)
        {

            //    if (good != null)
            //        {
            //            string RootPath = _hostEnvironment.WebRootPath;
            //            string fileName = Path.GetFileNameWithoutExtension(good.ImagePath.FileName);
            //            string extention = Path.GetExtension(good.ImagePath.FileName);
            //            good.Images = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            //            string path = Path.Combine(RootPath + "/Image/", fileName);
            //            var fileStream = new FileStream(path, FileMode.Create);
            //            good.ImagePath.CopyTo(fileStream);
            //        if (good.Idoffers == null)
            //            ViewData["Idoffers"] = new SelectList(_context.Offers, "Id", "Id", good.Idoffers.GetValueOrDefault());
            //            ViewData["Idoffers"] = new SelectList(_context.Offers, "Id", "Id", good.Idoffers);
            //        ViewData["Idtg"] = new SelectList(_context.TypeGoods, "Id", "Type", good.Idtg);
            //            _context.Add(good);
            //            await _context.SaveChangesAsync();
            //            return RedirectToAction(nameof(Index));
            //        }

            //    return View(good);
            //}
            if (ModelState.IsValid)
            {

                string RootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(good.ImagePath.FileName);
                string extention = Path.GetExtension(good.ImagePath.FileName);
                good.Images = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(RootPath + "/image/", fileName);
                var fileStream = new FileStream(path, FileMode.Create);
                good.ImagePath.CopyTo(fileStream);

                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idoffers"] = new SelectList(_context.Offers, "Id", "Id", good.Idoffers);
            ViewData["Idtg"] = new SelectList(_context.TypeGoods, "Id", "Type", good.Idtg);
            return View(good);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }
            ViewData["Idoffers"] = new SelectList(_context.Offers, "Id", "Id", good.Idoffers);
            ViewData["Idtg"] = new SelectList(_context.TypeGoods, "Id", "Type", good.Idtg);
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idtg,Name,Quantity,Size,Price,ExpireDate,Images,Idoffers")] Good good)
        {
            if (id != good.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.Id))
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
            ViewData["Idoffers"] = new SelectList(_context.Offers, "Id", "Id", good.Idoffers);
            ViewData["Idtg"] = new SelectList(_context.TypeGoods, "Id", "Type", good.Idtg);
            return View(good);
        }

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .Include(g => g.IdoffersNavigation)
                .Include(g => g.IdtgNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var good = await _context.Goods.FindAsync(id);
            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodExists(int id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }
    }
}
