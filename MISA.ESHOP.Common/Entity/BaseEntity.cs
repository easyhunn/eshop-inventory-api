using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Common.Entity
{
    /// <summary>
    /// Model Thực thể chung
    /// </summary>
    /// Created by: VM Hùng(11/05/2021)
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        /// Created by: VM Hùng(11/05/2021)
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        /// Created by: VM Hùng(11/05/2021)
        public String CreatedBy { get; set; }
        /// <summary>
        /// Lần chỉnh sửa đổi bản ghi cuối cùng
        /// </summary>
        /// Created by: VM Hùng(11/05/2021)
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa bản ghi cuối cùng
        /// </summary>
        /// Created by: VM Hùng(11/05/2021)
        public String ModifiedBy { get; set; }
    }
}
