namespace Utility.Models
{
    public class SubmitPayment
    {
        public IDictionary<string,string> ParameterCollection { get; set; } = null!;

        public string PaymentUrl { get; set; } = string.Empty;
    }
}
