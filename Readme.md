## Introduction ##
Bluevia’s .NET SDK” allows you to use the BlueVia’s public API from your .NET application using just a few lines of code. You only need to download the SDK, reference the BlueVia libraries into your solution, create API keys for it, and use all the BlueVia's functionality in an easy way.

BlueVia offers you:

- SMS and MMS sending, receiving and monitoring.
- Advertise requesting. </li>
- User's related info receiving. </li>

More info:
[https://bluevia.com/en/knowledge/APIs](https://bluevia.com/en/knowledge/APIs)

This SDK contains:

- doc\
    - html\
- lib\
    - Bluevia.dll
    - DotNetOpenAuth.dll
- src\ 
    - libraries\
    - Telefonica\
    - Example\
    - Bluevia.sln
LICENSE.txt</ul>

### SDK Overview: ###

Supported Operating Systems:

- Windows XP (32-bit or 64-bit).
- Windows Vista (32-bit or 64-bit).
- Windows 7 (32-bit or 64-bit).

Environment needed:

- .NET Framework 4
- Microsoft Visual Studio 2010

### Using Bluevia is easy: ###

First: Configure your data.

    Bluevia.Core.Configuration.Client.setConsumer("Your_consumer_key");
    Bluevia.Core.Configuration.Client.setConsumerSecret("Your_consumer_secret"); 
    
Second: Create a Bluevia Client. 

    BlueviaClient client = new BlueviaClient(); 
    
Third: Create a Request over the Client.

    IBlueviaClient request = client.CreateRequest(); 
    
Fourth: Authenticate if necessary. 
    
    Bluevia.Core.Configuration.Client.setTokenPair("AccessToken", "SecretToken");
    IBlueviaClient authenticatedRequest = request.AuthenticateClient();    
    
Deprecated Method:

    IBlueviaClient authenticatedRequest = request.AuthenticateWith("Your_Access_Token");
    
Fifth: Make the desired petition. Note that the 2 legged Oauth petition don’t need an authenticated request. And will work, only if the application has been registered for this purpose. So an App could only be registered for 2legged or 3legged functionality exclusively.

- 2LeggedOauth mode: 

        try 
        {   
            var response = request.API.Primitive.Send(Data);
        }
        catch (Exception e) { }

- 3LeggedOauth mode:

        try
        {
             var response = authenticatedRequest.API.Primitive.Send(Data);
        }
        catch (Exception e) { }

**Endpoints:** BlueVia has two endpoints, commercial and sandbox. Commercial is linked to Telefonica network, and sandbox is used just to verify application behavior (read the COMMON area to learn how to change it).


### OAuth: ###
User authentication is launched using OAuth protocol, so user is not required to use credentials in third party applications. If you want to learn more about OAuth please check: 

- [https://bluevia.com/en/knowledge/APIs.API-Guides.OAuth](https://bluevia.com/en/knowledge/APIs.API-Guides.OAuth) 
- [http://oauth.net](http://oauth.net)

We retrieve two parameters, Token and Token_Secret that will be used during the OAuth process. Both token and token_secret must be saved by the application provider cause OAuth process will require it later in almost every petition to the endpoints.

Once the user is authenticated and has authorized the application in BlueVia portal, he should be redirected to the URL used as parameter. Now it's time to fetch the valid token and token secret that shall identify the new user during any call to BlueVia API.

### Using the API´s: ###

Most of requests when accessing Bluevia API are associated to a specific user, so when a BlueviaClient object is created both user token and user token secret must be provided to identify user on behalf of whom the application wants to access BlueVia APIs. 

NOTE: From here, fields marked with "*" constructing objects or calling methods, means that are optional parameters.

## COMMON: ##

### Objects: ###

OAuth Token pair:

    Bluevia.Core.Schemas.OAuthToken OAuthToken = new Bluevia.Core.Schemas.OAuthToken("accessToken","accessTokenSecret");

### Methods: ###

Storing the AccessToken, and the AccessTokenSecret:

First mode: 

    Bluevia.Core.BlueviaConsumer.TokenManager.StoreNewRequestToken("accessToken","accessTokenSecret");

Second mode: 

    Bluevia.Core.BlueviaConsumer.TokenManager.StoreNewRequestToken(OAuthToken);

Third mode: 

    Bluevia.Core.Configuration.Client.setTokenPair("AccessToken", "SecretToken");

Setting environmental data:

    Bluevia.Core.Configuration.Client.setTokenPair("AccessToken", "SecretToken");
    Bluevia.Core.Configuration.Client.setConsumer("Your_consumer_key");
    Bluevia.Core.Configuration.Client.setConsumerSecret("Your_consumer_secret");
    Bluevia.Core.Configuration.Client.setTimeout(int);
    
    //Sandbox mode
    Bluevia.Core.Configuration.Client.setSandbox(true);
    Bluevia.Core.Configuration.Client.setEnvironment("_Sandbox");
    
    //Commercial mode
    Bluevia.Core.Configuration.Client.setSandbox(false);
    Bluevia.Core.Configuration.Client.setEnvironment("");

## OAuth: ##


### Objects: ###

Create OAuth Token pair: 

    Bluevia.Core.Schemas.OAuthToken OAuthToken = new Bluevia.Core.Schemas.OAuthToken("accessToken","accessTokenSecret");


### Methods: ###

Requesting valid tokens for the application:

First Step:
    
    var request = request.OAuth.RequestToken.Get(callbackUrl: "callbackUrl"*);
    
Second Step: As explained in: [https://bluevia.com/en/knowledge/APIs.API-Guides.OAuth](https://bluevia.com/en/knowledge/APIs.API-Guides.OAuth) there are two ways to receive the verification code:

- If you want to receive the verification code by SMS, you must make the First Step with your MSISDN at the callback parameter.
- If you prefer to receive the code by http from Bluevia server, the First Step must be done with a callback parameter. And at the end of "connect.bluevia" process, you will be redirected to: 
    `http://localhost/?oauth_verifier=Verification_Code&amp;oauth_token=your_given_requested_token`.        

The "connect.bluevia" process must be done after making the First Step by login into `https://connect.bluevia.com/authorise`, and then, go to `https://connect.bluevia.com/authorise?oauth_token=your_given_requested_token`. Accept all the terms, and finally press: Return BlueVia App.

Third Step:

    var access = request.OAuth.AccessToken.Get(request, "Verification_Code");


## ADVERTISING: ##

The Bluevia Advertising API is a set of functions which allows users to provide advertising based on different advertisement types such as images or texts or similar elements within their applications. More Info: [https://bluevia.com/en/knowledge/APIs.API-Guides.Advertising](https://bluevia.com/en/knowledge/APIs.API-Guides.Advertising)

### Objects: Creating a request object: ###

    Bluevia.SGAP.SimpleAdRequest adRequest = new SimpleAdRequest(adRequestId, adSpace, 
        userAgent, protectionPolicy, adRequestId*,targetUserId*,"country"*, adPresentationSize*);
    
    
### Methods: Requesting an advertising: ###

- 2LeggedOauth mode: - 2LeggedOauth mode: 

        var response = request.SGAP.AdRequest.Send(adRequest,true);

- 3LeggedOauth mode: 
    
        var response = authenticatedRequest.SGAP.AdRequest.Send(adRequest,false);


## DIRECTORY: ##

The Bluevia Directory API is a set of functions which allows users to retrieve user-related information, divided in three blocks (user profile, access information and user terminal information). More Info:

[https://bluevia.com/en/knowledge/APIs.API-Guides.GetUserInformation](https://bluevia.com/en/knowledge/APIs.API-Guides.GetUserInformation)

### Methods:###

- Getting user profile:
    - First mode:

                var response = authenticatedRequest
                .Directory.ProfileInfo.Get();

    - Second mode:

                var response = authenticatedRequest
                .Directory.ProfileInfo.Get(Directory.Schemas.ProfileFields.field | 
                                           Directory.Schemas.ProfileFields.field …);

- Getting user access info:
    - First mode:
    
                var response = authenticatedRequest
                .Directory.AccessInfo.Get();

    - Second mode:

                var response = authenticatedRequest
                .Directory.AccessInfo.Get(Directory.Schemas.AccessInfoFields.field);

- Getting user terminal info:
    - First mode:

                var response = authenticatedRequest
                .Directory.TerminalInfo.Get();

    - Second mode:

                var response = authenticatedRequest
                .Directory.TerminalInfo.Get(Directory.Schemas.TerminalInfoFields.field | 
                                            Directory.Schemas.TerminalInfoFields.field);




## LOCATION:##

The Bluevia Location API provides access not just to the geographical coordinates of a terminal where Location is expressed through a latitude, longitude, and accuracy. The operations cover the requesting for the location of a terminal or a group of terminals. More Info: 

[https://bluevia.com/en/knowledge/APIs.API-Guides.Location](https://bluevia.com/en/knowledge/APIs.API-Guides.Location)

### Objects:###

Creating a TerminalLocationRequestParams object:

    Bluevia.Location.Schemas.TerminalLocationParams tlp = new TerminalLocationParams();
    tlp.AcceptableAccuracy = “Acceptable Accuracy”;*

### Methods:###

Getting Location Info: 

    var response = authenticatedRequest
    .Location.TerminalLocation.GetLocation(tlp);


## MMS: ##
The Bluevia MMS API is a set of functions which allows users to send and receive MMS messages and request the status of those previously sent messages. Also you can subscribe notifications to your own server. In must be considered that the available Content-Types, MMS can carry are (as named in MMS/Schemas/MMSContentTypes.cs): 
*text/plain. image/jpeg, image/bmp, image/gif, image/png. audio/amr, audio/midi, audio/mp3, audio/mpeg, audio/wav. video/mp4, video/avi, video/3gpp*. 300KB as much, for good performance. More Info:

[https://bluevia.com/en/knowledge/APIs.API-Guides.MMS](https://bluevia.com/en/knowledge/APIs.API-Guides.MMS)

### Objects:###

- Creating a message object:

        Bluevia.MMS.Schemas.MessageType message = new Bluevia.MMS.Schemas.MessageType
            (new string[] {"Destination 1","Destination 2"...    },"Message text"*);

- Creating a FileAttachment object:

        Bluevia.Core.Schemas.FileAttachment file = new Bluevia.Core.Schemas.FileAttachment
            ("PathToFile", MMS.Schemas.MMSContentTypes.type);

- Creating a StreamAttachment object: 

    - First mode: 
        
            Bluevia.Core.Schemas.StreamAttachment stream = new Bluevia.Core.Schemas.StreamAttachment    
                (byte[] data, MMS.Schemas.MMSContentTypes.type, string fileName);

    - Second mode:
    
            Bluevia.Core.Schemas.StreamAttachment stream = new Bluevia.Core.Schemas.StreamAttachment
                (System.IO.MemoryStream data, MMS.Schemas.MMSContentTypes.type, string fileName);

- Creating a MessageNotification object: </ul>

            Bluevia.MMS.Schemas.MessageNotificationType notificationObject = new Bluevia.MMS.Schemas.MessageNotificationType()
                {reference = new MMS.Schemas.SimpleReferenceType() {correlator,endpoint} ,destinationAddress, criteria};

### Methods: ###

- Sending MMS:
    - First mode:

            var response = authenticatedRequest
            .MMS.MessageMT.Send(message, new FileAttachment[] {File, File …}*);

    - Second mode:

            var response = authenticatedRequest
            .MMS.MessageMT.Send(message,StreamAttachment[] streamAttachments);
    - Third mode:

            var response = authenticatedRequest
            .MMS.MessageMT.Send(new string[] { "Address", " Address"...}, " mmsSubject", new FileAttachment[] {File, File …}*);

- Getting Status:

        var response = authenticatedRequest
        .MMS.MessageMT.GetStatus("messageId","Status"*);

- Retrieving MMS Id:

        var response = authenticatedRequest
        .MMS.MessageMO.GetMessages("registrationId");

- Getting MMS:

        var response = authenticatedRequest
        .MMS.MessageMO.GetMessage("registrationId","messageId");

- Subscribe Notifications:

        var response = authenticatedRequest
        .MMS.NotificationManager.Subscribe(notificationObject);

- Unsubscribe Notifications:

        var response = authenticatedRequest
        .MMS.NotificationManager.UnSubscribeNotification("notificationId");


## PAYMENT: ##
The Bluevia PAYMENT API is a set of functions which allows individual, atomic payments based on input purchase information with economic data.

You must consider that the Oauth Token model changes for the Payment API:

Usually, you only have to request one Token Pair for your whole application.

But in the Payment case, a new special temporal Token Pair must be requested for each "payment request". And will be only usefull for that payment request and its relatives operations, "cancel authorization request", "get status request"...

I.E.: If you want to make a payment: First of all you must request a new pair of RequestTokens in the "payment way". After that you have to retrieve the AccessTokens as always. 

Next Step is to store that AccessTokens, and once stored, you can cancel it (with cancelAuthorization method), or make the payment. 

If you finally decide to make the payment(with payment method), you can get the status or request notifications (if the country permits asinchronus payments), with the same Tokens. But, if you want to make another payment, you have to request a new pair of tokens for it.  More Info:

[https://bluevia.com/en/knowledge/APIs.API-Guides.Payment](https://bluevia.com/en/knowledge/APIs.API-Guides.Payment)

### Objects: ###

- Creating a ServiceInfo object: This object must be included in the RequestToken (payment's for) requets.

        Bluevia.OAuth.Schemas.ServiceInfo serviceInfo = Bluevia.OAuth.Schemas.ServiceInfo();
        serviceInfo.name = name;//of the service
        paymentInfo.serviceID = string;

- Creating a PaymentInfoType object: This object must be included in the RequestToken (payment's for) requets, and in the PaymentParamsType object for the payment request.

        Bluevia.Payment.Schemas.PaymentInfoType paymentInfo = Bluevia.Payment.Schemas.PaymentInfoType();
        paymentInfo.amount = int;//the last digits will be the currency cents
        paymentInfo.currency = string;//"EUR","GBP",...

- Creating a PaymentParamsType object

        Bluevia.Payment.Schemas.PaymentParamsType paymentParams = Bluevia.Payment.Schemas.PaymentParamsType();
        paymentParams.paymentInfo = paymentInfo;

- Creating a GetPaymentStatusParamsType object:

        Bluevia.Payment.Schemas.GetPaymentStatusParamsType paymentStatusParams =        
            Bluevia.Payment.Schemas.GetPaymentStatusParamsType();
        paymentStatusParams.transactionId = string;

### Methods: ###

- Requesting RequestTokens for payment use:

        var response = request 
        .OAuth.RequestToken.Get(paymentInfo, serviceInfo, "callbackUrl"*);

- Payment:

        var response = authenticatedRequest
        .Payment.AmountCharging.Payment(paymentParams);

- Cancel Authorization tokens:

        var response = authenticatedRequest
        .Payment.AmountCharging.CancelAuthorization();

- Getting the payment status:

        var response = authenticatedRequest
        .Payment.AmountCharging.GetPaymentStatus(paymentStatusParams );

## SMS:##

The Bluevia SMS API is a set of functions which allows users to send and receive SMS messages and request the status of those previously sent messages. Also you can subscribe notifications to your own server. More Info:

[https://bluevia.com/en/knowledge/APIs.API-Guides.SMS](https://bluevia.com/en/knowledge/APIs.API-Guides.SMS)

### Objects: ###

- Creating a message object:

        Bluevia.SMS.Schemas.SMSTextType message = new Bluevia.MMS.Schemas.MessageType
            (new string[] {"Destination 1", "Destination 2"...},"Message text"*);

- Creating a MessageNotification object:

        Bluevia.SMS.Schemas.SMSNotificationType notification = new SMS.Schemas.SMSNotificationType()
            {reference = new SMS.Schemas.SimpleReferenceType(){correlator, endpoint}, destinationAddress, criteria};


### Methods: ###

- Sending SMS:
    - First mode:
            var response = authenticatedRequest
            .SMS.MessageMT.Send(new string[] {"Destination 1","Destination 2"...    },"Message text");
    - Second mode:
            var response = authenticatedRequest
            .SMS.MessageMT.Send(message);

- Getting Status:
 
        var response = authenticatedRequest
        .SMS.MessageMT.GetStatus("messageId", "status"*);

- Getting SMS:

        var response = authenticatedRequest
        .SMS.MessageMO.GetMessages("registrarionId");

- Subscribe Notifications:

        var response = authenticatedRequest
        .SMS.NotificationManager.Subscribe(notification);

- Unsubscribe Notifications:

        var response = authenticatedRequest
        .SMS.NotificationManager.UnSubscribeNotification("notificationId");
