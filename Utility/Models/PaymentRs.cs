using Newtonsoft.Json;


namespace Utility.Models
{
    public class PaymentRs
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "txnentry_id")]
        public Guid TxnEntryId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_txnid")]
        public string MerchantTxnId { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error")]
        public Error? Error { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "paymentrs_info")]
        public PaymentRsInfo PaymentRsInfo { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_info")]
        public PaymentInfo PaymentInfo { get; set; } = null!;

        /// <summary>
        /// It should not sent to merchant and its used to update extra details into txnentry
        /// </summary>
        public string Comments { get; set; } = string.Empty;

        
    }

    [Serializable]
    public class PaymentRsInfo
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "txn_status")]
        public string TxnStatus { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "txn_statuscode")]
        public int TxnStatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "txn_statusdesc")]
        public string TxnStatusDesc { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "requestid")]
        public string RequestId { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "provider_desc")]
        public string ProviderDesc { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "signature")]
        public string Signature { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "approval_code")]
        public string ApprovalCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_no")]
        public string TransactionNo { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_ref")]
        public string TransactionRefNo1 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_ref2")]
        public string TransactionRefNo2 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "additional_info")]
        public string AdditionalInfo { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_provider")]
        public string PaymentProvider { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_method")]
        public string PaymentMethod { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "channel_code")]
        public string ChannelCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "agent_code")]
        public string AgentCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "threeDs")]
        public ThreeDs ThreeDs { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "qr_data")]
        public QRData QrData { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payslip_url")]
        public string PaymentSlipUrl { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "additionalinfolist")]
        public List<AdditionalInfo> AdditionalInfoList { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "instruction_url")]
        public string InstructionUrl { get; set; } = string.Empty;

    }

    [Serializable]
    public class ThreeDs
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "eci")]
        public string Eci { get; set; } = string.Empty;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "eci_description")]
        public string EciDescription { get; set; } = string.Empty;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transactionno_for3D")]
        public string TransactionNofor3Ds { get; set; } = string.Empty;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "version")]
        public string Version { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cavv")]
        public string Cavv { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "authresult")]
        public string Authresult { get; set; } = string.Empty;

        public bool Is3DSuccess { get; set; }
    }

    [Serializable]
    public class QRData
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "qr_codedata")]
        public string QRCodeData { get; set; } = string.Empty;
        //Whether it is QRCode data (cleint need to generate the qrimage using this data) / or QRCode imageurl
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "qr_option")]
        public string QROption { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "qr_imageurl")]
        public string QRImageUrl { get; set; } = string.Empty;
    }
}
