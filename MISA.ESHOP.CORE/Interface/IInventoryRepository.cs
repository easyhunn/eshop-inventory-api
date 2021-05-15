using MISA.ESHOP.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Core.Interface
{

    public interface IInventoryRepository:IBaseRepository<Inventory>
    {
        /// <summary>
        /// Lọc bản ghi cùng phân trang
        /// </summary>
        /// <param name="pageSize">Kích thước </param>
        /// <param name="pageIndex">Vị trí trang</param>
        /// <param name="inventoryFilterEntity">Các thuộc tính lọc</param>
        /// <returns>
        /// Danh sách các bản ghi lấy được sau lọc
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        public InventoryPaging GetInventoriesPaging(int pageSize, int pageIndex, InventoryFilterEntity inventoryFilterEntity);
        /// <summary>
        /// Lấy thông tin hàng hoá theo mã SKU
        /// </summary>
        /// <param name="SKUCode">
        /// Mã SKU 
        /// </param>
        /// <returns>
        /// thông tin hàng hoá được lấy
        /// </returns>
        /// CreatedBy: VM Hùng (12/05/2021)
        public Inventory GetInventoryBySKUCode(String SKUCode);
        /// <summary>
        /// Lấy danh sách hàng hoá bởi id của hàng hoá cha
        /// </summary>
        /// <param name="id">
        /// id của hàng hoá cha
        /// </param>
        /// <returns>
        /// Danh sách các hàng hoá
        /// </returns>
        public IEnumerable<Inventory> GetInventoriesByParentId(Guid id);
        /// <summary>
        /// Lấy mã code lớn nhất của tiền tố
        /// </summary>
        /// <param name="prefix">Tiền tố</param>
        /// <returns>
        /// Mã code lớn nhất hiện tại
        /// </returns>
        public int GetMaxSKUCode(String prefix);
        /// <summary>
        /// Cập nhất mã SKU lớn nhất
        /// </summary>
        /// <param name="SKUCode">
        /// Mã SKU
        /// </param>
        /// <param name="prefix">
        /// Tiền tố của mã SKU
        /// </param>
        /// <param name="suffix">
        /// Hậu tố SKU
        /// </param>
        /// <returns></returns>
        public int UpdateMaxSKUCode(InventoryCodeEntity inventoryCodeEntity);
        /// <summary>
        /// Kiểm tra trùng mã SKU
        /// </summary>
        /// <param name="SKUCode">mã SKU code</param>
        /// <param name="inventoryId">mã id</param>
        /// <returns>
        /// thông tin hàng hoá trùng
        /// null
        /// </returns>
        public Inventory CheckDuplicateSKUCode(string SKUCode, Guid inventoryId);
        /// <summary>
        /// SỬ mã SKU
        /// </summary>
        /// <param name="SKUCode"></param>
        /// <returns>
        /// Số lượng bản ghi ảnh hưởng
        /// </returns>
        public int UpdateSKUCode(String SKUCode);
    }
}
