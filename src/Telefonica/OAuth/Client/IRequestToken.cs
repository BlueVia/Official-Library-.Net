// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
namespace Bluevia.OAuth.Client
{
    public interface IRequestToken
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the Request Token. </summary>
        /// <remarks>   19/04/2010. </remarks>
        /// <param name="userNick">     if included, it indicates a valid Identifier of the final User.
        ///                             The inclusion of this parameter means that the final User is not
        ///                             using a browser and therefore the Server will send an SMS to the
        ///                             User’s handset with a link as an alternative to the usual
        ///                             redirection to AA Portal mechanism. </param>
        /// <param name="callbackUrl">  URL of the callback. </param>
        /// <param name="apiName">      if included, specifies the concrete API for which the Request
        ///                             Token wants to be obtained. </param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        Bluevia.OAuth.Schemas.RequestToken Get(string callbackUrl = "oob");

                ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Overload for Getting the Request Token in Payment Api case. </summary>
        /// <remarks>   13/06/2011. </remarks>
        /// <param name="apiName">      if included, specifies the concrete API for which the Request
        ///                             Token wants to be obtained. </param>
        /// <returns>   Request Token. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        Bluevia.OAuth.Schemas.RequestToken Get(uint amount, String currency, String name, String serviceID, string callbackUrl = "oob");
    }
}
