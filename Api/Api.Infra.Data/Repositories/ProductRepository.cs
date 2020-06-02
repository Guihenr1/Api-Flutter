using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repositories
{
    public class ProductRepository : PostgresContext<Product>, IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAll() 
        {
            return await Query<Product>(
                $@"SELECT * FROM ""product""");
        }

        public async Task<IEnumerable<Product>> GetByCategory(int categoryID)
        {
            return await Query<Product>(
                $@"SELECT * FROM ""product"" where ""Category"" = " + categoryID);
        }
    }
}