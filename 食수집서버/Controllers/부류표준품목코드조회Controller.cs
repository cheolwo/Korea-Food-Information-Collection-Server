using Microsoft.AspNetCore.Mvc;
using 食수집서버.Services;

namespace 食수집서버.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class 부류표준품목코드Controller : ControllerBase
    {
        private readonly 부류표준품목코드조회APIService _service;

        public 부류표준품목코드Controller(부류표준품목코드조회APIService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> GetLClassCode([FromQuery] string type,
            [FromQuery] int startIndex, [FromQuery] int endIndex,
            [FromQuery] string lclassName = null, [FromQuery] string lclassCode = null)
        {
            try
            {
                var result = await _service.GetCodeInfoAsync(type, startIndex, endIndex, lclassName, lclassCode);
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                // Log exception details here...
                return StatusCode(500, $"Error making API request: {e.Message}");
            }
        }
    }
}
