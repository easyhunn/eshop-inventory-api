using MISA.ESHOP.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Core.Interface
{
    public interface IInventoryService:IBaseService<Inventory>
    {
        /// <summary>
        /// Lọc bản ghi cùng phân trang
        /// </summary>
        /// <param name="pageSize">Kích thước </param>
        /// <param name="pageIndex">Vị trí trang</param>
        /// <param name="inventoryFilterEntity">Các thuộc tính lọc</param>
        /// <returns>
        /// 1 ServiceResult
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        public ServiceResult GetInventoriesPaging(int pageSize, int pageIndex, InventoryFilterEntity inventoryFilterEntity);
        /// <summary>
        /// Lấy thông tin hàng hoá theo mã SKU
        /// </summary>
        /// <param name="SKUCode">
        /// Mã SKU 
        /// </param>
        /// <returns>
        /// Kết quả lấy thông tin hàng hoá
        /// </returns>
        /// CreatedBy: VM Hùng (12/05/2021)
        public ServiceResult GetInventoryBySKUCode(String SKUCode);
        /// <summary>
        /// Lấy danh sách hàng hoá bởi id của hàng hoá cha
        /// </summary>
        /// <param name="id">
        /// id của hàng hoá cha
        /// </param>
        /// <returns>
        /// Kết quả việc lấy danh sách
        /// </returns>
        /// CreatedBy: VM Hùng (12/05/2021)
        public ServiceResult GetInventoriesByParentId(Guid id);
        /// <summary>
        /// Lấy mã code lớn nhất của tiền tố
        /// </summary>
        /// <param name="prefix">Tiền tố</param>
        /// <returns>
        /// Kết quả việc lấy mã code
        /// </returns>
        /// CreatedBy: VM Hùng (12/05/2021)
        public ServiceResult GetMaxSKUCode(String prefix);
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
        /// <returns>
        /// Kết quả khi sau khi thực hiện update
        /// </returns>
        /// CreatedBy: VM Hùng (12/05/2021)
        public ServiceResult UpdateMaxSKUCode(InventoryCodeEntity inventoryCodeEntity);
        /// <summary>
        /// Thêm mới 1 chi tiết hàng hoá
        /// </summary>
        /// <param name="inventory">thông tin hàng hoá</param>
        /// <returns>
        /// Kết quả việc thêm 
        /// </returns>
        public ServiceResult InsertInventoryDetail(Inventory inventory);
    }
}

