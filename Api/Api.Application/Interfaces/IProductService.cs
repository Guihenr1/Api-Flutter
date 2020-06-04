using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.DTOs.Product;

namespace Api.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<IEnumerable<ProductDTO>> GetAllByCategory(int productCategory);
    }
}