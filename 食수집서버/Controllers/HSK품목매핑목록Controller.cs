using Microsoft.AspNetCore.Mvc;
using HSKItemMapping; // HSK품목매핑목록조회Service의 네임스페이스

namespace 食수집서버.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HSK품목매핑목록Controller : ControllerBase
    {
        private readonly HSK품목매핑목록조회Service _hskService;
        private readonly string _apiKey;

        public HSK품목매핑목록Controller(HSK품목매핑목록조회Service hskService, IConfiguration configuration)
        {
            _hskService = hskService;
            _apiKey = configuration["HSKApi:ApiKey"];
        }

        [HttpGet]
        public async Task<IActionResult> GetHSKItemMapping([FromQuery] string type, [FromQuery] int startIndex, [FromQuery] int endIndex, [FromQuery] string categoryCode, [FromQuery] string productCode)
        {
            try
            {
                var result = await _hskService.GetHSKItemMappingAsync(_apiKey, type, startIndex, endIndex, categoryCode, productCode);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
