// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.Messaging;
using Bluevia.Core.Schemas;
using System.ServiceModel;


namespace Bluevia.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   OAuth Rest Service Builder. </summary>
    /// <remarks>   22/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class ServiceBuilder : IServiceBuilder
    {
        private readonly List<int> acceptableStatus = new List<int> ();
        private Action<IncomingWebResponse> afterCall;
        private Uri baseUri;
        private HttpQueryString queryString = new HttpQueryString ();
        private WebHeaderCollection headers = new WebHeaderCollection ();
        private List<MultipartPostPart> files = new List<MultipartPostPart> ();
        private WebMethod webMethod;
        private string accessToken;
        private Type requestType = null;
        private object requestEntity = null;
        private bool twoLeggedAuth = false;
        private bool isFormUrlEncoded = false;
        private bool isForPaymentRequest = false;
        private string callBack = "oob";
        private bool isForcedDate = false;
        private bool isForSMSHandshake = false;




        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds an acceptable status. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="value">    A variable-length parameters list containing values of valid statuses. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder AddAcceptableStatus(params int[] value)
        {
            if (value != null)
                foreach (var item in value)
                    acceptableStatus.Add(item);

            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a header to the request. Concats list of values. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="name">     The header name. </param>
        /// <param name="values">   A variable-length parameters list containing values. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder AddHeader(string name, params string[] values)
        {
            headers.Add(name, string.Concat(values));
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a query string to the uri. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="value">    A variable-length parameters list containing values of valid
        ///                         statuses. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder AddQueryString(KeyValuePair<string, string> value)
        {
            queryString.Add(value);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a query string to the uri. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="name">     The query string name. </param>
        /// <param name="value">    The query string value. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder AddQueryString(string name, string value)
        {
            queryString.Add(name, value);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a list of query string to the uri. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="values">   A variable-length parameters list containing values. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder AddQueryString(IEnumerable<KeyValuePair<string, string>> values)
        {
            queryString.Add(values);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a file to the request. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="filePath"> Full pathname of the file. </param>
        /// <param name="mimeType"> Type of the mime. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder AddFile(string filePath, string mimeType)
        {
            //var post = MultipartPostPart.CreateFormFilePart("image" + files.Count, filePath, mimeType);
            var post = Extension.SetAttachmentAsXml(filePath, mimeType);
            files.Add(post);
            return this;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a file to the request. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="attachment"> Full info of the file(Data, MimeType, FileName). </param>
        /// <returns>   ServiceBuilder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder AddFile(Bluevia.Core.Schemas.StreamAttachment attachment)
        {
            var post = Extension.SetAttachmentAsXml(attachment.Data, attachment.MimeType, attachment.FileName);
            files.Add(post);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Authenticate using access token. </summary>
        /// <remarks>   18/11/2011. </remarks>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder AuthenticateClient()
        {
            this.accessToken = Bluevia.Core.Configuration.Client.TokenAccess;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Enable x-www-form-urlencoded for OAuth</summary>
        /// <returns></returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder EnableIsFormUrlEncoded()
        {
            this.isFormUrlEncoded = true;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Enable special headers for Payment petitions</summary>
        /// <returns></returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder EnableIsForPaymentRequest()
        {
            this.isForPaymentRequest = true;
            return this;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Set the CallBack address for Requesting Tokens</summary>
        /// <returns></returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder SetCallBackUrl(string callBack)
        {
            this.callBack = callBack;
            return this;
        }


        private bool ShouldBuildXmlContent()
        {
            return (webMethod == WebMethod.Post || webMethod == WebMethod.Put) && requestEntity != null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets Callback action. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="afterCall">    Action. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder SetCallback(Action<IncomingWebResponse> afterCall)
        {
            this.afterCall = afterCall;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a base uri. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="baseUri">  URI of the base. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder SetBaseUri(string baseUri)
        {
            this.baseUri = new Uri(baseUri);
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a base uri. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="baseUri">  URI of the base. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder SetBaseUri(Uri baseUri)
        {
            this.baseUri = baseUri;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a request content as type T. </summary>
        /// <remarks>   22/04/2010. </remarks>
        ///
        /// <typeparam name="T">    Value type. </typeparam>
        /// <param name="value">    A variable-length parameters list containing values of valid
        ///                         statuses. </param>
        ///
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder SetRequestContentAsType<T>(T value)
        {
            requestType = typeof(T);
            requestEntity = value;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the request web method. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="method">   The web method. </param>
        /// <returns>   I Service Builder. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder SetMethod(WebMethod method)
        {
            this.webMethod = method;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Enable OAuth-Two-Leggs</summary>
        /// <returns></returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder EnableTwoLeggedAuth()
        {
            this.twoLeggedAuth = true;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deserialize an error. </summary>
        /// <remarks>   16/04/2010. </remarks>
        /// <param name="response"> The response. </param>
        /// <returns>   RestClient exception. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private Bluevia.Core.Schemas.BlueviaException ParseError(IncomingWebResponse response)
        {
            if (response == null) return new BlueviaException(Bluevia.Resources.CoreResources.InvalidParseRemoteException);
            try
            {
                if ((int)response.Status >= 500)
                {
                    return new Bluevia.Core.Schemas.RestClientException(response.ParseXml<Schemas.ServerExceptionType>());
                }
                else if ((int)response.Status >= 400)
                {
                    return new Bluevia.Core.Schemas.RestClientException(response.ParseXml<Schemas.ClientExceptionType>());
                }
                return new BlueviaException(Bluevia.Resources.CoreResources.InvalidHttpResponse.FormatWithInvariantCulture(response.Status));
            }
            catch (Exception)
            {
                return new BlueviaException(Bluevia.Resources.CoreResources.InvalidParseRemoteException);
            }
        }

        public string GetActiveAccessToken()
        {
            return this.accessToken;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Indicates to the service Builder when the timestamp must be copied to the body </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder ForceDate(bool date)
        {
            isForcedDate = date;
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Manages the procedure to estract the timeStamp from Oauth header, and setting into the body </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SetDate(string header)
        {
            string timestamp = header.Substring(header.IndexOf("timestamp="));

            timestamp = timestamp.Substring(timestamp.IndexOf("\"") + 1);
            timestamp = timestamp.Substring(0,timestamp.IndexOf("\""));


            
            double seconds = Convert.ToInt64(timestamp);
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0);
            date=date.AddSeconds(seconds);


                // :O 
                Payment.Schemas.PaymentParamsType paymentParams;
                Payment.Schemas.MethodCallTypeParams methodCallParams;
                Payment.Schemas.MethodCallType1 methodCall = (Payment.Schemas.MethodCallType1)requestEntity;
                methodCallParams = methodCall.@params;
                paymentParams = (Payment.Schemas.PaymentParamsType)methodCallParams.Item;
                paymentParams.timestamp = date;
                requestEntity = methodCall;
            
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Enable special header parameters for SMS Handshake request Token</summary>
        /// <returns></returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IServiceBuilder EnableIsForSMSHandshake()
        {
            this.isForSMSHandshake = true;
            return this;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Request / Response call. </summary>
        ///
        /// <remarks>   22/04/2010. </remarks>
        ///
        /// <exception cref="ParseError">       Thrown when parse error. </exception>
        /// <exception cref="BlueviaException">   Thrown when Bluevia </exception>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Call()
        {
            WebConsumer consumer;
            MessageReceivingEndpoint endpoint;
            HttpWebRequest request;
            IncomingWebResponse response = null;
            IDirectWebRequestHandler requestHandler;
            try
            {

                //Verifiying that the essential user data, has been setted
                if (string.IsNullOrEmpty(Configuration.Client.Consumer) || string.IsNullOrEmpty(Configuration.Client.ConsumerSecret))
                {
                    throw new Exception("ConsumerKey and ConsumerSecret must be setted before making any request");
                }

                // Gets the OAuth client
                consumer = new WebConsumer(BlueviaConsumer.ServiceDescription, BlueviaConsumer.TokenManager);

                // Gets the url
                var uri = HttpQueryString.MakeQueryString(baseUri, queryString);

                // Gets the Endpoint 
                endpoint = new MessageReceivingEndpoint(uri,webMethod.ToHttpDeliveryMethods() |
                                                                                 HttpDeliveryMethods.AuthorizationHeaderRequest);

                requestHandler = consumer.Channel.WebRequestHandler;

                // for the special case: post request with body content and multipart (file attachments)///////////////////////
                if (webMethod == WebMethod.Post && requestEntity != null && files.Count > 0)
                {
                    // body content as first file attachment
                    files.Insert(0, Extension.SetAttachmentAsXml(requestEntity, requestType));
                    request = consumer.PrepareAuthorizedRequest(endpoint, accessToken);

                    // setting request headers
                    request.Headers.Add(headers);

                    try
                    {
                        // calling the server for a response
                        response = request.PostMultipart(requestHandler, files);
                    }
                    catch (DotNetOpenAuth.Messaging.ProtocolException)
                    {
                        throw ParseError(response);
                    }
                }// End case: post request with body content and multipart (file attachments)//////////////////////////////////

                //For the case: post request is a Form url encoded, and not twolegged, headers musnt be buildt/////////////////
                else if (isFormUrlEncoded && !twoLeggedAuth)
                {
                    try
                    {
                        // calling the client for a response
                        request = consumer
                            .PrepareAuthorizedRequest(endpoint, accessToken, ((Bluevia.Core.KeyValueUrl)requestEntity).getIDictionary());


                        response = requestHandler.GetResponse(request);
                    }
                    catch (DotNetOpenAuth.Messaging.ProtocolException)
                    {
                        var current = OperationContext.Current;
                        throw ParseError(response);
                    }
                }//End case: post request is a Form url encoded, and not twolegged/////////////////////////////////////////////


                //For the rest, headder and message must be buildt/////////////////////////////////////////////////////////////////////////
                else
                {
                    if (twoLeggedAuth)
                    {
                        TwoLeggedOAuth twoleggedOAuth = new TwoLeggedOAuth();
                        //Case Twolegged and formurlencoded.
                        if (isFormUrlEncoded)
                        {
                            if (isForPaymentRequest)//If its for Payment TokenRequest, enables the option in twolegged procedure
                            {
                                twoleggedOAuth.EnableIsForPaymentRequest();
                                twoleggedOAuth.setCallBack(callBack);

                                //To consider that a getPaymentRequestToken could be done via SMS.
                                if (isForSMSHandshake)
                                {
                                    twoleggedOAuth.EnableIsForSMSHandshake();
                                    twoleggedOAuth.setCallBack(callBack);
                                }
                            }
                            request = twoleggedOAuth
                                .generateTwoLeggedOAuthRequest(uri, webMethod, ((Bluevia.Core.KeyValueUrl)requestEntity).getIDictionary());
                        }
                        //Case Twolegged and not FormUrlEncoded
                        else
                        {

                            if(isForSMSHandshake){
                                twoleggedOAuth.EnableIsForSMSHandshake();
                                twoleggedOAuth.setCallBack(callBack);
                            }

                            request = twoleggedOAuth.generateTwoLeggedOAuthRequest(uri, webMethod);
                        }
                    }
                    //Not Twolegged
                    else
                    {
                        //Not FormUrlEncoded
                        request = consumer.PrepareAuthorizedRequest(endpoint, accessToken, files);
                    }

                    // setting request headers
                    request.Headers.Add(headers);

                    //For the case: the timestamp must match as particular time
                    if(isForcedDate)
                    {
                        //recomposing the body timestamp parameter
                        String authority = (string)request.Headers.GetValues(0).GetValue(0);
                        SetDate(authority);
                    }

                    // setting request method
                    request.Method = webMethod.ToString("g");
                    request.AllowWriteStreamBuffering = true;
                    if (ShouldBuildXmlContent())
                    {
                        // setting content-type and content body
                        if (requestType == typeof(Bluevia.Core.KeyValueUrl))
                            request.SetContentAsUrlEncoded(requestEntity as Bluevia.Core.KeyValueUrl);
                        else
                            request.SetContentAsXml(requestEntity, requestType);
                    }
                    try
                    {
                        // calling the client for a response
                        response = requestHandler.GetResponse(request, DirectWebRequestOptions.AcceptAllHttpResponses);
                    }
                    catch (DotNetOpenAuth.Messaging.ProtocolException)
                    {
                        var current = OperationContext.Current;
                        throw ParseError(response);
                    }
                }//End of the rest//////////////////////////////////////////////////////////////////////////////////////////////


                // checks acceptable status of the response
                if (acceptableStatus.Contains((int)response.Status))
                {
                    // execute callback
                    if (afterCall != null)
                        afterCall(response);
                }
                else
                {
                    throw ParseError(response);
                }
            }
            catch (BlueviaException)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new BlueviaException(Bluevia.Resources.CoreResources.UnknownError, ex);
            }
        }

    }
}
