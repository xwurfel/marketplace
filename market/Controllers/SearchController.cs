using AutoMapper;
using market.Data.Context;
using market.Host.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace market.Host.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;

        public SearchController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: SearchController
        
        public async Task<ActionResult> Index(string request)
        {
            var goods = from m in _context.Products select m;
            if (!string.IsNullOrEmpty(request))
            {
                goods = goods.Where(x => x.Name.Contains(request)).Take(5);
            }

            IQueryable<ProductModel> model = goods.Select(x => _mapper.Map<ProductModel>(x));

            return View(await model.ToListAsync());
        }

        // GET: SearchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SearchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
