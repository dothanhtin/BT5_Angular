using CloudDinary_BaseUsing.Models;
using CloudDinary_BaseUsing.ViewModels;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CloudDinary_BaseUsing.Controllers
{
  [Route("api/v1/Upload")]
  [ApiController]
  public class BaseUploadController : ControllerBase
  {
    public BaseUploadController()
    {
    }

    [Route("upLoadImage")]
    [HttpPost]
    public async Task<IActionResult> upLoadImage()
    {
      try
      {
        var formCollection = await Request.ReadFormAsync();
        var file = formCollection.Files.First();
        //var file = Request.Form.Files[0];
        var folderName = Path.Combine("Resources", "Images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        if (file.Length > 0)
        {
          var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
          var fullPath = Path.Combine(pathToSave, fileName);
          var dbPath = Path.Combine(folderName, fileName);
          using (var stream = new FileStream(fullPath, FileMode.Create))
          {
            file.CopyTo(stream);
          }
          return Ok(new { dbPath });
        }
        else
        {
          return BadRequest();
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal server error: {ex}");
      }
    }

  }
}
