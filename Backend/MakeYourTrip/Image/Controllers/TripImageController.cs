using Image.Interfaces;
using Image.Models;
using Image.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactCors")]

    public class TripImageController : ControllerBase
    {
        private readonly ITripImage _tripImageService;

        public TripImageController(ITripImage tripImageService)
        {
            _tripImageService = tripImageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TripImage), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<TripImage>>> GetAllTripImages()
        {
            var tripImages = await _tripImageService.GetAllTripImages();
            if (tripImages != null)
            {
                return Ok(tripImages);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TripImage), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TripImage>> GetTripImage(int id)
        {
            var tripImage = await _tripImageService.GetTripImage(id);
            if (tripImage != null)
            {
                return Ok(tripImage);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TripImage), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TripImage>> DeleteTripImage(int id)
        {
            var deletedTripImage = await _tripImageService.DeleteTripImage(id);
            if (deletedTripImage != null)
            {
                return Ok(deletedTripImage);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(TripImage), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TripImage>> AddTripImage([FromBody] TripImage tripImage)
        {
            var addedTripImage = await _tripImageService.AddTripImage(tripImage);
            if (addedTripImage != null)
            {
                return CreatedAtAction(nameof(GetTripImage), new { id = addedTripImage.ImageId }, addedTripImage);
            }
            return BadRequest("Unable to add trip image at this moment");
        }
    }

}
