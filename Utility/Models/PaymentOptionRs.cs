using Newtonsoft.Json;


namespace Utility.Models
{
    public class PaymentOptionRs
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "req_datetime")]
        public DateTime ReqDateTime { get; set; } = DateTime.UtcNow;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_options")]
        public List<PaymentOptions> Options { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error")]
        public Error? Error { get; set; } 
    }
    public class Error
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error_code")] 
        public string ErrorCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error_type")]
        public string ErrorType { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error_description")]
        public string ErrorDescription { get; set; } = string.Empty;
    }

    public class PaymentOptions
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_optionid")]
        public Guid PaymentOptionId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_type")] 
        public string PaymentType { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "display_name")] 
        public string DisplayName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_method")]
        public string RequestMethod { get; set; } = string.Empty;                

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_channels")]
        public List<Channels> ChannelList { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "capture_card")]
        public int? CardCapture { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "display_order")]
        public int DisplayOrder { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isasynchornous_payment")]
        public bool IsAsynchornousPayment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "country")]
        public string CountryCode { get; set; } = string.Empty;
        
    }
    public class Channels
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_id")]
        public string PaymentId { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_type")]
        public string? CardType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "channel_code")]
        public string ChannelCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "channel_name")]
        public string ChannelName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_url")]
        public string RequestUrl { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "image_url")]
        public string ImageUrl { get; set; } = string.Empty;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "iscredntialneed")]
        public bool IsCredentialsNeed { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "credential_template")]
        public string CredentialTemplate { get; set; } = string.Empty;
    }
}
