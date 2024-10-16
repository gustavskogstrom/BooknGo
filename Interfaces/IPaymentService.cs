using BooknGo.Data.Models;

namespace BooknGo.Interfaces
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        Payment AddPayment(Payment payment);
        bool UpdatePayment(int id, Payment updatedPayment);
        bool DeletePayment(int id);
    }
}
