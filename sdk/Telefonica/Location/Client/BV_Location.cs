// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using Bluevia.Core;

namespace Bluevia.Location.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_Location.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Bluevia Client for Location, to request Location info from the
    /// <a href=""> BlueVia location service.</a> </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_Location : BV_LocationClient
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BV_Location"/>.3 Legged Constructor</summary>
        /// <param name="mode">The Bluevia operation mode: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest">LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The appplication Identifier</param>
        /// <param name="consumerSecret">The application Secret</param>
        /// <param name="token">The final customer Identifier</param>
        /// <param name="tokenSecret">The final customer Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BV_Location(BVMode mode, string consumer, string consumerSecret, string token, string tokenSecret)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(tokenSecret))
            {
                throw new Bluevia.Core.Schemas.BlueviaException(
                    "Null or Empty tokens when creating Location Client. Two legged mode is not available in Location."
                    , Bluevia.Core.Schemas.ExceptionCode.InvalidArgumentException);
            }
            InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Retrieves the location of the terminal.</summary>
        /// <param name="accuracy">Optional: Accuracy, in meters, that is acceptable for a response.</param>
        /// <returns>An object containing the Location Data.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Schemas.LocationInfo GetLocation(int accuracy = 0)
        {
            return GetLocationProcess(accuracy, new Location.Schemas.UserIdType()
                {
                    ItemElementName = Schemas.ItemChoiceType1.alias,
                    Item = connector.GetToken()
                });
        }

    }
}
