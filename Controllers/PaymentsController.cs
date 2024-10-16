using BooknGo.Data.Models;
using BooknGo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooknGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Payment>> GetAllPayments()
        {
            return Ok(_paymentService.GetAllPayments());
        }

        [HttpGet("{id}")]
        public ActionResult<Payment> GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public ActionResult<Payment> AddPayment(Payment payment)
        {
            var newPayment = _paymentService.AddPayment(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = newPayment.PaymentId }, newPayment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, Payment updatedPayment)
        {
            if (!_paymentService.UpdatePayment(id, updatedPayment))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            if (!_paymentService.DeletePayment(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
