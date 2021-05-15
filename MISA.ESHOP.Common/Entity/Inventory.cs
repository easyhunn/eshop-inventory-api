using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Common.Entity
{
    /// <summary>
    /// Thông tin hàng hoá
    /// </summary>
    /// Created By: VM Hùng (11/05/2021)
    public class Inventory:BaseEntity
    {
        /// <summary>
        /// Mã id của hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public Guid InventoryId { get; set; }
        /// <summary>
        /// Tên hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String InventoryName { get; set; }
        /// <summary>
        /// Trạng thái kinh doanh
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public int Status { get; set; }
        /// <summary>
        /// Nhóm Hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String InventoryGroup { get; set; }
        /// <summary>
        /// Mã SKU hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String SKUCode { get; set; }
        /// <summary>
        /// Giá bán
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public double SalePrice { get; set; }
        /// <summary>
        /// Giá mua
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public double PurchasePrice { get; set; }
        /// <summary>
        /// Hiển thị trên MH bán hàng
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)

        public int Display { get; set; }
        /// <summary>
        /// Đơn vị
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String Unit { get; set; }
        /// <summary>
        /// Màu sắc
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String Color { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String Description { get; set; }
        /// <summary>
        /// Chị tiết hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String InventoryDetail { get; set; }
        /// <summary>
        /// Mã id của mặt hàng cha
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public Guid? ParentId { get; set; }

    }
}
