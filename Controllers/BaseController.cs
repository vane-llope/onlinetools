using Microsoft.AspNetCore.Mvc;

namespace onlinetools.Controllers
{
    public class BaseController : ControllerBase
    {
        [HttpGet("custom/ok")]
        public IActionResult CustomOk(object data = null, string message = "")
        {
            return Ok(new Result()
            {
                Message = message,
                Data = data,
                Status = Status.Success
            });
        }

        [HttpGet("custom/error")]
        public IActionResult CustomError(object data = null, string message = "")
        {
            return BadRequest(new Result()
            {
                Message = message,
                Data = data,
                Status = Status.Failed
            });
        }


    }
    public class Result
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public object Status { get; set; }
    }

    public enum Status
    {
        Success = 1,
        Failed = -1
    }
}
