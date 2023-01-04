using AutoMapper;
using market.Data.Context;
using market.Data.Contracts.Repositories.Products;
using market.Data.Contracts.UnitsOfWork;
using market.Host.Models.Products;
using market.Host.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace market.Host.Controllers
{
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        // GET: SearchController
        /*
        [Route("[action]/{url}")]*/
        [HttpGet]
        public async Task<ActionResult> Search(string request, int? start = 0, int? finish = 10000, int? page = 1)
        {
            if (string.IsNullOrEmpty(request))
            {
                return View();
            }

            int pageNum = page?? 1;
            int pageSize = 4;

            var goods = _unitOfWork.Products.FindSkipTake(x => x.Name.Contains(request) && x.Price >= start && x.Price <= finish, (pageNum - 1) * pageSize, pageSize);


            var model = goods.Select(x => _mapper.Map<ProductModel>(x));

            ViewBag.Req = request;
            ViewBag.Page = pageNum;

            return View( model.ToList());
        }

        

        [Route("profile/{request?}")]
        [HttpGet]
        public async Task<ActionResult> ProfileSearch(string request)
        {
            if (string.IsNullOrEmpty(request))
            {
                return View();
            }


            var profileEntity = _unitOfWork.Users.Get(request);

            profileEntity.ProductModels = _unitOfWork.Products.Find(x => x.SellerId.Equals(profileEntity.Id)).ToList();


            var model = _mapper.Map<UserModel>(profileEntity);


            return View("~/Views/Seller/Profile.cshtml", model);
        }

    }
}
