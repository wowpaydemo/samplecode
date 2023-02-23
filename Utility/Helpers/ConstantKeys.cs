namespace Utility.Helpers
{
	public class ConstantKeys
	{
		public const string SandboxPaymentOptionEndpoint = "https://sandbox.api.wowpay.io/api/paymentoptions";

		public const string SandboxHostedPaymentEndpoint = "https://sandbox.pay.wowpay.io/hosted/payment";

		public const string WowpaypublicKey = @"-----BEGIN PUBLIC KEY-----
                                                XXX
                                                -----END PUBLIC KEY-----";

		public const string Wowpayprivatekey = @"-----BEGIN RSA PRIVATE KEY-----
                                               XXX
                                                -----END RSA PRIVATE KEY-----";

		public const string MerchantId = "";

		public const string MerchantCode = "";

		public const string UserName = "";

		public const string Password = "";

		public const string ProductCode = "ANY";

		public const string Country = "ALL";

		public const string InputVector = "";


	}

	

	public static class ContentTypes
	{
		public const string Json = "application/json";
		public const string UrlEncode = "application/x-www-form-urlencoded";
		public const string Xml = "application/xml";
		public const string Plain = "text/plain";
		public const string Html = "text/html";
		public const string MultiPart = "multipart/form-data";
	}
}
