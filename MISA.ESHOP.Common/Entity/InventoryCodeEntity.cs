using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Common.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryCodeEntity
    {
        public InventoryCodeEntity()
        {

        }
        public InventoryCodeEntity(String InventoryCode, string prefix, int suffix )
        {
            this.InventoryCode = InventoryCode;
            this.Prefix = prefix;
            this.Suffix = suffix;
            
        }

        /// <summary>
        /// id của mã hàng hoá
        /// </summary>
        /// Created By: VM Hùng (12/05/2021)
        public String InventoryCodeId { get; set; }
        /// <summary>
        /// Má hàng hoá
        /// </summary>
        /// Created By: VM Hùng (12/05/2021)
        public String InventoryCode { get; set; }
        /// <summary>
        /// Tiền tố mã hàng hoá
        /// </summary>
        /// Created By: VM Hùng (12/05/2021)
        public String Prefix { get; set; }
        /// <summary>
        /// Hậu tố mã hàng hoá
        /// </summary>
        /// Created By: VM Hùng (12/05/2021)
        public int Suffix { get; set; }
    }
}
