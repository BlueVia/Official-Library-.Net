// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- //

using System.Collections.Generic;

namespace Bluevia.Core.Connectors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="IBV_OAuth.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   The IOAuth: Interface wich describes functionallity to provide 
    /// additional values or fields to the OAuthManager.</summary>
    /// <remarks>   2012/02/21. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    interface IBV_OAuth : IBV_Auth
    {
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to provide Bluevia's "special oauth options" from the client</summary>
        /// <remarks>   2012/02/21. </remarks>
        /// <param name="extraParams">KeyValuePairs with extra Oauth fields,
        /// or mandatory values for any oauth field.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        void SetOAuthParams(Dictionary<string, string> extraParams);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to change the behavior of the BV_HTTP_OAuth_Connector,
        /// from 2legged to 3legged, by setting the tokens.</summary>
        /// <remarks>   2012/02/16. </remarks>
        /// <param name="token">The access Token</param>
        /// <param name="tokenSecret">The Token Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        void SetTokens(string token, string tokenSecret);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to retrieve the Access Token</summary>
        /// <remarks>   2012/03/08. </remarks>
        /// <return>The Access Token</return>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        string  GetToken();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to know if the instance is a two legged Oauth Object</summary>
        /// <remarks>   2012/03/12. </remarks>
        /// <return>True, if the Object is OathTwolegged
        /// False, if is ThreeLegged.</return>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        bool IsTwoLegged();
    }
}
