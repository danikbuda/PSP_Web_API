using Microsoft.AspNetCore.Mvc;
using PSP_Web_API.Services;

namespace PSP_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolumeController : ControllerBase
    {
        
            private readonly AudioService _audioService;

            public VolumeController(AudioService audioService)
            {
                _audioService = audioService;
            }

            [HttpGet]
            public IActionResult GetVolume() => Ok(_audioService.GetVolume());

            [HttpPost("set")]
            public IActionResult SetVolume([FromQuery] float value)
            {
                _audioService.SetVolume(value);
                return Ok();
            }

            [HttpPost("up")]
            public IActionResult Increase([FromQuery] float step = 0.1f)
            {
                _audioService.IncreaseVolume(step);
                return Ok();
            }

            [HttpPost("down")]
            public IActionResult Decrease([FromQuery] float step = 0.1f)
            {
                _audioService.DecreaseVolume(step);
                return Ok();
            }
        
    }
    

   
    
}
