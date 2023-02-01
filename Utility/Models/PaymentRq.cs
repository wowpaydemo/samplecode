
using Newtonsoft.Json;
using Utility.Helpers;

namespace Utility.Models
{
    public class PaymentRq
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "language")]
        public string Language { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "requestid")]
        public string RequestId { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "customerip")]
        public string CustomerIp { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_info")]
        public PaymentInfo PaymentInfo { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "order_info")]
        public OrderInfo OrderInfo { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "customer_info")]
        public List<CustomerInfo> CustomerInfo { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_rtn_url")]
        public string ReturnUrl { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_callback_url")]
        public string CallBackUrl { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_request_time")]
        public DateTime RequestedTime { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_expiry")]
        public DateTime PaymentExpiry { get; set; } = DateTime.UtcNow.AddHours(2);

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "signature")]
        public string Signature { get; set; } = string.Empty;        


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "device_info")]
        public DeviceInfo DeviceInfo { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_access")]
        public MerchantAccess MerchantAccess { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "user_reference")]
        public string UserReference { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "attempt_reference")]
        public string AttemptReference { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "profiling_reference")]
        public string ProfilingReference { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "extra_data")]
        public string ExtraData { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "inquiry_id")]
        public string InquiryId { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "additionalinfo")]
        public List<AdditionalInfo> AdditionalInfos { get; set; } = null!;


    }

    public class CardInfo
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cardholder_name")]
        public string NameontheCard { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_no")]
        public string CardNo { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cvv")]
        public string Cvv { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_type")]
        public string CardType { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "exp_month")]
        public int ExpMonth { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "exp_year")]
        public int ExpYear { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "start_month")]
        public int StartMonth { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "start_year")]
        public int StartYear { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "issuer_name")]
        public string IssuerName { get; set; } = string.Empty;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "issuer_country")]
        public string IssuerCountry { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "credit_or_debit")]
        public string CreditOrDebit { get; set; } = string.Empty;
        
    }

    public class PaymentInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_id")]
        public string PaymentId { get; set; } = string.Empty;

        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_type")]
        public string PaymentType { get; set; } = string.Empty;


        [JsonProperty(PropertyName = "merchant_txnid")]
        public string MerchantTxnId { get; set; } = string.Empty;


        [JsonProperty(PropertyName = "txn_amount", Required = Required.Always)]
        public decimal TxnAmount { get; set; }


        [JsonProperty(PropertyName = "txn_currency", Required = Required.Always)]
        public string TxnCurrency { get; set; } = string.Empty;


        [JsonProperty(PropertyName = "is_installment")]
        public bool IsInstallment { get; set; }

        [JsonProperty(PropertyName = "installment_period")]
        public int InstallmentPeriod { get; set; }

        /// <summary>
        /// Customer/merchant/bank
        /// </summary>
        [JsonProperty(PropertyName = "installment_interesttype", NullValueHandling = NullValueHandling.Ignore)]
        public string InterestType { get; set; } = string.Empty;

        /// <summary>
        /// Possible values 0, 1,2,3
        ///0-None (non cc), 1-merchant website,2-in gqpay page,3-bank.provider page.
        /// </summary>
        [JsonProperty(PropertyName = "capture_card")]
        public int CaptureCard { get; set; }

        /// <summary>
        /// its added for the purpose if the merchant sents the request without the cardno but with cardtype then paymentprovider can collect the card details
        /// </summary>
        [JsonProperty(PropertyName = "card_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CardType { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_ref1")]
        public string MerchantRefNo1 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_ref2")]
        public string MerchantRefNo2 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "pnr")]
        public string Pnr { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_info")]
        public CardInfo CardInfo { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "custom_field1")]
        public string CustomField1 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "custom_field2")]
        public string CustomField2 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "custom_field3")]
        public string CustomField3 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isstore_cardinfo")]
        public bool IsStoreCardInfo { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "customer_id")]
        public string CustomerId { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "card_token")]
        public string CardToken { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "token_identifer")]
        public string Identifier { get; set; } = string.Empty;

    }

    public class CustomerInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "first_name")]
        public string FirstName { get; set; } = string.Empty;


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "last_name")]
        public string LastName { get; set; } = string.Empty;
        

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "customer_type")]
        public string CustomerType { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "mobile")]
        public string Mobile { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// applicable only for travel or accommadation
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "islead_pax")]
        public bool IsLeadPax { get; set; }

        // address & city details only for lead customer
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "address")]
        public string Address { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "city")]
        public string City { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string State { get; set; } = string.Empty;


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "postcode")]
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// Its country 2 digit countrycode.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "country")]
        public string Country { get; set; } = string.Empty;
    }

    public class OrderInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "order_desc")]
        public string OrderDesc { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "item_list")]
        public List<ItemInfo> ItemList { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flight_info")]
        public List<FlightInfo> FlightInfoList { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hotel_info")]
        public List<HotelInfo> HotelInfoList { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "insurance_info")]
        public InsuranceInfo InsuranceInfo { get; set; } = null!;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tour_info")]
        public List<TourInfo> TourInfoList { get; set; } = null!;
    }

    public class ItemInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "item_id")]
        public int ItemId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "item_code")]
        public string ItemCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "item_type")]
        public ItemType Itemtype { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "item_name")]
        public string ItemName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "item_desc")]
        public string ItemDesc { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "item_amount")]
        public decimal ItemAmount { get; set; }
        
    }

    public class FlightInfo
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "mins_beforedeparture")]
        public int MinsBeforeDeparture { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flight_id")]
        public int FlightId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "journey_type")]
        public JourneyType JType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_city")]
        public string DepartureCity { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_airport")]
        public string DepartureAirport { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_airport_code")]
        public string DepartureAirportCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_country")]
        public string DepartureCountry { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_date")]
        public DateTime DepartureDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_city")]
        public string ArrivalCity { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_airport")]
        public string ArrialAirport { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_airport_code")]
        public string ArrivalAirPortCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_country")]
        public string ArrivalCountry { get; set; } = string.Empty;

        /// <summary>
        /// If one ways its possible for null
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_date")]
        public DateTime ArrivalDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "adult_count")]
        public int NofAdults { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "child_count")]
        public int NoofChild { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "infant_count")]
        public int NoofInfant { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flight_amount")]
        public decimal FlightAmount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flight_tax")]
        public decimal TaxAmount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flight_segments")]
        public List<SegmentInfo> SegmentsList { get; set; } = null!;
    }

    public class SegmentInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "segment_id")]
        public int SegmentId { get; set; }


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_city")]
        public string DepartureCity { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_airport")]
        public string DepartureAirPort { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_airport_code")]
        public string DepartureAirPortCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_city")]
        public string ArrivalCity { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_airport")]
        public string ArrivalAirPort { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_airport_Code")]
        public string ArrivalAirPortCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_country")]
        public string DepartureCountry { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_country")]
        public string ArrivalCountry { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "departure_date")]
        public DateTime DepartureDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "arrival_date")]
        public DateTime ArrivalDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cabin_class")]
        public string CabinClass { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "booking_class")]
        public string BookingClass { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "flight_no")]
        public string FlightNo { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "airline_code")]
        public string AirlineCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "airline_name")]
        public string AirlineName { get; set; } = string.Empty;

        //it may be marketing airline
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "other_airline_code")]
        public string OtherAirlineCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "other_airline_name")]
        public string OtherAirlineName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "aircraft_type")]
        public string AirCraftType { get; set; } = string.Empty;
    }

    public class HotelInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hotel_name")]
        public string HotelName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hotel_city")]
        public string HotelCity { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hotel_country")]
        public string HotelCountry { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "check_in")]
        public DateTime CheckIn { get; set; } 

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "check_out")]
        public DateTime CheckOut { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "no_of_guest")]
        public int TotalNoGuest { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hotel_amount")]
        public decimal TotalHotelAmount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rooms")]
        public List<RoomInfo> RoomInfoList { get; set; } = null!;

    }

    public class RoomInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "room_id")]
        public int RoomId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "room_type")]
        public string RoomType { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "board_type")]
        public string BoardType { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "adult_count")]
        public int NofAdults { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "child_count")]
        public int NoofChild { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "infant_count")]
        public int NoofInfant { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "room_amount")]
        public decimal RoomAmount { get; set; }

    }

    public class InsuranceInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "insurance_code")]
        public string InsuranceCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "insurance_name")]
        public string InsuranceName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "insurance_amount")]
        public decimal InsuranceAmount { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "adult_count")]
        public int NoofAddults { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "child_count")]
        public int NoofChild { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "infant_count")]
        public int NoofInfants { get; set; }

    }

    public class TourInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tour_id")]
        public int TourId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tour_code")]
        public string TourCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tour_name")]
        public string TourName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tour_type")]
        public string TourType { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tour_city")]
        public string TourCity { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tour_date")]
        public DateTime TourDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "adult_count")]
        public int NoofAddults { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "child_count")]
        public int NoofChild { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "infant_count")]
        public int NoofInfants { get; set; }

    }

    /// <summary>
    /// If merchant wants to maintain the credentials for their payment service provider and pass to wowpay then can use 'MerchantAccess' element.
    /// </summary>

    public class MerchantAccess
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "providerid")]
        public string ProviderId { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "accesscode")]
        public string AccessCode { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "accesskey")]
        public string AccessKey { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "username")]
        public string UserName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "password")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "secretkey")]
        public string Secretkey { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "param1")]
        public string Param1 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "param2")]
        public string Param2 { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "param3")]
        public string Param3 { get; set; } = string.Empty;
    }

    public class DeviceInfo
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "deviceid")]
        public string DeviceId { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "devicename")]
        public string DeviceName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "devicemodel")]
        public string DeviceModel { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "otherinfo")]
        public string OtherInfo { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "devicetype")]
        public string DeviceType { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "browser")]
        public string Browser { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "useragent")]
        public string UserAgent { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "acceptheader")]
        public string AcceptHeader { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "acceptlanguage")]
        public string AcceptLanguage { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "devicefingerprint")]
        public string DeviceFingerPrint { get; set; } = string.Empty;

    }

    public class AdditionalInfo
    {
        public string FieldName { get; set; } = string.Empty;

        public string FieldValue { get; set; } = string.Empty;

        public string FieldDesc { get; set; } = string.Empty;
    }
}
