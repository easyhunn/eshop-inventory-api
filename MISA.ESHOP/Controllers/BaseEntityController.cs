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
    public class BaseEntityController<Entity> : ControllerBase
    {
        private IBaseService<Entity> _baseService;
        public BaseEntityController(IBaseService<Entity> baseService)
        {
            this._baseService = baseService;
        }
        /// <summary>
        /// Lấy thông tin tất cả bản ghi
        /// </summary>
        /// <returns>
        /// 200: Nếu có bản ghi trả về
        /// 204: Nếu không có bản ghi trả về
        /// </returns>
        /// Created by: VM Hùng 12/05/2021
        [HttpGet]
        public IActionResult GetAll()
        {

            var res = _baseService.GetAll();
            if (!res.isValid)
            {
                return StatusCode(204, res);
            }
            else
            {
                return Ok(res.data);
            }

        }
        /// <summary>
        /// Lấy thông tin bản ghi theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Created by: VM Hùng 12/05/2021
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {

            var res = _baseService.GetById(id);
            if (!res.isValid)
            {
                return StatusCode(204, res);
            }
            return Ok(res.data);
        }
        /// <summary>
        /// Xoá thông tin bản ghi
        /// </summary>
        /// <param name="id">
        /// Mã id của bản ghi
        /// </param>
        /// <returns>
        /// 200: thành công
        /// 204: Không lấy được dữ liệu
        /// </returns>
        /// Created By:VM Hùng (12/05/2021)
        [HttpDelete("byId/{id}")]
        public IActionResult DeleteEntity(Guid id)
        {

            var res = _baseService.DeleteEntity(id);
            if (res.isValid)
            {
                return Ok(res.message);
            }
            else
            {
                return StatusCode(204, res);
            }

        }

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="entity">
        /// Thông tin bản ghi
        /// </param>
        /// <param name="id">
        /// Mã id của bản ghi
        /// </param>
        /// <returns>
        /// 200: Nếu cập nhật thành công
        /// 204: Nếu không có bản ghi nào được cập nhật
        /// 400: Nếu trường thông tin bị sai
        /// </returns>
        /// Created By:VM Hùng (12/05/2021)
        [HttpPut("{id}")]
        public IActionResult UpdateEntity(Entity entity, Guid id)
        {

            var res = _baseService.UpdateEntity(id, entity);
            if (res.isValid) return Ok(res.message);
            else
            {
                if (res.errorCode == MISACode.badRequest)
                    return StatusCode(400, res);
                else return StatusCode(204, res);
            }
        }
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">
        /// <param name="entity">
        /// Thông tin bản ghi
        /// </param>
        /// <returns>
        /// 201: Nếu thêm bản ghi thành công
        /// 400: Nếu thông tin đầu vào bị sai
        /// 200: Không có bản ghi nào được thêm
        /// </returns>
        /// Created By:VM Hùng (13/04/2021)
        [HttpPost]
        public IActionResult InsertEntity(Entity entity)
        {
            //thêm dữ liệu
            var res = _baseService.InsertEntity(entity);
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
        /// <summary>
        /// Xoá nhiều bản ghi
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        [HttpDelete("multiple")]
        public IActionResult DeleteEntities(String listId)
        {

            var res = _baseService.DeleteEntities(listId);
            //kiểm tra thành công
            if (res.isValid)
            {
                return StatusCode(200, res.message);
            }
            else
            {
                return StatusCode(204, res);
            }
        }
    }
}
