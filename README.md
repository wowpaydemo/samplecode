# samplecode

This solution"WowpaySample" contains 2 projects.

1.DirectApiIntegration
    
    
    Merchant's should share their PCI DSS certificate with us.
    
    Merchants whoever wants to show the paymentmethods and channels on their checkout page, they can choose this integration type.    
    
    The first request to wowpay is to get the payment methods and channels based on the currency,country ...
    
    Show the payment options their users and allow them to choose the payment and enter the required details such as card details.
    
    Build the payment request and encrypt it as per the document and then submit to wowpay and handle the response returned to the return and callback urls.
  
2.HostedPage

  When the merchant's chooses hosted payment page integration, no need to worry about the PCI compliance.
  
  Merchants whoever wants to use wowpay's payment page to show the paymentmethods and channels ,they can choose this integration type.
  
  Generate a signature as per the document for the message integrity and submit the request to wowpay and then handle response returned to the return and callback urls.
