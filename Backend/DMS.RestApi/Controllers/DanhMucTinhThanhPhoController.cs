using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DMS.RestApi.ViewModels;
using DMS.Shared;
using DMS.Core.Models;
using DMS.Workflows.DanhMucTinhThanhPhoWorkflows;
using DMS.Workflows;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DMS.Repositories.Helpers;

namespace DMS.RestApi.Controllers
{
    [Route("api/DanhMucTinhThanhPho")]
    [ApiController]
    public class DanhMucTinhThanhPhoController : ControllerBase
    {
        /// <summary>
        /// Create mới một danh mục tỉnh thành phố
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewDanhMucTinhThanhPhoAsync([FromBody] DanhMucTinhThanhPhoViewModel model, CancellationToken cancellationToken)
        {
            var token = Request.GetTokenValue();
            var danhmucthanhpho = model.InsertGetModel();
            var danhmuc = new DanhMucTinhThanhPhoCreateNewWorkflows("", danhmucthanhpho, token);
            var (lastestResult, details) = await danhmuc.ExecuteAsync("", token, cancellationToken);
            if (details[0].Failed) return BadRequest(details[0]);
            var result = details[0].GetData<DanhMucTinhThanhPho>();
            if (result is null) return BadRequest(ErrorCodeCollection.DanhMucTinhThanhPho.DanhMucTinhThanhPhoCreateFail);
            return Ok(result);
        }
        
        /// <summary>
        /// Update 1 danh mục tỉnh thành phố theo id đầu vào
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDanhMucTinhThanhPhoAsync([FromRoute] Guid id, [FromBody] DanhMucTinhThanhPhoViewModel model, CancellationToken cancellationToken)
        {
            var token = Request.GetTokenValue();
            var danhmuc = model.UpdateGetModel();
            var danhmuctinhthanhphoWorkflow = new DanhMucTinhThanhPhoUpdateWorkflows("", token, danhmuc);
            var (lastestResult, details) = await danhmuctinhthanhphoWorkflow.ExecuteAsync("", token, cancellationToken);
            if (details[0].Failed) return BadRequest(details[0]);

            var result = details[0].GetData<DanhMucTinhThanhPho>();
            if (result is null) return BadRequest(ErrorCodeCollection.DanhMucTinhThanhPho.DahMucTinhThanhPhoUpdateFail);
            return Ok(result);
        }

        /// <summary>
        /// Delete một danh mục tỉnh thành phố theo id đầu vào
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDanhMucTinhThanhPhoAsync([FromRoute] Guid id, [FromBody] ObjectDeleteViewModel model, CancellationToken cancellationToken)
        {
            var token = Request.GetTokenValue();
            var danhmucquocgiaId = model.Id;
            var danhmucDeleteWorkflow = new DanhMucTinhThanhPhoDeleteWorkflows("", token, danhmucquocgiaId);
            var (lastestResult, details) = await danhmucDeleteWorkflow.ExecuteAsync("delete", token, cancellationToken);
            if (details[0].Failed) return BadRequest(details[0]);
            return Ok(details[0]);
        }
        
        /// <summary>
        /// Get list all danh mục tỉnh thành phố
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListDanhMucTinhThanhPhoAsync(CancellationToken cancellationToken)
        {
            var token = Request.GetTokenValue();
            var danhmucgetlist = new DanhMucTinhThanhPhoGetListByTokenWorkflows("", token);
            var (lastestResult, details) = await danhmucgetlist.ExecuteAsync("", token, cancellationToken);
            if (details[0].Failed) return BadRequest(details[0]);
            var resultStores = details[0].GetData<List<DanhMucTinhThanhPho>>();
            
            if (resultStores is null) return BadRequest(ErrorCodeCollection.Valid.DataResultIsNull);
            return Ok(resultStores);

        }
        
        /// <summary>
        /// Get 1 danh mục tỉnh thành phố theo id đầu vào
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDanhMucTinhThanhPhoByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var token = Request.GetTokenValue();
            var danhmucGetObjectByIdWorkflows = new DanhMucTinhThanhPhoGetObjectByIdWorkflows("", token, id);
            var (lastestResult, details) = await danhmucGetObjectByIdWorkflows.ExecuteAsync("", token, cancellationToken);
            if (details[0].Failed) return BadRequest(details[0]);
            var result = details[0].GetData<DanhMucTinhThanhPho>();
            if (result is null) return BadRequest(ErrorCodeCollection.Valid.DataResultIsNull);
            return Ok(result);
        }

    }
}
