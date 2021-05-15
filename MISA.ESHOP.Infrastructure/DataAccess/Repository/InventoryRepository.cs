using Dapper;
using MISA.ESHOP.Common.Entity;
using MISA.ESHOP.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Infrastructure.DataAccess.Repository
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public IEnumerable<Inventory> GetInventoriesByParentId(Guid id)
        {
            var storeName = "Proc_GetInventoryByParentId";
            var parameters = new DynamicParameters();
            parameters.Add($"@id", id, DbType.String);
            var inventories = dbConnection.Query<Inventory>(storeName, parameters, commandType: CommandType.StoredProcedure);
            return inventories;
        }

        public InventoryPaging GetInventoriesPaging(int pageSize, int pageIndex, InventoryFilterEntity inventoryFilterEntity)
        {
            var storeName = "Proc_GetInventoriesPaging";
            var parameters = new DynamicParameters();
            parameters.Add($"@PageSize", pageSize);
            parameters.Add($"@PageIndex", pageIndex);
            parameters.Add($"@TotalRecord", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
            //parameters.Add($"@TotalPage", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
            parameters.Add($"@SKUCode", inventoryFilterEntity.SKUCode, DbType.String);
            parameters.Add($"@SKUCodeType", inventoryFilterEntity.SKUCodeType, DbType.String);
            parameters.Add($"@InventoryGroup", inventoryFilterEntity.InventoryGroup, DbType.String);
            parameters.Add($"@InventoryGroupType", inventoryFilterEntity.InventoryGroupType, DbType.String);
            parameters.Add($"@InventoryName", inventoryFilterEntity.InventoryName, DbType.String);
            parameters.Add($"@InventoryNameType", inventoryFilterEntity.InventoryNameType, DbType.String);
            parameters.Add($"@SalePrice", inventoryFilterEntity.SalePrice);
            parameters.Add($"@SalePriceType", inventoryFilterEntity.SalePriceType, DbType.String);
            parameters.Add($"@Status", inventoryFilterEntity.Status);
            parameters.Add($"@Display", inventoryFilterEntity.Display);
            parameters.Add($"@Unit", inventoryFilterEntity.Unit);
            parameters.Add($"@UnitType", inventoryFilterEntity.UnitType);

            var storePaging = new InventoryPaging();
            var store = dbConnection.Query<Inventory>(storeName, parameters, commandType: CommandType.StoredProcedure);
            storePaging.Data = store.ToList();
            //storePaging.TotalPage = parameters.Get<int>("@TotalPage");
            storePaging.TotalRecord = parameters.Get<int>("@TotalRecord");
            return storePaging;
        }

        public Inventory GetInventoryBySKUCode(string SKUCode)
        {
            var storeName = "Proc_GetInventoryBySKUCode";
            var parameters = new DynamicParameters();
            parameters.Add($"@SKUCode", SKUCode, DbType.String);
            var inventory = dbConnection.Query<Inventory>(storeName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return inventory;
        }

        public int GetMaxSKUCode(string prefix)
        {
            var storeName = "Proc_GetMaxCode";
            var parameters = new DynamicParameters();
            parameters.Add($"@Prefix", prefix, DbType.String);
            int inventoryCodeMax = dbConnection.ExecuteScalar<int>(storeName, parameters, commandType: CommandType.StoredProcedure);
            return inventoryCodeMax;
        }

        public int UpdateMaxSKUCode(InventoryCodeEntity inventoryCodeEntity)
        {
            var storeName = $"Proc_UpdateMaxCode";
            var rowEffect = dbConnection.Execute(storeName, inventoryCodeEntity, commandType: CommandType.StoredProcedure);
            return rowEffect;

        }
    }
}
