// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 
using System.Collections.Generic;

using Bluevia.Core.Connectors;
using Bluevia.Core.Schemas;
using Bluevia.Core.Tools;


namespace Bluevia.Core.Clients
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_BaseClient.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Abstract representation of an HTTP REST Client for the Bluevia API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class BV_BaseClient
    {
        /// <summary></summary>
        protected IParser parser;

        /// <summary></summary>
        protected ISerializer serializer;

        /// <summary></summary>
        protected BV_Connector connector;

        /// <summary></summary>
        protected BV_Response response;

        /// <summary></summary>
        protected string url;

        /// <summary></summary>
        protected BVMode bvMode;

        /// <summary></summary>
        protected string sandboxString = "{0}";



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Base Client, to work as a trusted client. 
        /// It initiates the url, creates the certificate, the Bluevia Connector and sets the operational mode.</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="certPath">The path to the ssl client's pem certificate.</param>
        /// <param name="certPasswd">Optional (only if needed): The password of the ssl client's pem certificate.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void InitTrusted(BVMode mode
            , string consumer, string consumerSecret
            , string certPath, string certPasswd = "")
        {
            if (string.IsNullOrEmpty(consumer) || string.IsNullOrEmpty(consumerSecret) || string.IsNullOrEmpty(certPath))
            {
                throw new BlueviaException(
                    "Invalid parameter when creating Bluevia Client."
                    , ExceptionCode.InvalidArgumentException);
            }

            parser = null;
            serializer = null;
            if (mode == BVMode.SANDBOX)
            {
                sandboxString = "_Sandbox{0}";
            }

            url = Constants.blueviaURLBase;
            bvMode = mode;
            connector = new BV_Connector(consumer,consumerSecret,CreateCert(certPath, certPasswd));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Base Client, to work as an untrusted client. 
        /// It initiates the url, creates the Bluevia Connector and sets the operational mode.</summary>
        /// <remarks>
        /// 2012.05.8 Consumer Error message changed.
        /// </remarks>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void InitUntrusted(BVMode mode
            , string consumer, string consumerSecret
            , string token = "", string tokenSecret = "")
        {

            if (string.IsNullOrEmpty(consumer) || string.IsNullOrEmpty(consumerSecret))
            {
                throw new BlueviaException(
                    "Null or Empty consumers when creating Bluevia Client."
                    , ExceptionCode.InvalidArgumentException);
            }

            parser = null;
            serializer = null;
            if (mode == BVMode.SANDBOX)
            {
                sandboxString = "_Sandbox{0}";
            }
            url = Constants.blueviaURLBase;
            bvMode = mode;
            connector = new BV_Connector(consumer, consumerSecret, token, tokenSecret);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method that process the flow of a CREATE(POST) request.</summary>
        /// <remarks>2012/03/5</remarks>
        /// <param name="address">The string wich represents the Bluevia's service that is going to be called </param>
        /// <param name="parameters">Key-Value url query pairs</param>
        /// <param name="content">Tc generic object, to be serialized (or not) to serve as message</param>
        /// <param name="headers">The POST Content-Type, and extra Bluevia's special headers.</param>
        /// <returns>Tr generic object, to be parsed (or not) to serve as result.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected Tr BaseCreate<Tr, Tc>(string address, Dictionary<string, string> parameters, Tc content, Dictionary<string, string> headers)
        {
            byte[] message = null;
            if (serializer != null)
            {
                message = serializer.Serialize(content);
            }

            try
            {
                response = connector.Create(address, parameters, message, headers);
            }
            catch (BV_ConnectorException e)
            {
                SimplifyAndThrowConnectorException(e);
            }
            if (parser == null)
            {
                return default(Tr);
            }
            return (Tr)parser.Parse<Tr>(response.GetResponseBody());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method that process the flow of a RETRIEVE(GET) request.</summary>
        /// <remarks>2012/03/5</remarks>
        /// <param name="address">The string wich represents the Bluevia's service that is going to be called </param>
        /// <param name="parameters">Key-Value url query pairs</param>
        /// <returns>Tr generic object, to be parsed (or not) to serve as result.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected Tr BaseRetrieve<Tr>(string address, Dictionary<string, string> parameters)
        {
            try
            {
                response = connector.Retrieve(address, parameters);
            }
            catch (BV_ConnectorException e)
            {
                SimplifyAndThrowConnectorException(e);
            }
            if (parser == null)
            {
                object nl = null;
                return (Tr)nl;
            }
            return (Tr)parser.Parse<Tr>(response.GetResponseBody());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method that process the flow of an UPDATE(UPDATE) request. NOT IMPLEMENTED!.</summary>
        /// <remarks>2012/03/5</remarks>
        /// <param name="address">The string wich represents the Bluevia's service that is going to be called </param>
        /// <param name="parameters">Key-Value url query pairs</param>
        /// <param name="content">Tc generic object, to be serialized (or not) to serve as message</param>
        /// <param name="headers">The UPDATE Content-Type, and extra Bluevia's special headers.</param>
        /// <returns>Tr generic object, to be parsed (or not) to serve as result.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected Tr BaseUpdate<Tr, Tc>(string address, Dictionary<string, string> parameters, Tc content, Dictionary<string, string> headers)
        {
            throw new BlueviaException(
                    "BaseUPDATE CRUD Method not implemented"
                    , ExceptionCode.NotImplementedException);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method that process the flow of a DELETE(DELETE) request.</summary>
        /// <remarks>2012/03/5</remarks>
        /// <param name="address">The string wich represents the Bluevia's service that is going to be called.</param>
        /// <param name="parameters">Key-Value url query pairs.</param>
        /// <returns>Tr generic object, to be parsed (or not) to serve as result.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected Tr BaseDelete<Tr>(string address, Dictionary<string, string> parameters)
        {
            string message = string.Empty;
            try
            {
                response = connector.Delete(address, parameters);
            }
            catch (BV_ConnectorException e)
            {
                SimplifyAndThrowConnectorException(e);
            }
            if (parser == null)
            {
                object nl = null;
                return (Tr)nl;
            }
            return (Tr)parser.Parse<Tr>(response.GetResponseBody());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method that creates and initializes the "parameters" object that must be passed
        /// to every request.</summary>
        /// <remarks>2012/03/21.</remarks>
        /// <returns>An initialized "parameters" dictionary, with the mandatory KeYValue Pair</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected Dictionary<string, string> CreateParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(Constants.blueviaVersionKey, Constants.blueviaVersion);
            return parameters;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Method that creates and initializes the "headers" object that must be passed
        /// to every POST/UPDATE request. At least, a ContentType header, is created (even with a  void value).</summary>
        /// <remarks>2012/04/03.</remarks>
        /// <param name="contentType">The type of the body content(can ve void).</param>
        /// <returns>An initialized "Headers" dictionary, with the mandatory KeYValue Pair</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected Dictionary<string, string> CreateHeaders(string contentType)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(HttpTools.ContetTypeKey, contentType);
            return headers;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method that simplifies a BV_ConnectorException, into a BlueviaException</summary>
        /// <remarks>   2012/03/14. </remarks>
        /// <param name="e">A BV_ConnectorException, that occurs, when a request receives
        /// an HTTP 4xx,5xx error</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected static void SimplifyAndThrowConnectorException(BV_ConnectorException e)
        {
            BlueviaException bvE = new BlueviaException(e.GetConnectorExceptionBody(), e.code);
            throw bvE;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method that creates a X509CertificateCollection. </summary>
        /// <remarks>   2012/03/14. </remarks>
        /// <param name="certPath">The path to the ssl client's pem certificate.</param>
        /// <param name="certPasswd">Optional (only if needed): The password of the ssl client's pem certificate.</param>
        /// <returns> The certificate collection to attach into the Bluevia Connector.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static System.Security.Cryptography.X509Certificates.X509CertificateCollection CreateCert(string certPath, string certPasswd)
        {
            System.Security.Cryptography.X509Certificates.X509CertificateCollection certCollection
                = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();

            System.Security.Cryptography.X509Certificates.X509Certificate cert = null;
            if (string.IsNullOrEmpty(certPasswd))
            {
                cert = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromSignedFile(@certPath);
            }
            else
            {
                cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(@certPath, @certPasswd);
            }
            certCollection.Add(cert);
            return certCollection;
        }


    }
}
