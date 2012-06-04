## Set up your environment

This section explains how to prepare your development environment to start working with the Bluevia .NET SDK. 
First check out the system requirements that your computer must meet, and then follow the installation steps. 
Once you have finished you will be able to develop your first .NET application using the functionality provided by Bluevia APIs.

### System requeriments

.NET SDK is the only library required from Bluevia 1.6 version. 
The following system requirements are the ones your computer needs to meet to be able to work with the .NET SDK:

Tested Operating Systems:

	- Windows XP (32-bit or 64-bit).
	- Windows 7 (32-bit or 64-bit).

Developing environment:

	- Microsoft Visual Studio 2010.
  
The following Framework are required:
 
	- .NET Framework 4 Client Profile.

### Step 1: Preparing the .NET environment
The first step to start developing applications is setting up your .NET environment. 
If you have already prepared your computer to develop .NET Framework 4 applications you can skip to step 2; 
otherwise follow the next instructions:

	- Prepare your development computer and ensure it meets the system requirements.
	- Install .NET Framework 4.
	- Microsoft Visual Studio 2010.

### Step 2: Download Bluevia library for .NET and create the project

	- Download the library from : "https://github.com/BlueVia/Official-Library-.Net"
	- Create your .NET Project in VS 2010: select File > New > Project. 
	- ".Net Framework 4" at the selector field.
	- Fill the "Name", "Location" and "Solution Name" fields.
	
  
### Step 3: Setting the include path:
  
  Include the Bluevia Library into the references:
	- Right click over "References" in the "Solution Explorer" and select "Add Reference...".
	- At the "Browse" label, look for the  " /lib" directory, and select "Bluevia.dll" and "Microsoft.Contracts.dll".
	- Click "OK".


## Code samples 
You can find a set of complete sample apps on this repository:
	-  "https://github.com/BlueVia/Official-Library-.Net/tree/master/samples"

Please find below also some quick snippets on how to use the library.


### OAuth proccess negotiation
Most of the APIs need have passed a complete OAuth process once before starting to use them because they will act on behalf a customer (OAuth 3-leggded mode);
 others, like receiving messages ones, don't need that process (OAuth 2-legged mode). 
 The advertising API, could be used both as 3-legged and as 2-legged.

#### Step 1: Get application keys (consumer keys).
You can get your own application keys for you app at [BlueVia] (https://bluevia.com/en/page/tech.howto.tut_APIkeys).

#### Step 2: Init oauth process: Do a request tokens
BlueVia APIs authentication is based on [OAuth 1.0](https://bluevia.com/en/page/tech.howto.tut_APIauth)
To get the users authorization for using BlueVia API's on their behalf, you shall do as follows.
By using your API key, you have to create a request token that is required to start the OAuth process. For example:

  // Create the client (you have to choose the mode (LIVE|SANDBOX|TEST) and include the Consumer credentials)
  BV_OAuth oauthClient = new BV_OAuth(BVMode.LIVE, "my_consumer_key", "my_consumer_secret");
  // Retrieve the request token
  RequestToken requestToken = oauthClient.GetRequestToken();

#### Step 3: User authorisation

There are three alternatives to request the user authorisation:

  - Callback authorisation

  Callback parameter is  a defined callback URL. You will receive the oauth_verifier as a request parameter at your callback.
  // Retrieve the request token
  oauthClient.GetRequestToken("http://foo.bar/bluevia/get_access");

The user must be redirected to the Bluevia's verification Url, so he can authorize the application. 
Once he has finished, he will be redirect again to the application so he can complete the OAuth's proccess. 
Your application will recieve the oauth_verifier in the url as a query string. 

  - OutOfBand authorisation
To get user authorization using the oauthToken from your request token you have to take the user to BlueVia.

// Retrieve the request token
  oauthClient.GetRequestToken();
  
The obtained request token contains the verification url to access to the BlueVia portal. 
Depending on the mode used, it will be available for final users (LIVE) or developers (TEST and SANDBOX). 
The application should enable the user (customer) to visit the url in any way, where he will have to introduce its credentials (user and password) 
to authorise the application to connect BlueVia APIs behalf him. 
Once permission has been granted, the user will obtain a PIN code necessary to exchange the request token for the access token.
Once the user confirms the authorization, you have to ask the user to enter the oauth_verifier in your app. 
Note that your users will need to copy and paste the oauth_verifier manually, so be clear when you request it to be sure they do not get confused.

  - SMSOauth authorisation
Bluevia supports a variation of OAuth process where the user is not using the browser to authorize the application. 
Instead he will receive an SMS containing he PIN code (oauth_verifier). 
To use this SMS handshake, getRequestToken request must pass the user's MSISDN (phone number) in callback parameter. 
After the user had received the PIN code, the application should allow him to enter it and request the access token.
  // Retrieve the request token
  oauthClient.GetRequestTokenSMSHandshake("34609090909");

#### Step 4: Get access tokens
With the obtained PIN code (oauth_verifier), you can now get the accessToken from the user as follows:
  //Obtain the access token
  Token accessToken = oauthClient.getAccessToken(oauth_verifier,requestToken.key,requestToken.secret);

Both token and token_secret must be saved in your application because OAuth process will require it later.


### Payment API
Payment API enables your application to make payments behalf the user to let him buy products or pay for services, and request the status of a previous payment.
Bluevia Payment API uses an extension of OAuth protocol to guarantee secure payment operations. 
For each payment the user makes he must complete the OAuth process to identify itself and get a valid acess token. 
These tokens will be valid for 48 hours and then will be dismissed.
First, you have to retrieve a request token to be authorised by the user. 
In this case you have to use the RequestToken object, which includes the digital good pricing besides the usual request tokens params:
  BV_Payment paymentClient = new BV_Payment(BVMode.LIVE, "consumer_key", "consumer_secret");
  RequestToken requestToken = paymentClient.GetPaymentRequestToken(100, "GBP", serviceName, serviceId);

Note that the callBackUrl is an optional value, you can set it to null if your application is not able to recieve request from BlueVia.
Typically websites set a callBackURL and desktop or mobile applications don't.
Then, take the user to BlueVia Connect to authorise the application as usual.
Once you have obtained the oauth_verifier, you can now get the accessToken as follows:
  Token accessToken = paymentClient.GetPaymentAccessToken(verifier, requestToken.key,requestToken.secret); /* Get verifier from GUI */

In order to execute the payment operations:
	PaymentResult paymentResult = paymentClient.Payment(amount, currency);	
	PaymentStatus paymentStatus = paymentClient.GetPaymentStatus(paymentResult.transactionId);
	bool tokenCancelled = paymentClient.CancelAuthorization();
	
### Send SMS and get delivery status
SMS API allows your app to send messages on behalf of the users, this means that their mobile number will be the text sender and they will pay for them.

#### Sending SMS
  BV_MTSMS smsClient = new BV_MTSMS(BVMode.LIVE, "my_consumer_key","my_consumer_secret","token", "token_secret");
  // Send the message.
  string smsId = smsClient.send(destination, text);

Your application can send the same SMS to several users including an array with multiple destinations.
  // Add multiple destinations.
  string[] destination = new string[]{"44123456789","4490090009000"};
  
Take into account that the recipients numbers are required to included the international country calling code.

#### Checking delivery status
After sending an SMS you may need to know if it has been delivered. 
You can poll to check the delivery status.This alternative is used typically for mobile applications without a backend server.
You need to keep the deliveryStatusId to ask about the delivery status of that SMS as follows:
  DeliveryInfo[] status = smsClient.GetDeliveryStatus(smsId);  

### Send MMS and get delivery status 
MMS API enables your application to send an MMS on behalf of the user, check the delivery status of a sent MMS and Receive an MMS on your application.

#### Sending MMS
  BV_MTMMS mmsClient = new BV_MTMMS(BVMode.LIVE, "my_consumer_key","my_consumer_secret", "accessToken", "accessTokenSecret");
  Several attachments could be attached to the MMS message. The class that represent multipart attachment is Attachment:

  // Create the Attachment object
  Attachment attachment = new Attachment("/path/to/image/image.gif",MIMEType.gif);


  // Send the message.
  string mmsId = mmsClient.Send(destination,subject,text,attachments);

Your application can send the same MMS to several users including an array with multiple destinations.
  // Add multiple destinations.
  string[] destination = new string[]{"44123456789","4490090009000"};

#### Checking delivery status
After sending an MMS you may need to know if it has been delivered.
You can poll polling to check the delivery status. This alternative is used typically for mobile applications without a backend server.
You need to keep the deliveryStatusId to ask about the delivery status of that MMS as follows:
  DeliveryInfo[] status = mmsClient.GetDeliveryStatus(smsId);  

### Receive SMS 
You can can retrieve the SMS sent to your app using OAuth-2-legged auhtorisation so no user access token is required.
  BV_MOSMS smsMo = new BV_MOSMS(BVMode.LIVE, "my_consumer_key","my_consumer_secret");

Your application can receive SMS from users sent to [BlueVia shortcodes]
(http://bluevia.com/en/page/tech.overview.shortcodes) including your application keyword. 
You have to take into account that you will need to remember the SMS keyword you defined when you requested you API key.

You can grab messages sent from users to you app as follows:
  string registrationId = "553456"
  SMSMessage[] smsInfo = smsMo.GetAllMessages(registrationId);

Note that this is just an example and you should implement a more efficient polling strategy.

### Receive MMS 
You can can retrieve the MMS sent to your app using OAuth-2-legged auhtorisation so no user access token is required.
  BV_MOMMS mmsClient = new BV_MOMMS(BVMode.LIVE, "my_consumer_key","my_consumer_secret");

Your application can receive MMS from users sent to [BlueVia shortcodes]
(http://bluevia.com/en/page/tech.overview.shortcodes) including your application keyword. 
You have to take into account that you will need to remember the MMS keyword you defined when you requested you API key. 

You can grab messages sent from users to you app as follows. 
The ReceivedMmsInfo object contains the information of the sent MMS, but the attachments. 
In order to retreive attached documents in the MMS you have to use the getMessage function, which needs the messageIdentifier available in the ReceivedMmsInfo object. 
The returned ReceivedMms object contains the info of the Mms itself and a list of MimeContent objects with the content of the attachments:
  string registrationId = "553456"
  MMSMessageInfo[] list = mmsClient.GetAllMessages(registrationId);   
  foreach (var message in MMSMessageInfo){         
    MMSMessage  mms = mmsClient.getMessage(registrationId, message.messageId);
    //Print the info as you wish
    foreach(var attach in mms.attachments){
      // You can save on do any stuff with the attachments
    }
  }
Note that this is just an example and you should implement a more efficient polling strategy


### User Context API
User Context API enables your application to get information about the user's customer profile in order to know more about your users to targetize better your product.

  // Create the Directory Client
  BV_Directory directoryClient= new BV_Directory(BVMode.LIVE, "my_consumer_key","my_consumer_secret","token", "token_secret");

#### Getting Profile Information
  ProfileInfo profile = directoryClient.GetProfile();

#### Getting Access Information
  AccessInfo accessInfo = directoryClient.GetAccessInfo();

#### Getting Device Information
  TerminalInfo terminalInfo = directoryClient.GetTerminalInfo();

#### Filters
If you want to configure a filter on the information relevant for your application you can do it for any of the requests above:

  ProfileInfoFields[] fields = array(ProfileInfoFields.userType, ProfileInfoFields.parentalControl, ProfileInfoFields.operatorId);
	
  //Get the Profile
  ProfileInfo profile = directoryClient.GetProfile(fields);

#### Getting all User Information

  UserInfo info = directoryClient.GetUserInfo();

### Location API
Location API enables your application to retrieve the geographical coordinates of user. 
These geographical coordinates are expressed through a latitude, longitude, altitude and accuracy.

The acceptableAccuracy (optional) parameter expresses the range in meters that the application considers useful. 
If the location cannot be determined within this range, then the application would prefer not to receive the information.

  BV_Location locationClient = new BV_Location(BVMode.LIVE, "my_consumer_key","my_consumer_secret","token", "token_secret");
  int acceptableAccuracy = 500;
  LocationInfo location = locationClient.GetLocation(acceptableAccuracy);

### Advertising API
Adverstising API enables your application to retrieve advertisements. 

You can invoke this API using a 3-leddged client (ouath process passed) or a 2-legged client. This is selected in the client instantiating.
Once configured your client is ready to get advertisements.
 When retrieving a simple advertisement you can specify a set of request parameters such as banner size, protection policy, etc.
 Mandatory parameters are adSpace, that is the identifier you obtained when you registered your application within the Bluevia portal; 
 and protectionPolicy. The adRequetsId is an optional parameter (if it is not supplied, the SDK will generate one). 
 For a more detailed description please see the API Reference.
 
  BV_Advertising adClient = new BV_Advertising(BVMode.LIVE, "my_consumer_key","my_consumer_secret","token", "token_secret");
  SimpleAdResponse response = adClient.getAdvertising(adSpace, adId, AdPresentation.image, null, ProtectionPolicy.safe);

Take into account that the Protection Policy sets the rules for adult advertising, please be careful.
  ProtectionPolicy.LOW 	Low, moderately explicit content (I am youth; you can show me moderately explicit content).
  ProtectionPolicy.SAFE 	Safe, not rated content (I am a kid, please, show me only safe content).
  ProtectionPolicy.HIGH 	High, explicit content (I am an adult; I am over 18 so you can show me any content including very explicit content).