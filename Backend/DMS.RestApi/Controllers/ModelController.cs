using DMS.Core.Models;
using DMS.RestApi.ViewModels.Employee;
using DMS.Workflows.ModelsWorkflows;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.RestApi.Controllers
{
  [Route("api/model")]
  [ApiController]
  public class ModelController : ControllerBase
  {
    [HttpPost]
    public async Task<IActionResult> InsertNewModel([FromBody] ModelViewModel model, CancellationToken cancellationToken)
    {
      var token = Request.GetTokenValue();
      var newModel = model.GetModel();
      var modelInsertWorkflow = new ModelInsertWorkflows(newModel);
      var (lastestResult, details) = await modelInsertWorkflow.ExecuteAsync("", token, cancellationToken);
      if (details[0].Failed) return BadRequest(details[0]);
      var result = details[0].GetData<Model>();
      if (result is null) return BadRequest("Something is wrong");
      await Task.Delay(200);
      return Ok(1);
    }

    [HttpGet]
    public async Task<IActionResult> GetListModelAsync(CancellationToken cancellationToken)
    {
      //await Task.Delay(300);
      var token = Request.GetTokenValue();
      var modelGetlist = new ModelGetAllWorkflows();
      var (lastestResult, details) = await modelGetlist.ExecuteAsync("", token, cancellationToken);
      if (details[0].Failed) return BadRequest(details[0]);
      var resultStores = details[0].GetData<List<Model>>();

      if (resultStores is null) return BadRequest("NULL");
      return Ok(resultStores);

    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateModelAsync([FromRoute] Guid id, [FromBody] ModelViewModel model, CancellationToken cancellationToken)
    {
      var token = Request.GetTokenValue();
      var updateModel = model.GetModel();
      updateModel.Id = id;
      var updateModelWorkflow = new ModelUpdateWorkflows(updateModel);
      var (lastestResult, details) = await updateModelWorkflow.ExecuteAsync("", token, cancellationToken);
      if (details[0].Failed) return BadRequest(details[0]);

      var result = details[0].GetData<Model>();
      if (result is null) return BadRequest("Update Failed");
      //await Task.Delay(200);
      return Ok(1);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteModelAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
      var token = Request.GetTokenValue();
      var modelDeleteWorkflow = new ModelDeleteWorkflows(id);
      var (lastestResult, details) = await modelDeleteWorkflow.ExecuteAsync("", token, cancellationToken);
      if (details[0].Failed) return BadRequest(details[0]);
      await Task.Delay(200);
      return Ok(1);
    }
  }
}
