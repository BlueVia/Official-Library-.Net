// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Core.Configuration
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for misc properties of the BlueviaClient. </summary>
    /// <remarks>   22/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class Client
    {
        public static Store dataStore = new Store();

        ////////////////////////////////////////////////
        ////////////////////////////////////////////////
        //GETTERS
        ////////////////////////////////////////////////
        ////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   TimeOut applied to the connections made by the client. </summary>
        /// <value> The timeout. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static int Timeout { get { return dataStore.timeout; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the consumerKey applied in OAuth authentication. </summary>
        /// <value> The consumer key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string Consumer { get { return dataStore.consumer; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the consumer secret applied in OAuth authentication. </summary>
        /// <value> The consumer secret. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ConsumerSecret { get { return dataStore.consumerSecret; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Service Host Url. </summary>
        /// <value> The service host url. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string BlueviaHost { get { return "https://api.bluevia.com/services"; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Service Environment. </summary>
        /// <value> The service environment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string Environment { get { return dataStore.environment; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Service Environment, if Sandbox. </summary>
        /// <value> if Sandbox is activated. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool Sandbox { get { return dataStore.sandbox; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Authorise Host Url. </summary>
        /// <value> The Authorise host url. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Produccion
        public static string AuthoriseHost { get { return "https://connect.bluevia.com/authorise"; } }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the AccessToken. </summary>
        /// <value> The AccessToken. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string TokenAccess { get { return dataStore.tokenAccess; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the TokenSecret. </summary>
        /// <value> The TokenSecret. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string TokenSecret { get { return dataStore.tokenSecret; } }

        ////////////////////////////////////////////////
        ////////////////////////////////////////////////
        //SETTERS
        ////////////////////////////////////////////////
        ////////////////////////////////////////////////
        public static void setTimeout(int value)
        {
            dataStore.timeout = value;
        }
        public static void setConsumer(string value)
        {
            dataStore.consumer = value;
        }
        public static void setConsumerSecret(string value)
        {
            dataStore.consumerSecret = value;
        }
        public static void setEnvironment(string value)
        {
            dataStore.environment = value;
            if (value.StartsWith("_"))
            {
                if (!Sandbox)setSandbox(true);
            }
            else
            {
                if (Sandbox) setSandbox(false);
            }
            UriManager.UpdateFields();
        }
        public static void setSandbox(bool value)
        {
            dataStore.sandbox = value;
            if(value)
            {
                setEnvironment("_Sandbox");
            }
            else
            {
                setEnvironment("");
            }
            UriManager.UpdateFields();
        }
        public static void setTokenPair(string value1, string value2)
        {
            dataStore.tokenAccess = value1;
            dataStore.tokenSecret = value2;
            BlueviaConsumer.TokenManager.StoreNewRequestToken(value1,value2);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Stores properties of the BlueviaClient. </summary>
    /// <remarks>   12/04/2011. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Store
    {
        public int timeout = 0;
        public string consumer = string.Empty;
        public string consumerSecret = string.Empty;
        public string environment = string.Empty;
        public string tokenAccess = string.Empty;
        public string tokenSecret = string.Empty;
        public bool sandbox = false;
    }
}
