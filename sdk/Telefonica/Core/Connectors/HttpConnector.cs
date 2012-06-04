// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.IO;

using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using Bluevia.Core.Schemas;
using Bluevia.Core.Tools;

namespace Bluevia.Core.Connectors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="HTTPConnector.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   The HttpConnector: Class wich implements functionallity described by the IConnector 
    /// interface, to access the BlueVia services in Http way.</summary>
    /// <remarks>   2012/02/09. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class HTTPConnector : IBV_Connector, IBV_Auth
    {
        /// <value>The Http Request object.</value>
        protected HttpWebRequest request;

        /// <value>The Http Response object.</value>
        protected HttpWebResponse response;

        /// <value>The Url of the service requested. Address, and in case, queryParameters.</value>
        protected Uri uri;

        /// <value>The query Parameters for the service request, received from the client.</value>
        protected Dictionary<string, string> queryParameters;

        // Defining the body as byteArray, is not the most usefull or efficient option, as the HttpWebRequest object
        // can accept, xml, or formurl bodies.
        // But is necessary to maintain an homogeneous interface, and an easy debugging.
        /// <value>The body of CREATE/UPDATE operations.</value>
        protected byte[] body;

        /// <value>The body headers of CREATE/UPDATE operations.</value>
        protected Dictionary<string, string> headers;

        /// <value>The SSL Client certificate object for trusted requests.</value>
        protected X509CertificateCollection certCollection;


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The CRUD's "Create" operation. Will prepare and call a POST operation over HTTP.</summary>
        /// <remarks>   2012/04/24. Able to receive null body</remarks>
        /// <param name="uri">The string wich represents the Bluevia's service that is going to be called </param>
        /// <param name="parameters">Key-Value url query pairs</param>
        /// <param name="body">The POST Body Content</param>
        /// <param name="headers">The POST Content-Type, and extra Bluevia's special headers</param>
        /// <returns>The response related to the request, through the Call Method</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Response Create(string uri, Dictionary<string, string> parameters, byte[] body, Dictionary<string, string> headers)
        {
            if (headers == null)
            {
                throw new BlueviaException(
                    "Null headers has been received in the CRUD (CREATE) method."
                    , ExceptionCode.InvalidArgumentException);
            }
            else
            {
                if(headers.Count == 0)
                {
                    throw new BlueviaException(
                    "No header has been received in the CRUD (CREATE) method."
                    , ExceptionCode.InvalidArgumentException);
                }
                initializeRequest(uri, parameters, body, headers);
            }            

            request.Method = WebMethod.Post.ToString("g");
            Authenticate();

            return Call();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The CRUD's "Retrieve" operation. Will prepare and call a GET operation over HTTP.</summary>
        /// <remarks>   2012/02/09. </remarks>
        /// <param name="uri">The string wich represents the Bluevia's service that is going to be called.</param>
        /// <param name="parameters">Key-Value url query pairs</param>
        /// <returns>The response related to the request, through the Call Method</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Response Retrieve(string uri, Dictionary<string, string> parameters)
        {
            initializeRequest(uri, parameters, null, null);
            request.Method = WebMethod.Get.ToString("g");
            Authenticate();

            return Call();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The CRUD's "Update" operation. Will prepare and call an UPDATE operation over HTTP.</summary>
        /// <remarks>   2012/03/02. </remarks>
        /// <param name="uri">The string wich represents the Bluevia's service that is going to be called.</param>
        /// <param name="parameters">Key-Value url query pairs</param>
        /// <param name="body">The UPDATE Body Content</param>
        /// <param name="headers">The UPDATE Content-Type, and extra Bluevia's special headers.</param>
        /// <returns>The response related to the request, through the Call Method</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Response Update(string uri, Dictionary<string, string> parameters, byte[] body, Dictionary<string, string> headers)
        {
            throw new BlueviaException(
                    "UPDATE CRUD Method not implemented"
                    , ExceptionCode.NotImplementedException);
            /*if ((body != null) && (!string.IsNullOrEmpty(encoding)))
            {
                initializeRequest(uri, parameters, body, encoding);
            }
            else
            {
                BlueviaSystemException ex = new BlueviaSystemException("Null body or encoding has been received in the CRUD (UPDATE) method.");
                ex.code = ExceptionCode.NullArgumentException;
                throw ex;
            }
            request.Method = WebMethod.DUpdate.ToString("g");
            Authenticate();
            
            return Call();
            */
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The CRUD's "Retrieve" operation. Will prepare and call a GET operation over HTTP.</summary>
        /// <remarks>   2012/02/09. </remarks>
        /// <param name="uri">The string wich represents the Bluevia's service that is going to be called.</param>
        /// <param name="parameters">Key-Value url query pairs</param>
        /// <returns>The response related to the request, through the Call Method</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Response Delete(string uri, Dictionary<string, string> parameters)
        {
            initializeRequest(uri, parameters, null, null);
            request.Method = WebMethod.Delete.ToString("g");
            Authenticate();

            return Call();
        }

        //IMPLEMENTED BY SON
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to prepare or provide authentication info for the HTTP operation.
        /// A child class, must implement it.</summary>
        /// <remarks>2012/02/09.</remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public abstract void Authenticate();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to initialize the request, following the steps:
        /// 1- Checking the parameters
        /// 2- Creating an aimed request
        /// 3- Filling the global fields with the info: </summary>
        /// <remarks>   2012/03/06. </remarks>
        /// <param name="uri">Mandatory string wich represents the Bluevia's service that is going to be called </param>
        /// <param name="parameters">Mandatory Dictionary of queryParameters (at least "version"must be provided)</param>
        /// <param name="body">The body content</param>
        /// <param name="headers">The Content-Type, and extra Bluevia's special headers</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void initializeRequest(string uri, Dictionary<string, string> parameters, byte[] body, Dictionary<string, string> headers)
        {
            bool err = true;//If this boolean doesn't change its value, a BlueviaException will be thrown
            if ((!string.IsNullOrEmpty(uri))&&(parameters!=null))
            {
                if (parameters.Count!=0)
                {
                    this.uri = HttpTools.BuildUri(uri, parameters);
                    request = (HttpWebRequest)HttpWebRequest.Create(this.uri);
                    err = false;//the parameters aren't void-> don't need to throw an Exception
                }
            }
            if (err)
            {
                throw new BlueviaException(
                    "Empty \"parameters\" has been received in the CRUD Method."
                    , ExceptionCode.InvalidArgumentException);
            }

            this.body = body;
            this.headers = headers;
            this.queryParameters = parameters;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to execute the request, and control the exceptions.</summary>
        /// <remarks>   2012/04/19. SSL Exception control code added.
        /// 2012/04/24. Null body controlled when PostWithout body.</remarks>
        /// <returns>The formated Generic Response. 
        /// If Exception occurs (Http 400,500, timeout etc..), and properly formated exception will be thrown.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private BV_Response Call()
        {
            BV_Response genericResponse = null;

            //CONFIGURING THE REQUEST CALL:---------

            //Setting the Certificate if exists:
            if (certCollection != null)
            {
                request.ClientCertificates = certCollection;
            }

            //Setting the Timeout:
            request.Timeout = Constants.blueviaTimeout;
            //Allowing autoredirect: true by default

            //IN POST CASE(with body), the body and headders must be buildt:
            if (headers!=null)
            {
                WebHeaderCollection headerCollection = new WebHeaderCollection();
                foreach (var pair in headers)
                {
                    headerCollection.Add(pair.Key, pair.Value);
                }
                
                //Setting the Content-Type

                //first if the message is a multipart, setting the boundary in the header
                string contentType = null;
                headers.TryGetValue(HttpTools.ContetTypeKey, out contentType);
                if (contentType.Contains("multipart"))
                {
                    string bodyInString = Encoding.Default.GetString(body);
                    string boundary = bodyInString.Substring(2, bodyInString.IndexOf("\r\n") - 2);
                    contentType = string.Format(contentType, boundary);
                }


                //The content-type header must be setted with the following instruction ...
                request.ContentType = contentType;

                //... so deleting from the headerCollection, to avoid an exception ...
                headerCollection.Remove(HttpTools.ContetTypeKey);
                //... when the whole collection of headers is setted.
                request.Headers.Add(headerCollection);

                if (body != null)
                {
                    request.ContentLength = body.Length;

                    //SENDING THE REQUEST FOR PETITIONS WITH BODY:---------
                    try
                    {
                        using (System.IO.Stream putStream = request.GetRequestStream())
                        {
                            putStream.Write(body, 0, body.Length);
                        }
                    }
                    catch (WebException e)
                    {
                        throw new BlueviaException(
                        "SSL error: Unable to create secure channel: " + e.Message
                        , ExceptionCode.ConnectionErrorException);
                    }
                }
            }

            //SENDING THE REQUEST FOR PETITIONS WITHOUT BODY:---------
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)//Only Bluevia Http Errors will be catched
            {
                response = (HttpWebResponse)e.Response;
            }

            //THE RESPONSE HAS BEEN RECEIVED:---------

            //Checking the response status:
            if(response == null)
            {
                throw new BlueviaException(
                    "Http error: Unable to create secure channel."
                    , ExceptionCode.ConnectionErrorException);
            }
            if ((int)response.StatusCode >= 400) //HTTP Error
            {
                BV_ConnectorException ex = new BV_ConnectorException(
                    response.StatusDescription
                    , Convert.ToString((int)response.StatusCode));
                ex.SetConnectorExceptionAdditionalData(CreateAdditionalData());
                throw ex;
            }
            else //Correct Response
            {
                genericResponse = new BV_Response();
                genericResponse.SetResponseStatus(Convert.ToString((int)response.StatusCode));
                genericResponse.SetResponseData(response.StatusDescription);
                genericResponse.SetResponseAdditionalData(CreateAdditionalData());
            }

            return genericResponse;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Private method to extract the headers and the body of the response, 
        /// and fill with that info the AdditionalResponseData of a Bluevia_Response, or a 
        /// BV_ConnectorException</summary>
        /// <remarks>   2012/03/14. </remarks>
        /// <returns>A full Core.Schemas.AdditionalResponseData</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private AdditionalResponseData CreateAdditionalData()
        {
            byte[] responseData = null;
            //Saving the responseBody as string:
            using (Stream stream = response.GetResponseStream())
            {
                MemoryStream memStream = new MemoryStream();
                stream.CopyTo(memStream);
                responseData = memStream.ToArray();
            }

            AdditionalResponseData addData = new AdditionalResponseData();
            //Setting Body:
            addData.SetBody(responseData);

            //Setting Headers:
            for (int i = 0; i < response.Headers.Count; i++)
            {
                StringBuilder valuesAppender = new StringBuilder();
                foreach (string value in response.Headers.GetValues(i))
                {
                    valuesAppender.Append(value);
                }

                addData.AddHeader(
                    response.Headers.GetKey(i)
                    , valuesAppender.ToString());
            }
            return addData;
        }
    }
}
