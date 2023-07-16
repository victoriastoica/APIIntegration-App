using APIIntegration.Infrastructure.Context;
using APIIntegration.Model.Common;
using Dapper;
using System.Data;

namespace APIIntegration.Infrastructure.Repositories
{
    public class BaseRepository<T> where T : AggregateRoot
    {
        public BaseRepository(DapperContext context, string tableName)
        {
            TableName = tableName;
            Context = context;
        }

        protected string TableName { get; private set; }
        protected DapperContext Context { get; private set; }

        public async Task<T?> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);

            var sql = $"SELECT * FROM {TableName} WHERE [Id] = @ID";

            using (var connection = Context.CreateConnection())
            {
                var user = await connection.QueryAsync<T>(sql, parameters);

                return user?.FirstOrDefault();
            }
        }

        public async Task<IList<T>> GetAsync()
        {
            var sql = $"SELECT * FROM {TableName}";

            using (var connection = Context.CreateConnection())
            {
                var users = await connection.QueryAsync<T>(sql);

                return users.ToList();
            }
        }

        public async Task<int> SoftDeleteAsync(int id)
        {
            var sql = $"UPDATE {TableName} SET IsDeleted = 1 WHERE Id = @id";

            using var connection = Context.CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { id });
            return result;
        }
    }
}
