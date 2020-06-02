using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.DTOs.Product;
using Api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController<ProductController>
    {
        readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        /// <returns>Retorna todos os produtos.</returns>
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            IEnumerable allProducts = new List<ProductDTO>();
            try
            {
                allProducts = await _productService.GetAll();
            }
            catch (Exception ex)
            {
                return CreateServerErrorResponse(ex, null);
            }

            return CreateResponse(allProducts);
        }

        /// <summary>
        /// Listar os produtos por categoria
        /// </summary>
        /// <param name="productCategory">ID da categoria do produto.</param>
        /// <returns>Retorna todos os produtos por categoria.</returns>
        [HttpGet("productCategory")]
        public async Task<IActionResult> Get(int productCategory)
        {
            IEnumerable allProductsByType = new List<ProductDTO>();
            try
            {
                allProductsByType = await _productService.GetAllByType(productCategory);
            }
            catch (Exception ex)
            {
                return CreateServerErrorResponse(ex, null);
            }

            return CreateResponse(allProductsByType);
        }
    }
}