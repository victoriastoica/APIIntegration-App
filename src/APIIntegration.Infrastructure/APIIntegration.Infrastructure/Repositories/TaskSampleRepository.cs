using APIIntegration.Infrastructure.Context;
using APIIntegration.Model.TaskAggregate;
using Dapper;

namespace APIIntegration.Infrastructure.Repositories
{
    internal class TaskSampleRepository : BaseRepository<TaskSample>, ITaskSampleRepository
    {
        private readonly static string tableName = "dbo.[Task]";
        public TaskSampleRepository(DapperContext context) : base(context, tableName)
        {
        }

        public async Task<int> InsertAsync(TaskSample entity)
        {
            var sql = $"INSERT {tableName}(Name, Date, Type, IsProcessed, IsDeleted) VALUES (@Name, @Date, @Type, 0, 0)";

            using var connection = Context.CreateConnection();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }

        public async Task<int> UpdateAsync(TaskSample entity)
        {
            var sql = $"UPDATE {tableName} SET Name = @Name, Date = @Date, Type = @Type WHERE Id = @Id";

            using var connection = Context.CreateConnection();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }
}
