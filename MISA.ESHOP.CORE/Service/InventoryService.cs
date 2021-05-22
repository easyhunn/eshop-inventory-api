using MISA.ESHOP.Common.Entity;
using MISA.ESHOP.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ESHOP.Core.Service
{
    public class InventoryService: BaseService<Inventory>, IInventoryService
    {
        private IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository) : base(inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        #region Xử lí nghiệp vụ
        public ServiceResult GetInventoriesPaging(int pageSize, int pageIndex, InventoryFilterEntity inventoryFilterEntity)
        {
            serviceResult.isValid = true;
            var inventories = _inventoryRepository.GetInventoriesPaging(pageSize, pageIndex, inventoryFilterEntity);
                
            serviceResult.data = inventories;
            if (inventories.TotalRecord < 1)
            {
                serviceResult.isValid = false;
                serviceResult.errorCode = MISACode.noContent;
            }
            return serviceResult;
        }
        public ServiceResult GetInventoriesByParentId(Guid id)
        {
            serviceResult.isValid = true;
            //Lấy dữ dữ liệu

            var inventories = _inventoryRepository.GetInventoriesByParentId(id);
            //Kiểm trả bản ghi có tồn tại không
            if (inventories.Count() < 1)
            {
                //Nếu không có bản ghi trả về
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
        public ServiceResult GetInventoryBySKUCode(string SKUCode)
        {
            serviceResult.isValid = true;
            //Lấy dữ dữ liệu

            var store = _inventoryRepository.GetInventoryBySKUCode(SKUCode);
            //Kiểm trả bản ghi có tồn tại không
            if (store == null)
            {
                //Nếu không có bản ghi trả về
                serviceResult.isValid = false;
                serviceResult.message = Properties.Resources.Msg_NoContent;
                serviceResult.errorCode = MISACode.noContent;
            }
            else
            {
                serviceResult.data = store;
                serviceResult.message = Properties.Resources.Msg_Success;
            }
            return serviceResult;
        }

        public ServiceResult GetMaxSKUCode(string prefix)
        {
            serviceResult.isValid = true;
            //Lấy dữ dữ liệu

            var store = _inventoryRepository.GetMaxSKUCode(prefix);
            //Kiểm trả bản ghi có tồn tại không
            
            serviceResult.data = store;
            serviceResult.message = Properties.Resources.Msg_Success;
            
            return serviceResult;
        }

        public ServiceResult UpdateMaxSKUCode(InventoryCodeEntity inventoryCodeEntity)
        {
            serviceResult.isValid = true;

            //Thực hiện update
            var res = _inventoryRepository.UpdateMaxSKUCode(inventoryCodeEntity);
            //kiểm tra số lượng bản ghi được sửa/thêm
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
            }
            return serviceResult;
        }
        public ServiceResult InsertInventoryDetail(Inventory inventory)
        {
            serviceResult.isValid = true;
            //Lấy thông tin hàng hoá theo id
           
            var availableInventory = _inventoryRepository.GetById(inventory.InventoryId);
            //Nếu đã tồn tại thực hiện cập nhật
            if (availableInventory != null && inventory.InventoryId != Guid.Empty)
            {
                // kiểm tra dữ liệu
                EntityValidate(inventory, inventory.InventoryId);
                if (!serviceResult.isValid)
                {
                    serviceResult.isValid = false;
                    return serviceResult;
                }
                //Thực hiện update
                var res = _inventoryRepository.UpdateEntity(inventory.InventoryId, inventory);
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
                    updateMaxCode(inventory);

                }
            } else
            {
                //Thực hiện thêm mới 1 hàng hoá
                serviceResult.isValid = true;
                //kiêm tra thông tin cửa hàng
                ValidateEntity(inventory, Guid.Empty);
                if (!serviceResult.isValid)
                {
                    serviceResult.isValid = false;
                    return serviceResult;
                }
                //Thêm mới cửa hàng
                var rowEffect = _inventoryRepository.InsertEntity(inventory);
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
                    updateMaxCode(inventory);
                }
            }
            
            return serviceResult;
        }

        #endregion
        public override void updateMaxCode(Inventory inventory)
        {
            var code = inventory.SKUCode;
            //Lấy code lớn nhất hiện tại => so sánh
            string prefix = getPrefix(code);
            if (prefix != "")
            {
                int max_code = _inventoryRepository.GetMaxSKUCode(code);
                int suffix = getSuffix(code);

                if (suffix > 0 && suffix > max_code)
                {
                    //Cập nhật lại code lớn nhất
                    var inventoryCodeEntity = new InventoryCodeEntity(code, prefix, suffix);
                    _inventoryRepository.UpdateMaxSKUCode(inventoryCodeEntity);
                }
            }
            
            
        }
        public int getSuffix(String code)
        {
            String suffix = "";
            for (int i = code.Length - 1; i > 0; --i)
            {
                if (Char.IsDigit(code[i]))
                    suffix += code[i];
            }
            
            if (suffix.Length > 0)
            {
                char[] charArray = suffix.ToCharArray();
                Array.Reverse(charArray);
                suffix =  new string(charArray);
                return int.Parse(suffix);
            }
                
            return -1;
        }
        public string getPrefix(String code)
        {
            int lastNumber = code.Length - 1;
            for (int i = lastNumber; i >= 0; --i)
            {
                if (Char.IsDigit(code[i]))
                    lastNumber = i;
                else
                    break;
            }
            string prefix = "";
            for (int i = 0; i < lastNumber; ++i)
            {
                prefix += code[i];
            }
            return prefix;
        }
        #region Validate

        public override ServiceResult EntityValidate(Inventory inventory, Guid oldId)
        {
            serviceResult.isValid = true;
            ValidateInformation(inventory);
            if (serviceResult.isValid) ValidCode(inventory.SKUCode, oldId);
            return this.serviceResult;
        }
        /// <summary>
        /// Kiểm tra đầy đủ thông tin bắt buộc
        /// </summary>
        /// <param name="store">
        /// Thông tin cửa hàng
        /// </param>
        /// <returns>
        /// True: Nếu thống tin đủ
        /// False: Nếu có trường thông tin bắt buộc bị trống
        /// </returns>
        public void ValidateInformation(Inventory inventory)
        {
            if (inventory.InventoryName == null || inventory.InventoryName == "")
            {
                serviceResult.message = Properties.Resources.EmptyInventoryName;
                serviceResult.errorCode = MISACode.badRequest;
                serviceResult.isValid = false;
                return;
            }

            if (inventory.SKUCode == null || inventory.SKUCode == "")
            {
                serviceResult.message = Properties.Resources.EmptySKUCode;
                serviceResult.errorCode = MISACode.badRequest;
                serviceResult.isValid = false;
            }
        }

        public void ValidCode(String SKUCode, Guid id)
        {
            Inventory inventory = _inventoryRepository.CheckDuplicateSKUCode(SKUCode, id);

            if (inventory != null)
            {
                serviceResult.errorCode = MISACode.badRequest;
                serviceResult.message = Properties.Resources.DuplicateSKUCode;
                serviceResult.isValid = false;
                return;
            }
        }


        #endregion
    }
}
