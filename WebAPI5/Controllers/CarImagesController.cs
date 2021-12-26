using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {

        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService=carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.AddCarImage(formFile,carImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetCarImages();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagebycarid")]
        public IActionResult GetCarImageByCarId(int carId)
        {
            var result = _carImageService.GetCarImageByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = _carImageService.UpdateCarImage(formFile,carImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);


        }

        [HttpDelete("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.DeleteCarImage(carImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);


        }
    }
}
