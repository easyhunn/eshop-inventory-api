using Dapper;
using MISA.ESHOP.Core.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Infrastructure.DataAccess.Repository
{
    public class BaseRepository<Entity> : IBaseRepository<Entity>
    {
        private String _connectionString = "UserID = root; " +
                "Host=127.0.0.1; " +
                "DataBase= MF760_VMHung_EshopInventory; " +
                "port=9999;" +
                "password=12345678a;";
        private String _className = typeof(Entity).Name;
        protected DbConnection dbConnection;
        public BaseRepository() {
            dbConnection = new MySqlConnection(_connectionString);
        }

        public int DeleteEntities(string listId)
        {

            var parameters = new DynamicParameters();
            parameters.Add($"ListId", listId, DbType.String);
            var correctClassName = _className;
            var classNameLength = correctClassName.Length;
            if (correctClassName[classNameLength - 1] == 'y')
            {
                correctClassName = correctClassName.Substring(0, classNameLength - 1) + "ie";
            }
            var storeName = $"Proc_Delete{correctClassName}s";

            var rowEffect = dbConnection.Execute(storeName, parameters, commandType: CommandType.StoredProcedure);
            return rowEffect;
        }

        public int DeleteEntity(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add($"@{_className}Id", id, DbType.String);
            var storeName = $"Proc_Delete{_className}";
            var rowEffect = dbConnection.Execute(storeName, parameters, commandType: CommandType.StoredProcedure);
            return rowEffect;
        }

        public IEnumerable<Entity> GetAll()
        {
            var correctClassName = _className;
            var classNameLength = correctClassName.Length;
            if (correctClassName[classNameLength - 1] == 'y')
            {
                correctClassName = correctClassName.Substring(0, classNameLength - 1) + "ie";
            }
            var storeName = $"Proc_Get{correctClassName}s";
            var entity = dbConnection.Query<Entity>(storeName, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public Entity GetById(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add($"@{_className}Id", id, DbType.String);
            var storeName = $"Proc_Get{_className}ById";
            var entity = dbConnection.Query<Entity>(storeName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public int InsertEntity(Entity entity)
        {
        
            var storeName = $"Proc_Insert{_className}";
            var rowEffect = dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            return rowEffect;
        }

        public int UpdateEntity(Guid id, Entity entity)
        {
            var storeName = $"Proc_Update{_className}";

            var rowEffect = dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            return rowEffect;
        }
    }
}
