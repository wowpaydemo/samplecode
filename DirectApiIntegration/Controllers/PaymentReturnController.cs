using Microsoft.AspNetCore.Mvc;
using Utility.Helpers;
using Utility.Models;

namespace DirectApiIntegration.Controllers
{
    public class PaymentReturnController : Controller
    {
        [Route("/paymentrs/returnurl")]
        public IActionResult ReturnUrl(PaymentResponse paymentResponse)
        {
			PaymentRs paymentRs = ProcessPaymentResonse(paymentResponse);

            return View(paymentRs);
        }

        [Route("/paymentrs/callbackurl")]
        public IActionResult CallBackUrl(PaymentResponse paymentResponse)
        {
            return View();
        }


        private PaymentRs ProcessPaymentResonse(PaymentResponse paymentResponse)
        {
            string decryptedPassword = EncryptionHelper.DecryptRandomPassword(paymentResponse.EncValue, ConstantKeys.Wowpayprivatekey);

            string responseJson = EncryptionHelper.DecryptJson(paymentResponse.PaymentRS, decryptedPassword, ConstantKeys.InputVector);

            PaymentRs? paymentRs = SerializationHelper.Deserialize<PaymentRs>(responseJson);
            
            if(paymentRs!=null && paymentRs.PaymentRsInfo != null)
            {
                string signatureinput = paymentRs.PaymentRsInfo.TxnStatus + paymentRs.PaymentInfo.TxnAmount.ToString("#0.00") + paymentRs.PaymentInfo.MerchantTxnId +
								paymentRs.PaymentInfo.TxnCurrency + paymentRs.PaymentRsInfo.ApprovalCode;

				string signature = EncryptionHelper.CreateSha512Hash(signatureinput.ToUpper());

                if(signature != paymentRs.PaymentRsInfo.Signature)
                {
                    //it should be matched
                }
            }

            return paymentRs;
        }
    }
}
