namespace Utility.Helpers
{
    public class Enums
    {
        
    }

    public enum RequestType
    {
        /// <summary>
        /// Request to wowpay should be submitted using Http.Post method with form elements.
        /// </summary>
        HTTP_FORMPOST = 1,

        /// <summary>
        /// Request to wowpay should be submitted using Http.Get method with form elements.
        /// </summary>
        HTTP_FORMGET = 2,

        /// <summary>
        /// Request should be submitted using Http.Post method with json data via server-to-server call.
        /// </summary>
        HTTP_S2SPOST = 3,

        /// <summary>
        /// Request to wowpay should be submitted using Http.Get method with json data via server-to-server call.
        /// </summary>
        HTTP_S2SGET = 4,

        /// <summary>
        /// Request to wowpay should be submitted using Http.Get method with json data via server-to-server call.
        /// </summary>
        REDIRECT = 5,

        /// <summary>
        /// Request to wowpay should be submitted using Http.Post method with and the data in keyvaluepair via server-to-server call.
        /// </summary>
        HTTP_S2S_FORMPOST = 6,

        /// <summary>
        /// First Request to wowpay is server-to-server, based on the response, redirect to the url receieved from the first response.
        /// </summary>

        HTTP_S2S_REDIRECT = 7
    }

    public enum ItemType
    {
        Package = 1,
        Flight = 2,
        Hotel = 3,
        Tour = 4,
        Transfer = 5,
        Insurance = 6,
        Meals = 7,
        Others = 8,
        GeneralCheckOut = 9,
    }

    public enum JourneyType
    {
        OneWay = 1,
        RoundTrip = 2,
        MultiCity = 3
    }
}
