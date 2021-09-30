using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload()
        {
            var formCollection = await Request.ReadFormAsync();
            var files = formCollection.Files;
            foreach (var file in files)
            {
                var blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "images");
                blobContainerClient.CreateIfNotExists();
                var containerClient = blobContainerClient.GetBlobClient(file.FileName);
                var blobHttpHeader = new BlobHttpHeaders
                {
                    ContentType = file.ContentType
                };
                await containerClient.UploadAsync(file.OpenReadStream(), blobHttpHeader);
            }

            return Ok();
        }
    }
}
