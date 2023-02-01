using Utility.Helpers;

namespace Utility.Models
{
    public class SelectedPayment:CardInfo
    {        
        public string PaymentId { get; set; } = string.Empty;

        public string PaymentUrl { get; set; } = string.Empty;

        public RequestType Requesttype { get; set; } = RequestType.HTTP_FORMPOST;//default                 

        public string CustomerId { get; set; } = string.Empty;

        public string CardToken { get; set; } = string.Empty;

        public bool StoreCard { get; set; } 
    }
}
