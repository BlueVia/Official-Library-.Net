// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.Messaging;
using Bluevia.Core.Configuration;
using DotNetOpenAuth.OAuth.ChannelElements;

namespace Bluevia.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Unica OAuth consumer. </summary>
    /// <remarks>   22/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class BlueviaConsumer
    {
        public static readonly ServiceProviderDescription ServiceDescription;

        public static readonly InMemoryTokenManager TokenManager;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialize provider / token manager. </summary>
        /// <remarks>   22/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        static BlueviaConsumer()
        {
            TokenManager = new InMemoryTokenManager()
            {
                ConsumerKey = Client.Consumer,
                ConsumerSecret = Client.ConsumerSecret
            };

            ServiceDescription = new ServiceProviderDescription
            {
                RequestTokenEndpoint = new MessageReceivingEndpoint(UriManager.OAuth_RequestToken_Get, HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
                UserAuthorizationEndpoint = new MessageReceivingEndpoint(UriManager.OAuth_AccessToken_Get, HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
                AccessTokenEndpoint = new MessageReceivingEndpoint(UriManager.OAuth_AccessToken_Get, HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
                TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() }
            };

        }

    }
}
