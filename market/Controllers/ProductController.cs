using AutoMapper;
using market.Data.Context;
using market.Data.Contracts.Repositories.Products;
using market.Domain.Const;
using market.Domain.DataEntities.Product;
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
        private readonly AppDBContext _context;
        private readonly IProductRepository _productRepository;


        public ProductController(IMapper mapper, AppDBContext appDBContext, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _context = appDBContext;
        }

        [Route("[action]/{id?}")]
        public async Task<ActionResult> Index(int id)
        {
            if (id < 0)
            {
                return View();
            }

            var product = _productRepository.Get(id);

            ProductModel productModel = _mapper.Map<ProductModel>(product);


            return View(productModel);
        }


        [Authorize(Roles = "Administrator")]

        [Route("[action]/")]
        public async Task<ActionResult> Add()
        {
            var a = HttpContext.User.Identities.FirstOrDefault();


            return View();
        }


        [Route("[action]/")]
        [HttpPost]
        public async Task<ActionResult> Add(ProductModel model)
        {

            var productEntity = _mapper.Map<ProductEntity>(model);

            _productRepository.Create(productEntity);


            return View();
        }
    }
}
