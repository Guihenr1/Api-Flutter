using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Api.Core.Helpers;
using Dapper;
using Npgsql;

namespace Api.Infra.Data.Context
{
    public class PostgresContext<TEntity>
    {
        public PostgresContext()
        {
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(GlobalVariables.PostresqlConnection);
            }
        }
        internal async Task<IEnumerable<T>> Query<T>(string query)
        {

            using (var conn = Connection)
            {
                return await conn.QueryAsync<T>(query);
            }
        }
        internal async Task<T> QueryFirstOrDefault<T>(string query)
        {

            using (var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<T>(query);
            }
        }
        internal async Task<T> QueryFirstOrDefault<T>(string query, object parameters)
        {

            using (var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<T>(query, parameters);
            }
        }

        internal async Task ExecuteAsync(string query, TEntity entity)
        {

            using (var conn = Connection)
            {
                var idResponse = await conn.ExecuteAsync(query, entity);

                if (idResponse == 0)
                    throw new Exception("Error in execute operation.");
            }
        }
        internal async Task ExecuteAsync(string query, object obj)
        {

            using (var conn = Connection)
            {
                var idResponse = await conn.ExecuteAsync(query, obj);

                if (idResponse == 0)
                    throw new Exception("Error in execute operation.");
            }
        }

        internal async Task<T> ExecuteWithReturnAsync<T>(string query, TEntity entity)
        {
            T value;

            using (var conn = Connection)
            {
                value = await conn.ExecuteScalarAsync<T>(query, entity);
            }

            return value;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}