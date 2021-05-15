using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Common.Entity
{
    /// <summary>
    /// Thực thể phân trang trả về
    /// </summary>
    /// Created By: VM Hùng (12/05/2021)
    public class InventoryPaging
    {
        /// <summary>
        /// Tổng số lượng trang
        /// </summary>
        /// Created By: VM Hùng (12/05/2021)
        /// 
        public int TotalPage { get; set; }
        /// <summary>
        /// Tổng số lượng bản ghi
        /// </summary>
        /// Created By: VM Hùng (12/05/2021)
        /// 
        public int TotalRecord { get; set; }
        /// <summary>
        /// Danh sách các giá trị trả về sau phân trang
        /// </summary>
        /// Created By: VM Hùng (12/05/2021)
        public List<Inventory> Data { get; set; }
    }
}
