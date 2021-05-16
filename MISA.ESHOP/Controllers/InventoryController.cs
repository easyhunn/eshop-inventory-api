using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ESHOP.Common.Entity;
using MISA.ESHOP.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ESHOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : BaseEntityController<Inventory>
    {
        private IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService) : base(inventoryService)
        {
            this._inventoryService = inventoryService;
        }
        [HttpGet("SKUCode/{SKUCode}")]
        public IActionResult GetInventoryBySKUCode(String SKUCode)
        {

            var res = _inventoryService.GetInventoryBySKUCode(SKUCode);
            if (!res.isValid)
            {
                return StatusCode(204, res);
            }
            return Ok(res.data);
        }
        [HttpGet("ParentId/{id}")]
        public IActionResult GetInventoryByParentId(Guid id)
        {

            var res = _inventoryService.GetInventoriesByParentId(id);
            if (!res.isValid)
            {
                return StatusCode(204, res);
            }
            return Ok(res.data);
        }
        /// <summary>
        /// Lẫy Mã SKU lớn nhất
        /// </summary>
        /// <param name="prefix">
        /// Tiền tố mã cần lấy
        /// </param>
        /// <returns>
        /// Hậu tố lớn nhất của mã
        /// 0: mã chưa tồn tại
        /// </returns>
        [HttpGet("MaxCode/{prefix}")]
        public IActionResult GetMaxSKUCode(String prefix)
        {

            var res = _inventoryService.GetMaxSKUCode(prefix);
            
            return Ok(res.data);
        }
        [HttpPut("updateMaxCode")]
        public IActionResult UpdateMaxSKuCode(InventoryCodeEntity inventoryCodeEntity)
        {

            var res = _inventoryService.UpdateMaxSKUCode(inventoryCodeEntity);
            if (res.isValid) return Ok(res.message);
            else
            {   
                if (res.errorCode == MISACode.badRequest)
                    return StatusCode(400, res);
                else return StatusCode(204, res);
            }
        }
        [HttpGet("paging")]
        public IActionResult GetInventoriesPaging(int pageIndex, 
                                                    int pageSize, 
                                                    string SKUCode,
                                                    string inventoryName,
                                                    string inventoryGroup,
                                                    string unit,
                                                    double salePrice,
                                                    int status,
                                                    int display,
                                                    string SKUCodeType,
                                                    string inventoryNameType,
                                                    string inventoryGroupType,
                                                    string unitType,
                                                    string salePriceType
                                                )
        {

            var inventoryFilterEntity = new InventoryFilterEntity();
            inventoryFilterEntity.Display = display;
            inventoryFilterEntity.InventoryGroup = inventoryGroup;
            inventoryFilterEntity.InventoryGroupType = inventoryGroupType;
            inventoryFilterEntity.InventoryName = inventoryName;
            inventoryFilterEntity.SalePrice = salePrice;
            inventoryFilterEntity.InventoryNameType = inventoryNameType;
            inventoryFilterEntity.SalePriceType = salePriceType;
            inventoryFilterEntity.SKUCode = SKUCode;
            inventoryFilterEntity.SKUCodeType = salePriceType;
            inventoryFilterEntity.Status = status;
            inventoryFilterEntity.Unit = unit;
            inventoryFilterEntity.UnitType = unitType;
            inventoryFilterEntity.SKUCodeType = SKUCodeType;

            ServiceResult res = _inventoryService.GetInventoriesPaging(pageSize, pageIndex, inventoryFilterEntity);
            if (res.isValid)
            {
                return Ok(res.data);
            }
            else
            {
                return StatusCode(204, res);
            }
        }
        [HttpPost("detail")]
        public IActionResult InsertInventoryDetail(Inventory inventory)
        {
            //thêm dữ liệu  
            var res = _inventoryService.InsertInventoryDetail(inventory);
            //kiểm tra thêm thành công
            if (res.isValid)
            {
                return StatusCode(201, res.message);
            }
            else
            {
                if (res.errorCode == MISACode.badRequest)
                {
                    return StatusCode(400, res);
                }
                return StatusCode(200, res.message);
            }
        }
    }
}
