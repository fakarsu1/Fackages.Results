using Fackages.Results;
using Microsoft.AspNetCore.Mvc;
using Samples.WebApi.Messages;

namespace Samples.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("DefaultSuccessResult")]
        public IActionResult GetDefaultSuccessResult()
        {
            var result = Result.Success();
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("DefaultErrorResult")]
        public IActionResult GetDefaultErrorResult()
        {
            var result = Result.Error();
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("CustomResultMessageNoResource")]
        public IActionResult GetSuccessResultWithMessage()
        {
            var result = Result.Success(ResultMessage.NoResource);
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("CustomResultMessageOnlyDisplayName")]
        public IActionResult GetCustomResultMessageOnlyDisplayName()
        {
            var result = Result.Success(ResultMessage.OnlyDisplayName);
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("CustomResultMessageWithResource")]
        public IActionResult GetCustomResultMessageWithResource()
        {
            var result = Result.Success(ResultMessage.Test1);
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("CustomResultMessageWithResourceAndDisplayName")]
        public IActionResult GetCustomResultMessageWithResourceAndDisplayName()
        {
            var result = Result.Success(ResultMessage.Test2);
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("CustomResultMessageWithMessageArgs")]
        public IActionResult GetCustomResultMessageWithMessageArgs()
        {
            var result = Result.Error(ResultMessage.RecordAlreadyExists, Guid.NewGuid());
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("CustomResultMessageWithStatusCode")]
        public IActionResult GetCustomResultMessageWithStatusCode()
        {
            var result = Result.Error(ResultMessage.WithCustomStatusCode);
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("SuccessDataResult")]
        public IActionResult GetSuccessDataResult()
        {
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();

            var result = Result.SuccessData(data);
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet("ErrorDataResult")]
        public IActionResult GetErrorDataResult()
        {
            var errorDetails = new List<string> { "Error detail 1...", "Error detail 2..." };

            var result = Result.ErrorData(errorDetails);
            return StatusCode(result.HttpStatusCode, result);
        }
    }
}