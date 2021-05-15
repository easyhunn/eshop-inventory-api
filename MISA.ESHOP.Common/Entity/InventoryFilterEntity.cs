using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Common.Entity
{
    /// <summary>
    /// Thuộc tính lọc của hàng hoá
    /// </summary>
    public class InventoryFilterEntity
    {
        /// <summary>
        /// Tên hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String InventoryName { get; set; }
        /// <summary>
        /// kiểu lọc của tên hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String InventoryNameType { get; set; }

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
        /// Kiểu lọc của nhóm hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String InventoryGroupType { get; set; }

        /// <summary>
        /// Mã SKU hàng hoá
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        /// Created By: VM Hùng (11/05/2021)
        public String SKUCode { get; set; }
        /// <summary>
        /// Kiểu lọc của mã SKU
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String SKUCodeType { get; set; }

        /// <summary>
        /// Giá bán
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public double SalePrice { get; set; }
        /// <summary>
        /// Kiểu lọc của giá bán
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        /// 
        public string SalePriceType { get; set; }

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
        /// Kiểu lọc của đơn vị 
        /// </summary>
        /// Created By: VM Hùng (11/05/2021)
        public String UnitType { get; set; }
    }
}
