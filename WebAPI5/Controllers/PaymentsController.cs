using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService=paymentService;
        }
       [HttpPost("pay")]
        public IActionResult Pay(Card card)
        {
            var result=_paymentService.Pay(card);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
    }
}
