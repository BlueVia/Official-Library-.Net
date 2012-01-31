// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Linq;
using System.Text;
using System.Collections;

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
        /// <summary>   Gets the Authorise Host Url. </summary>
        /// <value> The Authorise host url. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string AuthoriseHost { get { return dataStore.authoriseHost; } }

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
            if (value.StartsWith("S"))
            {
                dataStore.sandbox = true;
                dataStore.test = false;
                dataStore.live = false;
                dataStore.environment = "_Sandbox";
                dataStore.authoriseHost="https://bluevia.com/test-apps/authorise";
            }
            else if (value.StartsWith("T"))
            {
                dataStore.sandbox = false;
                dataStore.test = true;
                dataStore.live = false;
                dataStore.environment = "";
                dataStore.authoriseHost = "https://bluevia.com/test-apps/authorise";

            }
            else if(value.StartsWith("L"))
            {
                dataStore.sandbox = false;
                dataStore.test = false;
                dataStore.live = true;
                dataStore.environment = "";
                dataStore.authoriseHost="https://connect.bluevia.com/authorise";
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
        //Commercial environment by default:
        public string environment = string.Empty;
        public string authoriseHost = "https://connect.bluevia.com/authorise";
        public string tokenAccess = string.Empty;
        public string tokenSecret = string.Empty;
        public bool test = false;
        public bool live = true;
        public bool sandbox = false;
    }

    public static class ENVIRONMENT
    {
        public static readonly String TEST = "TEST";
        public static readonly String LIVE = "LIVE";
        public static readonly String SANDBOX = "SANDBOX";
    }
}
