using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Utility.Helpers;
using Utility.Models;

namespace HostedPage.Controllers
{
    public class PaymentController : Controller
    {
        [HttpPost("/payment/request")]
        public IActionResult PaymentRq()
        {
			string OrderRed = Helper.GenerateMerchantTxnId();
			string currency = "SGD";
			decimal amount = 825;

			IDictionary<string, string> parameters = new Dictionary<string, string>
			{
					{"LANGUAGE","GB"},
					{"AMOUNT",amount.ToString()},
					{"CURRENCY",currency},
					{"EMAIL","demo@demo.io"},
					{"FIRSTNAME","Demo"},
					{"LASTNAME","Customer"},
					{"MOBILENO","+60103103103"},
					{"POSTALCODE","50470"},
					{"ADDRESS","10 KL EcoCity"},
					{"CITY","KUALA LUMPUR"},
					{"STATE","KUALA LUMPUR"},
					{"STATEMENTDESCRIPTION","Demo"},
					{"COUNTRY","SG"},
					{"CARDTOKEN",""},
					{"CUSTOMERID",""},
					{"MERCHANT_ID",ConstantKeys.MerchantId},
					{"ORDERREF",OrderRed},
					{"DESCRIPTION",$"Demo Order - {OrderRed}"},
					{"RETURNURL","https://localhost:7199/payment/return"},
					{"NOTIFYURL","https://localhost:7199/payment/callback"}
			};

			string signature = GenerateSecureHashForRequest(parameters);

			parameters.Add("SIGNATURE", signature);

			SubmitPayment submitPayment = new SubmitPayment
			{ 
				PaymentUrl = ConstantKeys.SandboxHostedPaymentEndpoint,
				
				ParameterCollection = parameters			
			};

			return View(submitPayment);
        }

        [HttpPost("/payment/return")]
        public async Task<IActionResult> PaymentRs()
        {
			IDictionary<string, string> responseParameters = await HandlePaymentResponse();

			return View(responseParameters);
        }

		[HttpPost("/payment/callback")]
		public IActionResult CallBack()
		{
			return View();
		}


		private async Task<IDictionary<string,string>>  HandlePaymentResponse()
		{

            IFormCollection form = await Request.ReadFormAsync();
					

            string signatureresponse = form["SIGNATURE"];


            string rawData = $"{form["PAYMENT_REFERENCE3"]}{form["PAYMENT_STATUS"]}{form["AMOUNT"]}{form["CURRENCY"]}{ConstantKeys.Password}";

            string signature = EncryptionHelper.CreateSha512Hash(rawData.ToUpper());

            if(signatureresponse != signature)
			{
				//handle your logic
			}

			return  form.ToDictionary(x=>x.Key,x=>x.Value!.ToString());
        }


        private string GenerateSecureHashForRequest(IDictionary<string, string> form)
		{
			string rawData = ConstantKeys.Password + form["ORDERREF"] + decimal.Parse(form["AMOUNT"]).ToString("#0.00") + form["CURRENCY"] + form["MERCHANT_ID"] + form["RETURNURL"] + form["NOTIFYURL"] + (form.ContainsKey("CUSTOMERID") ? form["CUSTOMERID"] : "");

			return EncryptionHelper.CreateSha512Hash(rawData.ToUpper());
		}

	}
}
