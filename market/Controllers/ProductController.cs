using AutoMapper;
using market.Data.Context;
using market.Data.Contracts.Repositories.Products;
using market.Domain.Const;
using market.Domain.DataEntities.Product;
using market.Host.Models;
using market.Host.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace market.Host.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly AppDBContext _appDBContext;


        public ProductController(IMapper mapper, IProductRepository productRepository, AppDBContext appDBContext)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            this._appDBContext = appDBContext;
        }

        [Route("[action]/{id?}")]
        public async Task<ActionResult> Index(int id)
        {
            var product = _productRepository.Get(id);

            if (id < 0 || product == null)
            {
                return View("Error", new ErrorViewModel());
            }


            ProductModel productModel = _mapper.Map<ProductModel>(product);


            return View(productModel);
        }


        [Authorize]
        [Route("[action]/")]
        public async Task<ActionResult> Add()
        {

            return View();
        }


        [Route("[action]/")]
        [HttpPost]
        public async Task<ActionResult> Add(ProductModel model)
        {

            var productEntity = _mapper.Map<ProductEntity>(model);

            var id = _appDBContext.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;


            productEntity.Seller = _appDBContext.Users.First(x => x.Id == id);

            _productRepository.Create(productEntity);


            return View("Done");
        }
    }
}
