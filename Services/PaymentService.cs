using BooknGo.Data.Models;
using BooknGo.Data;
using BooknGo.Interfaces;

namespace BooknGo.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly BookNGoDbContext _context;

        public PaymentService(BookNGoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            return _context.Payments.FirstOrDefault(p => p.PaymentId == id);
        }

        public Payment AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public bool UpdatePayment(int id, Payment updatedPayment)
        {
            var payment = GetPaymentById(id);
            if (payment == null)
            {
                return false;
            }

            payment.Amount = updatedPayment.Amount;
            payment.PaymentDate = updatedPayment.PaymentDate;
            payment.PaymentMethod = updatedPayment.PaymentMethod;
            _context.SaveChanges();
            return true;
        }

        public bool DeletePayment(int id)
        {
            var payment = GetPaymentById(id);
            if (payment == null)
            {
                return false;
            }
            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return true;
        }
    }
}
