using MISA.ESHOP.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Core.Interface
{
    /// <summary>
    /// Hàm xử lý nghiệm vụ chung
    /// </summary>
    /// Created By: VM Hùng (11/05/2021)
    public interface IBaseService <Entity>
    {

        /// <summary>
        /// Lấy danh sách tất cả các thực thể
        /// </summary>
        /// <returns>
        /// 1 Service Result
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        /// 
        ServiceResult GetAll();
        /// <summary>
        /// Lấy thực thể theo Id
        /// </summary>
        ///<param name="id">
        /// mã id Thực thể
        /// </param>
        /// <returns>
        ///1 Service Result
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        ServiceResult GetById(Guid id);
        /// <summary>
        /// Thêm mới 1 thực thể
        /// </summary>
        /// <param name="entity">
        ///     Thực thể
        /// </param>
        /// <returns>
        ///1 Service Result
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        /// 
        ServiceResult InsertEntity(Entity entity);
        /// <summary>
        ///Sửa thông tin bản ghi 
        /// </summary>
        /// <param name="id">
        /// Mã id bản ghi cần sửa
        /// </param>
        /// <param name="entity">
        /// Thông tin bản ghi
        /// </param>
        /// <returns>
        /// 1 Service Result
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        /// 
        ServiceResult UpdateEntity(Guid id, Entity entity);
        /// <summary>
        /// Xoá 1 bản ghi
        /// </summary>
        /// <param name="id">
        /// id bản ghi cần xáo
        /// </param>
        /// <returns>
        /// 1 Service Result
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        ServiceResult DeleteEntity(Guid id);
        /// <summary>
        /// Xoá nhiều bản ghi
        /// </summary>
        /// <param name="listId">
        /// List các bản ghi
        /// </param>
        /// <returns>
        /// 1 Service Result
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        ServiceResult DeleteEntities(string listId);
    }
}
