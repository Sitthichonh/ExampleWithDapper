using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace ExampleWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThaipostController : Controller
    {
        private readonly IThaipost _thaipost;
        public ThaipostController(IThaipost thaipost)
        {
            _thaipost = thaipost;
        }
        [HttpGet]
        public async Task<IActionResult> GetThaipostAll()
        {
            try
            {
                var thaiposts = await _thaipost.GetThaipostAll();
                return Ok(thaiposts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{ZipCode}")]
        public async Task<IActionResult> GetThaipostByIdAsync(string ZipCode)
        {
            try
            {
                var thaipost = await _thaipost.GetThaipostByIdAsync(ZipCode);
                if (thaipost is null)
                    return NotFound();

                return Ok(thaipost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]

        public async Task<IActionResult> InsertThaipostAsync(ThaipostModel thaipost)
        {
            try
            {
                await _thaipost.InsertThaipostAsync(thaipost);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateThaipostAsync(string ZipCode, ThaipostModel thaipost)
        {
            try
            {
                var post = _thaipost.GetThaipostByIdAsync(ZipCode);
                if (post is null)
                    return NotFound();

                await _thaipost.UpdateThaipostAsync(ZipCode, thaipost);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{ZipCode}")]
        public async Task<IActionResult> DeleteThaipost(string ZipCode)
        {
            try
            {
                var post = await _thaipost.GetThaipostByIdAsync(ZipCode);
                if (post is null)
                    return NotFound();

                await _thaipost.DeleteThaipostAsync(ZipCode);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
