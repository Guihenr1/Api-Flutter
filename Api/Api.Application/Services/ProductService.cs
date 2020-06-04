using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.DTOs.Product;
using Api.Application.Interfaces;
using Api.Domain.Interfaces;
using AutoMapper;
using System.Linq;

namespace Api.Application.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return _mapper.ProjectTo<ProductDTO>(products.AsQueryable());
        }

        public async Task<IEnumerable<ProductDTO>> GetAllByCategory(int productCategory)
        {
            var products = await _productRepository.GetByCategory(productCategory);
            return _mapper.ProjectTo<ProductDTO>(products.AsQueryable());
        }
    }
}