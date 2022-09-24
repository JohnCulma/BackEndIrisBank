using DataFileUpload.DTOs;
using DataFileUpload.Helpers.Answers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataFileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadAndUploadFile : ControllerBase
    {
        [HttpPost("RegisterData", Name = "registerData")]
        public async Task<ActionResult> Post([FromForm] Files file)
        {

            if (file.data == null)
            {
                return BadRequest(new GeneralAnswers()
                {
                    title = "Read and upload",
                    status = 400,
                    message = "Data not found"
                });
            }




            return Created("", new GeneralAnswers()
            {
                title = "Read and upload",
                status = 201,
                message = "file found",
                otherdata = ""
            });
        }
    }
}
