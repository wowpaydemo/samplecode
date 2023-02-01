namespace Utility.Models
{
    public class PaymentResponse
    {
        public string MerchantTxnId { get; set; } = string.Empty;

        public string PaymentRS { get; set; } = string.Empty;

        public string EncValue { get; set; } = string.Empty;
    }

    public class CallBackResponse: PaymentResponse
    {
        
    }
}
