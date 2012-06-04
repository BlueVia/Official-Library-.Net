// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Collections.Generic;

using Bluevia.Core.Schemas;

using Bluevia.Core.Tools;

namespace Bluevia.OAuth.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="OAuthSimplifiers.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class for response simplifier functions of OAuth API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class OAuthSimplifiers
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Not Exactly a simplifier, but is named in this way to maintain coherence with other APIs.
        /// This Function retrieves a Dictionary (hash collection), and fills a Token object with the retrived data.</summary>
        /// <param name="pairs">The retrieved oauth data stored in a Dictionary (hash collection).</param>
        /// <returns>A full Token</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Token SimplifyTokenType(Dictionary<string, string> pairs)
        {
            Token token = new RequestToken();
            string temp;
            pairs.TryGetValue(OAuthConstants.OAuthTokenKey, out temp);
            token.key = temp;
            pairs.TryGetValue(OAuthConstants.OAuthTokenSecretKey, out temp);
            token.secret = temp;
            return token;
        }       
    }
}
