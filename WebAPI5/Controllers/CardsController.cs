using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {

        ICardService _cardService;
        public CardsController(ICardService cardService)
        {
            _cardService= cardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getcardbyuserid")]
        public IActionResult GetCardByUserId(int userId)
        {
            var result = _cardService.GetCardByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Card card)
        {
            var result = _cardService.AddCard(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("upDate")]
        public IActionResult UpDate(Card card)
        {
            var result = _cardService.UpDateCard(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Card card)
        {
            var result = _cardService.DeleteCard(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

