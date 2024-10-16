using AutoMapper;
using BooknGo.Data.Models;
using BooknGo.DTOs;
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
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentDTO>> GetAllPayments()
        {
            var payments = _paymentService.GetAllPayments();
            var paymentDTOs = _mapper.Map<IEnumerable<PaymentDTO>>(payments);
            return Ok(paymentDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentDTO> GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDTO = _mapper.Map<PaymentDTO>(payment);
            return Ok(paymentDTO);
        }

        [HttpPost]
        public ActionResult<PaymentDTO> AddPayment(PaymentDTO paymentDTO)
        {
            var payment = _mapper.Map<Payment>(paymentDTO);
            var newPayment = _paymentService.AddPayment(payment);
            var newPaymentDTO = _mapper.Map<PaymentDTO>(newPayment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = newPaymentDTO.PaymentId }, newPaymentDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, PaymentDTO updatedPaymentDTO)
        {
            var updatedPayment = _mapper.Map<Payment>(updatedPaymentDTO);
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
