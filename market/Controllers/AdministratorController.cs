using AutoMapper;
using market.Data.Contracts.UnitsOfWork;
using market.Domain.DataEntities.User;
using market.Host.Models.Products;
using market.Host.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace market.Host.Controllers
{
    //TODO admincontroller
    [Authorize(Policy = "RequireAdministratorRole")]
    public class AdministratorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AdministratorController(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = autoMapper;
        }

        // GET: AdministratorController
        public ActionResult Index()
        {
            //UserEntity a
            var usersEntity = _unitOfWork.Users.GetAll().ToList();
            var usersModel = usersEntity.Select(x => _mapper.Map<UserModel>(x)).ToList();
            foreach(var user in usersModel)
            {
               user.ProductModels = _unitOfWork.Products.Find(x => x.SellerId == user.Id).Select(x => _mapper.Map<ProductModel>(x)).ToList();
            }


            return View(usersModel);
        }

        // GET: AdministratorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministratorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministratorController/Create
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

        // GET: AdministratorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministratorController/Edit/5
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

        // GET: AdministratorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministratorController/Delete/5
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
