using MISA.ESHOP.Common.Entity;
using MISA.ESHOP.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Core.Service
{
    public class BaseService<Entity>:IBaseService<Entity>
    {
        IBaseRepository<Entity> _baseRepository;
        protected ServiceResult serviceResult;
        public BaseService(IBaseRepository<Entity> baseRepository)
        {
            this._baseRepository = baseRepository;
            serviceResult = new ServiceResult();
        }

        public ServiceResult GetAll()
        {
            // Lấy tất cả bản ghi
            serviceResult.isValid = true;
            var inventories = _baseRepository.GetAll();

            // Kiểm tra số lượng bản ghi trả về
            if (inventories.Count() == 0)
            {
                serviceResult.isValid = false;
                serviceResult.message = Properties.Resources.Msg_NoContent;
                serviceResult.errorCode = MISACode.noContent;
            }
            else
            {
                serviceResult.data = inventories;
                serviceResult.message = Properties.Resources.Msg_Success;
            }

            return serviceResult;
        }

        public ServiceResult GetById(Guid id)
        {
            serviceResult.isValid = true;
            //Lấy dữ dữ liệu

            var entity = _baseRepository.GetById(id);
            //Kiểm trả bản ghi có tồn tại không
            if (entity == null)
            {
                //Nếu không có bản ghi trả về
                serviceResult.isValid = false;
                serviceResult.message = Properties.Resources.Msg_NoContent;
                serviceResult.errorCode = MISACode.noContent;
            }
            else
            {
                serviceResult.data = entity;
                serviceResult.message = Properties.Resources.Msg_Success;
            }
            return serviceResult;
        }

        public ServiceResult DeleteEntity(Guid id)
        {   
            serviceResult.isValid = true;
            var rowEffect = _baseRepository.DeleteEntity(id);
            if (rowEffect == 0)
            {
                serviceResult.isValid = false;
                serviceResult.errorCode = MISACode.noContent;
                return serviceResult;
            }
            else
            {
                if (rowEffect == -1)
                {
                    serviceResult.isValid = false;
                    serviceResult.errorCode = MISACode.inernalException;
                    return serviceResult;
                }
                serviceResult.message = Properties.Resources.Msg_DeleteSuccess;
                return serviceResult;
            }
        }
        public ServiceResult DeleteEntities(string listId)
        {
            serviceResult.isValid = true;
            int idQuantity = listId.Count(ch => ch == ',') + 1;
            var rowEffect = _baseRepository.DeleteEntities(listId);
            if (rowEffect == 0)
            {
                serviceResult.isValid = false;
                serviceResult.errorCode = MISACode.noContent;
                return serviceResult;
            }
            else
            {
                if (rowEffect < idQuantity)
                {
                    serviceResult.isValid = false;
                    serviceResult.errorCode = MISACode.inernalException;
                    return serviceResult;
                }
                serviceResult.message = Properties.Resources.Msg_DeleteSuccess;
                return serviceResult;
            }
        }

        public ServiceResult InsertEntity(Entity entity)
        {

            serviceResult.isValid = true;
            //kiêm tra thông tin cửa hàng
            ValidateEntity(entity, Guid.Empty);
            if (!serviceResult.isValid)
            {
                serviceResult.isValid = false;
                return serviceResult;
            }
            //Thêm mới cửa hàng
            var rowEffect = _baseRepository.InsertEntity(entity);
            //kiểm tra thêm bản ghi mới thành công
            if (rowEffect == 0)
            {
                // Nếu thêm bản ghi không thành công
                serviceResult.message = Properties.Resources.Msg_NoContent;
                serviceResult.isValid = false;
                serviceResult.errorCode = MISACode.success;
            }
            else
            {
                //Nếu thêm bản ghi thành công
                serviceResult.message = Properties.Resources.Msg_InsertSuccess;
                serviceResult.isValid = true;
                //cập nhật mã
                updateMaxCode(entity);
            }
            return serviceResult;
        }
        public ServiceResult UpdateEntity(Guid id, Entity entity)
        {
            serviceResult.isValid = true;

            // kiểm tra dữ liệu
            ValidateEntity(entity, id);
            if (!serviceResult.isValid)
            {
                serviceResult.isValid = false;
                return serviceResult;
            }
            //Thực hiện update
            var res = _baseRepository.UpdateEntity(id, entity);
            //kiểm tra số lượng bản ghi được update
            if (res == 0)
            {
                serviceResult.message = Properties.Resources.Msg_NoContent;
                serviceResult.errorCode = MISACode.noContent;
                serviceResult.isValid = false;
            }
            else
            {
                serviceResult.message = Properties.Resources.Msg_Success;
                serviceResult.errorCode = MISACode.success;
                updateMaxCode(entity);

            }
            return serviceResult;
        }
        /// <summary>
        /// Thay đổi mã code lớn nhất
        /// </summary>
        /// Created By: VM Hùng (12/05/2021)
        public virtual void updateMaxCode (Entity entity)
        {

        }
        #region Xử lý nghiệp vụ
        public void ValidateEntity(Entity entity, Guid id)
        {
            //check đủ thông tin bắt buộc
            //if (!ValidateInformation(entity)) return false;
            ServiceResult entityServiceResult = InventoryValidate(entity, id);
            if (!entityServiceResult.isValid)
            {
                this.serviceResult = entityServiceResult;
            }
            // check trùng mã
            //if (!isValidCode(store.StoreCode, id)) return false;
        
        }
        /// <summary>
        /// Hàm xử lý nghiệp vụ riêng
        /// </summary>
        /// <returns></returns>
        public virtual ServiceResult InventoryValidate(Entity inventory, Guid id) {
            return this.serviceResult;
        }

        
        #endregion
    }
}
