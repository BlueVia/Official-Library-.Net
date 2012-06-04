// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;

using Bluevia.Core;
using Bluevia.Core.Tools;
using Bluevia.Core.Schemas;
using Bluevia.OAuth.Client;


using Bluevia.Payment.Schemas;
using Bluevia.Payment.Tools;

namespace Bluevia.Payment.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_Payment.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for Payment, to cover the process of retrieving authorization credentials for 
    /// payments transactions, and these transactions, with <a href=""> BlueVia Payment service.</a>
    /// This Api needs to be authorizated for each payment, so, it has its own OAuth Functions (for that
    /// reason, it has also extra parsers and serializer, to properly switch between them and null ).</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_Payment : BV_OAuthClient
    {
        /// <summary>An XML parser for the RPC requests: Payment, GetPaymentStatus and Cancel Authorization.</summary>
        IParser xmlParser = null;

        /// <summary>An formUrl parser for the Authorization REST requests: GetPaymentRequestToken and GetPaymentAccessToken.</summary>
        IParser formUrlParser = null;

        /// <summary>An XML serializer for the RPC requests: Payment, GetPaymentStatus and Cancel Authorization.</summary>
        ISerializer xmlSerializer = null;

        /// <summary>An formUrl serializer for the Authorization REST requests: GetPaymentRequestToken.</summary>
        ISerializer formUrlSerializer = null;

        /// <summary>An string to describe the url for payment services.</summary>
        string paymentUrl = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_OAuth"/>. 2 and 3 Legged Constructor</summary>
        /// <param name="mode">The Bluevia operation mode: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The appplication Identifier</param>
        /// <param name="consumerSecret">The application Secret</param>
        /// <param name="token">Optional: The final customer Identifier</param>
        /// <param name="tokenSecret">Optional: The final customer Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Payment(BVMode mode, string consumer, string consumerSecret, string token = "", string tokenSecret = "")
        {
            if (mode == BVMode.TEST)
            {
                throw new BlueviaException("Payment is not available on TEST MODE."
                        , ExceptionCode.InvalidModeException);
            }
            InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
            InitApiUrlAndObjects();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method to get the Request Token for Payment Api. </summary>
        /// <remarks> 2012/03/29. </remarks>
        /// <param name="amount">the cost of the digital good being sold,
        /// expressed in the minimum fractional monetary unit of the currency reflected in the next parameter
        /// (to avoid decimal digits). </param>
        /// <param name="currency">The currency of the payment, following ISO 4217 (EUR, GBP, MXN, etc.). </param>
        /// <param name="name">The name of the service for the payment.</param>
        /// <param name="serviceID">The id of the service for the payment</param>
        /// <param name="callback">Optional. If exists, it indicates a valid URL where the verifier code
        /// for the OAuth process, is going to be sent (Out of Band mode by default).</param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public RequestToken  GetPaymentRequestToken(uint amount, String currency, String name, String serviceID, String callback = "oob")
        {
            if ((amount < 0) || string.IsNullOrEmpty(currency) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(serviceID))
            {
                throw new BlueviaException("Wrong mandatory parameters when requesting PaymentTokens."
                        , ExceptionCode.InvalidArgumentException);
            }

            long result = 0;
            bool isNumericDestination = false;
            isNumericDestination = long.TryParse(callback, out result);
            if (isNumericDestination) 
            {
                throw new BlueviaException("OAuth by SMSHandShake is not available in PAYMENT."
                    , ExceptionCode.InvalidArgumentException);
            }

            //Adding body parameters. Sorted to match oauth requeriments.
            Dictionary<string, string> paymentFields = new Dictionary<string, string>();
            paymentFields.Add("paymentInfo.amount", Convert.ToString(amount));
            paymentFields.Add("paymentInfo.currency", currency);
            paymentFields.Add("serviceInfo.name", name);
            paymentFields.Add("serviceInfo.serviceID", serviceID);

            //Selecting the apropiate parser/serializer for the operation:
            serializer = formUrlSerializer;
            parser = formUrlParser;

            return base.GetRequestTokensProcess(callback, paymentFields);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Gets the Access Token For the specified Payment.</summary>
        /// <remarks>2012/03/30</remarks>
        /// <param name="oauthVerifier">OAuth verifier for the token. </param>
        /// <param name="requestToken">Optional: The previously received requestToken 
        /// (its autosetted during the requestToken process, and can be setted also during the client construction).</param>
        /// <param name="requestSecret">Optional: The previously received requestTokenSecret
        /// (its autosetted during the requestToken process, and can be setted also during the client construction).</param>
        /// <returns>AccessToken for the Payment.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Token GetPaymentAccessToken(string oauthVerifier, string requestToken = null, string requestSecret = null)
        {
            //Selecting the apropiate parser/serializer for the operation:
            serializer = null;
            parser = formUrlParser;
            var paymentAccessToken = GetAccessToken(oauthVerifier, requestToken, requestSecret);

            //Setting the tokens to make the payment
            connector.SetTokens(paymentAccessToken.key, paymentAccessToken.secret);

            return GetAccessToken(oauthVerifier, requestToken, requestSecret);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to set tokens of a previous Payment.</summary>
        /// <remarks>   2012/04/02. </remarks>
        /// <param name="token">The access Token</param>
        /// <param name="tokenSecret">The Token Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetTokens(string token, string tokenSecret)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(tokenSecret))
            {
                BlueviaException ex = new BlueviaException("Null or empty tokens when using SetTokens.");
                ex.code = ExceptionCode.InvalidArgumentException;
                throw ex;
            }
            connector.SetTokens(token,tokenSecret);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This operation allows to request a charge in the account indicated by the end user identifier,
        ///     with information about the purchase, such as economic units, the currency employed, 
        ///     optional information about additional taxes that could apply, 
        ///     generic code and a suggested reference code which uniquely identifies the current payment event.
        /// </summary>
        /// <param name="amount">Unsigned int whith the amount (without decimals), of the desired payment.</param>
        /// <param name="currency">String with the currency of the payment.</param>
        /// <param name="endpoint"> Optional: String which contains the endpoint where status notifications will be sent.</param>
        /// <param name="correlator">Optional, Mandatory if Notifications: The correlator for the status notifications.</param>
        /// <returns>A PaymentResult Object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public PaymentResult Payment(uint amount, String currency, String endpoint = null, String correlator = null)
        {
            if(string.IsNullOrWhiteSpace(connector.GetToken()))
            {
                throw new BlueviaException("Null or empty Tokens when making a Payment."
                        , ExceptionCode.InvalidArgumentException);
            }
            if (amount < 0 || string.IsNullOrEmpty(currency))
            {
                throw new BlueviaException("Wrong mandatory parameters when making a Payment."
                        , ExceptionCode.InvalidArgumentException);
            }

            PaymentParamsType paymentParams = new PaymentParamsType();
            paymentParams.paymentInfo = new PaymentInfoType();
            paymentParams.paymentInfo.amountSpecified = true;
            paymentParams.paymentInfo.amount = amount;
            paymentParams.paymentInfo.currency = currency;

            double seconds = Convert.ToInt64(HttpTools.GenerateTimeStamp());
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0);
            date = date.AddSeconds(seconds);
            paymentParams.timestamp = date;

            //OPtional fields
            if (!string.IsNullOrEmpty(endpoint) && !string.IsNullOrEmpty(correlator))//Both endpoint and correlator arent null nor empty
            {
                paymentParams.receiptRequest = new SimpleReferenceType() { endpoint = endpoint, correlator = correlator };
            }
            else if (!(string.IsNullOrEmpty(endpoint) && string.IsNullOrEmpty(correlator)))//One of enpoint or correlator is null or empty
            {
                throw new BlueviaException("Both endpoint and correlator parameters,are mandatory when making payment with status notifications."
                        , ExceptionCode.InvalidArgumentException);
            }

            //Building the object wich will be serialized to serve as body
            MethodCallType1 mct1 = new Schemas.MethodCallType1();
            mct1.id = HttpTools.generateRPCId();
            mct1.version = Core.Constants.blueviaRPCAccessVersion;
            mct1.method = Schemas.MethodType.PAYMENT;
            mct1.@params = new Schemas.MethodCallTypeParams();
            mct1.@params.Item = paymentParams;
            
            //As the timestamp of the payment must be the same as the Oauth:
            Dictionary<string, string> oauthExtra = new Dictionary<string, string>();
            oauthExtra.Add(OAuthConstants.OAuthTimestampKey, seconds.ToString());
            connector.SetOAuthParams(oauthExtra);           

            //Selecting the apropiate parser/serializer for the operation:
            serializer = xmlSerializer;
            parser = xmlParser;

            //The Bluevia´s complex response object, as result of the call:
            MethodResponseType1 response = BaseCreate<MethodResponseType1, MethodCallType1>(
                string.Format(paymentUrl, Constants.PaymentPayment)
                , CreateParameters()
                , mct1
                , CreateHeaders(HttpTools.ContetTypeXML));
            return PaymentSimplifiers.SimplifyPaymentResultType((PaymentResultType)response.result.Item);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This operation allows to query for the current status of an already initiated purchase 
        ///     (i.e. payment transaction).</summary>
        /// <param name="transactionId">The id of the transaction wich status is going to be retrieved.</param>
        /// <returns>A PaymentResult.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public PaymentStatus GetPaymentStatus(String transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new BlueviaException("Null or Empty transactionId when requesting a payment status."
                        , ExceptionCode.InvalidArgumentException);
            }

            //Building the object wich will be serialized to serve as body
            GetPaymentStatusParamsType paymentStatusParams = new GetPaymentStatusParamsType();
            paymentStatusParams.transactionId = transactionId;

            
            MethodCallType1 mct1 = new Schemas.MethodCallType1();
            mct1.id = HttpTools.generateRPCId();
            mct1.version = Core.Constants.blueviaRPCAccessVersion;
            mct1.method = MethodType.GET_PAYMENT_STATUS;
            mct1.@params = new MethodCallTypeParams();
            mct1.@params.Item = paymentStatusParams;

            //Selecting the apropiate parser/serializer for the operation:
            serializer = xmlSerializer;
            parser = xmlParser;

            //The Bluevia´s complex response object, as result of the call:
            MethodResponseType1 response = BaseCreate<MethodResponseType1, MethodCallType1>(
                string.Format(paymentUrl, Constants.PaymentGetPaymentStatus)
                , CreateParameters()
                , mct1
                , CreateHeaders(HttpTools.ContetTypeXML));

            return PaymentSimplifiers.SimplifyPaymentStatusResultType((GetPaymentStatusResultType)response.result.Item);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Cancels the previous AccesToken requested, before making the payment.</summary>
        /// <remarks> 2012/03/29. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool CancelAuthorization()
        {
            MethodCallType1 mct1 = new Schemas.MethodCallType1();
            mct1.id = HttpTools.generateRPCId();
            mct1.version = Core.Constants.blueviaRPCAccessVersion;
            mct1.method = Schemas.MethodType.CANCEL_AUTHORIZATION;

            //Selecting the apropiate parser/serializer for the operation:
            serializer = xmlSerializer;
            parser = null;

            //No complex response object expected, as result of the call:
            BaseCreate<bool, MethodCallType1>(
                string.Format(paymentUrl, Constants.PaymentCancelAuthorization)
                , CreateParameters()
                , mct1
                , CreateHeaders(HttpTools.ContetTypeXML));
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function concatenates the api string into the url, 
        /// and instantiates the parsers and serializers.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitApiUrlAndObjects()
        {
            //In payment case, an extra url is created to avoid overriding the oauth one:
            paymentUrl = string.Format(Core.Constants.blueviaURLBase, 
                string.Format(Constants.apiPayment, sandboxString)
            );

            //The formUrl Parser and serializer are created during a previous step,
            // in the base BV_OAuth class.
            formUrlParser = parser;
            formUrlSerializer = serializer;
            xmlParser = new XMLParser();
            xmlSerializer = new BV_XMLSerializer(); 
        }

    }
}
