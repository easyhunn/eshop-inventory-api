using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Core.Interface
{
    /// <summary>
    ///  Hàm xử kết nối chung
    /// </summary>
    /// Created By: VM Hùng (11/05/2021)
    public interface IBaseRepository<Entity>
    {
        /// <summary>
        /// Lấy danh sách tất cả các thực thể
        /// </summary>
        /// <returns>
        /// Danh sách tất cả thực thể dạng
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        /// 
        IEnumerable<Entity> GetAll();
        /// <summary>
        /// Lấy thực thể theo Id
        /// </summary>
        ///<param name="id">
        /// mã id Thực thể
        /// </param>
        /// <returns>
        /// Thành công: thực thể
        /// không thành công: nulll
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        /// 
        Entity GetById(Guid id);
        /// <summary>
        /// Thêm mới 1 thực thể
        /// </summary>
        /// <param name="entity">
        ///     Thực thể
        /// </param>
        /// <returns>
        /// Số lượng bản ghi được thêm vào
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        /// 
        int InsertEntity(Entity entity);
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
        /// Số lượng bản ghi được thay đổi
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        /// 
        int UpdateEntity(Guid id, Entity entity);
        /// <summary>
        /// Xoá 1 bản ghi
        /// </summary>
        /// <param name="id">
        /// id bản ghi cần xáo
        /// </param>
        /// <returns>
        /// Số lượng bản ghi được xoá
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        int DeleteEntity(Guid id);
        /// <summary>
        /// Xoá nhiều bản ghi
        /// </summary>
        /// <param name="listId">
        /// List các bản ghi
        /// </param>
        /// <returns>
        /// Số lượng bản ghi được xoá
        /// </returns>
        /// Created By: VM Hùng (11/05/2021)
        int DeleteEntities(string listId);
    }
}
