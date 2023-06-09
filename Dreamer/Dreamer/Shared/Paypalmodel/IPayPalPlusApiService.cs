using PayPal.v1.Payments;
using System;
using System.Threading.Tasks;

namespace Dreamer.Shared.Paypalmodel
{
    public interface IPayPalPlusApiService
    {
        string GetReferenceWithVerification(string entityName, string number, Guid guid);
        Task<Payment> CreatePaymentAsync(PaypalTransaction transaction);
    }
}
