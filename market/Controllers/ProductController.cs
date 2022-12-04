using AutoMapper;
using market.Data.Context;
using market.Data.Contracts.Repositories.Products;
using market.Data.Contracts.UnitsOfWork;
using market.Domain.Const;
using market.Domain.DataEntities.Product;
using market.Domain.DataEntities.User;
using market.Host.Models;
using market.Host.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace market.Host.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public ProductController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("[action]/{id?}")]
        public async Task<ActionResult> Index(int id)
        {
            var product = _unitOfWork.Products.Get(id);

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

            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value; 


            productEntity.SellerId = id;

            _unitOfWork.Products.Create(productEntity);
            _unitOfWork.SaveChanges();


            return View("Done");
        }
    }
}
