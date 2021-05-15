using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Common.Entity
{
    /// <summary>
    /// Kết quả trả về của service
    /// </summary>
    /// Created By: VM Hung(11/05/2021)
    public class ServiceResult
    {
        //Kết quả trả về chính xác
        public bool isValid;
        public ServiceResult()
        {
            isValid = true;
        }
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        /// Created By: VM Hung(11/05/2021)
        public object data { get; set; }
        /// <summary>
        /// Thông báo
        /// </summary>
        /// Created By: VM Hung(11/05/2021)
        public String message { get; set; }
        /// <summary>
        /// Mã code 
        /// </summary>
        /// Created By: VM Hung(11/05/2021)
        public String errorCode { get; set; }
    }
}
