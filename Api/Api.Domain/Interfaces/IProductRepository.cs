using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IProductRepository
    {
         Task<IEnumerable<Product>> GetAll();
    }
}