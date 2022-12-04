using AutoMapper;
using market.Data.Context;
using market.Data.Contracts.Repositories.Products;
using market.Data.Contracts.UnitsOfWork;
using market.Host.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("[action]/{id?}")]
        [HttpPost]
        public async Task<ActionResult> Search(string request)
        {
            if (string.IsNullOrEmpty(request))
            {
                return View();
            }

            var goods = _unitOfWork.Products.FindTake(x => x.Name.Contains(request), 20);


            var model = goods.Select(x => _mapper.Map<ProductModel>(x));

            return View(model.ToList());
        }

    }
}
