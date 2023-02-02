using Microsoft.AspNetCore.Mvc;
using Utility.Helpers;
using Utility.Models;

namespace DirectApiIntegration.Controllers
{
    public class PaymentController : Controller
    {
		private static string Currency = "SGD";

		public async Task<IActionResult> ShowPayment()
        {
            var options = await GetPaymentOptionsAsync();

            return View(options);
        }


        [HttpPost]
        public IActionResult DoPayment(SelectedPayment selectedPayment)
        {
            SubmitPayment submitPayment = new SubmitPayment
            {
                PaymentUrl = selectedPayment.PaymentUrl,

                ParameterCollection = BuildPaymentRequest(selectedPayment)
            };

            return View(submitPayment);
        }


        /// <summary>
        /// To get the payment methods and channles for the given credentials and country,product,currency
        /// </summary>
        /// <returns></returns>
        private async Task<PaymentOptionRs> GetPaymentOptionsAsync()
        {
            //Replace the credentials in ConstantKeys with your credentials

            PaymentOptionRq optionRq = new PaymentOptionRq
            {
                MerchantId = new Guid(ConstantKeys.MerchantId),
                MerchantCode = ConstantKeys.MerchantCode,
                UserName = ConstantKeys.UserName,
                Password = ConstantKeys.Password,
                ProductCode = ConstantKeys.ProductCode,
                Country = ConstantKeys.Country,
                Currency = Currency//use your actual transaction currency
            };

            string? rs = await HttpHelper.RequestAsync(ConstantKeys.SandboxPaymentOptionEndpoint, optionRq.ToString(), HttpMethod.Post);

            PaymentOptionRs? paymentOptionRs = string.IsNullOrEmpty(rs) ? null : SerializationHelper.Deserialize<PaymentOptionRs>(rs);

            return paymentOptionRs!;
        }

        private IDictionary<string, string> BuildPaymentRequest(SelectedPayment selectedPayment)
        {

            PaymentRq paymentRq = new PaymentRq
            {
                ReturnUrl = "https://localhost:7038/paymentrs/returnurl",
                CallBackUrl = "https://localhost:7038/paymentrs/callbackurl",
                Signature = "",

                PaymentInfo = new PaymentInfo
                {
                    IsStoreCardInfo = false, //This is tokenization,if creditcard payment, merchant allow wowpay to store the card details for their future transactions then it should be 'true'

                    CustomerId = "",///This is tokenization,if creditcard payment, merchant allow wowpay to store or reuse the existing card,then it should have the customerid to store the card or fetch the existing card.
                    CardToken = "",//if any card tokenized already for this customer and he chooses any existing card then cardtoken should be passed. READ MORE ABOUT TOKENIZATION                                       


                    MerchantRefNo1 = DateTime.Now.ToString("ddMMyyHHmmsstt"),
                    MerchantTxnId = $"DEMO{DateTime.Now:ddMMyyHHmmsstt}",
                    TxnAmount = 100,
                    TxnCurrency = Currency,
                    PaymentId = selectedPayment.PaymentId,
                    CardInfo = !string.IsNullOrEmpty(selectedPayment.CardNo) ? new CardInfo { CardNo = selectedPayment.CardNo, ExpMonth = selectedPayment.ExpMonth, ExpYear = selectedPayment.ExpYear, NameontheCard = selectedPayment.NameontheCard } : null,

                },
                OrderInfo = new OrderInfo
                {
                    OrderDesc = "Demo Order",
                    ItemList = new List<ItemInfo>
                    {
                        new ItemInfo
                        {
                            ItemAmount = 100,
                            ItemCode = "001",
                            ItemName = "Demo Item",
                            Itemtype = ItemType.GeneralCheckOut
                        }
                    }
                },
                CustomerInfo = new List<CustomerInfo>
                {
                    new CustomerInfo
                    {
                        FirstName = "Demo Customer",
                        LastName = "Name",
                        Email = "customer@demo.com",
                        Mobile = "0909099009",
                        Address = "street1",
                        PostCode = "630098",
                        City = "Singapore",
                        Country = "SG"
                    }
                },
                DeviceInfo = new DeviceInfo
                {
                    UserAgent = Request.Headers["User-Agent"]!,
                    AcceptHeader = Request.Headers["Accept"]!,
                    AcceptLanguage = Request.Headers["Accept-Language"]!
                }
            };

            string combination = $"{paymentRq.PaymentInfo.TxnCurrency}{paymentRq.PaymentInfo.TxnAmount:#0.00}{paymentRq.PaymentInfo.MerchantTxnId}";

            paymentRq.Signature = EncryptionHelper.CreateSha512Hash(combination.ToUpper());

            string randomPass = EncryptionHelper.GenerateRandomPassword();

            var enryptedRandomPass = EncryptionHelper.EncryptRandomPassword(randomPass, ConstantKeys.WowpaypublicKey);

            string jsonRq = SerializationHelper.Serialize(paymentRq);

            string encyptedrq = EncryptionHelper.EncryptJosn(jsonRq, randomPass, ConstantKeys.InputVector);

            IDictionary<string, string> dict = new Dictionary<string, string>
                            {
                                { "MerchantId",ConstantKeys.MerchantId },
                                { "EncValue",enryptedRandomPass },
                                { "PaymentRq",encyptedrq },
                                { "MerchantTxnId",paymentRq.PaymentInfo.MerchantTxnId },
                                { "IsWebRq", "false"}
                            };
            return dict;
        }
    }
}
