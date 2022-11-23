using AutoMapper;
using market.Data.Context;
using market.Data.Contracts.Repositories.Products;
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
        private readonly IProductRepository _productRepository;

        public SearchController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
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

            var goods = _productRepository.GetAll().Where(x => x.Name.Contains(request)).Take(20);


            var model = goods.Select(x => _mapper.Map<ProductModel>(x));

            return View(model.ToList());
        }

    }
}
