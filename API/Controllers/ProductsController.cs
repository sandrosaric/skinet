using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
            
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            return Ok(await _repo.GetProductsAsync());
        }

         [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            return Ok(await _repo.GetProductByIdAsync(id));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands(){
            return Ok(await _repo.GetProductBrandsAsync());
        }


        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrand(int id){
            return Ok(await _repo.GetProductBrandByIdAsync(id));
        }

         [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes(){
            return Ok(await _repo.GetProductTypesAsync());
        }


        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductType(int id){
            return Ok(await _repo.GetProductTypeByIdAsync(id));
        }


    }
}