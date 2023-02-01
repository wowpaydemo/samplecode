using Newtonsoft.Json;
using Utility.Helpers;

namespace Utility.Models
{
    public class PaymentOptionRq
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_id")]
        public Guid MerchantId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_code")]
        public string MerchantCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "username")]
        public string UserName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "password")] 
        public string Password { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "currency")] 
        public string Currency { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "country")]
        public string Country { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "product_code")] 
        public string ProductCode { get; set; } = "ALL";

        public override string ToString()
        {
            return SerializationHelper.Serialize(this);
        }

    }
}
