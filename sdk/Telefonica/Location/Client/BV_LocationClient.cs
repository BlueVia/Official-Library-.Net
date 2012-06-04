// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using Bluevia.Core;
using Bluevia.Core.Clients;
using Bluevia.Core.Tools;
using Bluevia.Core.Schemas;
using Bluevia.Location.Schemas;
using Bluevia.Location.Tools;

namespace Bluevia.Location.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_LocationClient.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>This functional block covers the Location Request submission following 
    /// <a href="">BlueVia location service.</a></summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_LocationClient : BV_BaseClient
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Location functional block, to work 
        /// as a trusted client. 
        /// It calls the base Init function, wich creates the SSL client's certificate, the Bluevia Connector and
        /// sets the operational mode. 
        /// Then creates itself the api url, the parsers and serializers that the
        /// service petition's process needs</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="certPath">The path to the ssl client's pem certificate.</param>
        /// <param name="certPasswd">Optional (only if needed): The password of the ssl client's pem certificate.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitTrusted(BVMode mode
            , string consumer, string consumerSecret
            , string certPath, string certPasswd = "")
        {
            base.InitTrusted(mode, consumer, consumerSecret, certPath, certPasswd);
            InitApiUrlAndObjects();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>This Init function prepares the Location functional block, to work 
        /// as an untrusted client. 
        /// It calls the base Init function, wich creates the Bluevia Connector and
        /// sets the operational mode. 
        /// Then creates itself the api url, the parsers and serializers that the
        /// service petition's process needs</summary>
        /// <param name="mode"> The Bluevia Mode enumerator, that describes the 
        /// operational behavior of the client: <a href="https://www.bluevia.com/en/page/tech.howto.tut_APPtest"> LIVE, TEST, SANDBOX.</a></param>
        /// <param name="consumer">The application Identifier.</param>
        /// <param name="consumerSecret">The application Secret.</param>
        /// <param name="token">Optional (Mandatory for 3legged behavior): The final customer Identifier.</param>
        /// <param name="tokenSecret">Optional (Mandatory for 3legged behavior): The final customer Secret.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected new void InitUntrusted(BVMode mode
            , string consumer, string consumerSecret
            , string token = "", string tokenSecret = "")
        {
            base.InitUntrusted(mode, consumer, consumerSecret, token, tokenSecret);
            InitApiUrlAndObjects();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Provides access not just to the geographical coordinates of a terminal 
        /// where Location is expressed through: latitude, longitude, altitude and accuracy.
        /// But also to the actual location addresses i.e. street, postal code, etc.  </summary>
        /// <param name="accuracy">The desired accuracy of the location Info, in meters.</param>
        /// <param name="locatedParty">The Identifier of the device which location is going to be retrieved.</param>
        /// <returns> An Object with the requested info</returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected LocationInfo GetLocationProcess(int accuracy, Location.Schemas.UserIdType locatedParty)
        {
            var parameters = CreateParameters();

            if (accuracy > 0)
            {
                parameters.Add("acceptableAccuracy", accuracy.ToString());
            }
            else if (accuracy < 0)
            {
                throw new BlueviaException("Accuray must be a value bigger than 0"
                        , ExceptionCode.InvalidArgumentException);
            }
            string party = string.Format("{0}:{1}",
                locatedParty.ItemElementName, locatedParty.Item);

            parameters.Add(Constants.LocatedPartyKey, party);

            //Dont need to select the apropiate parser/serializer for the operation:

            //The Bluevia´s complex response object, as result of the call:
            LocationDataType locationDataType = BaseRetrieve<Schemas.LocationDataType>(
                string.Format(url, Constants.LocationTerminalGetLocation)
                ,parameters);

            return LocationSimplifiers.SimplifyLocationDataType(locationDataType);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function concatenates the api string into the url, 
        /// and instantiates the parsers and serializers.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InitApiUrlAndObjects()
        {
            url = string.Format(url, string.Format(Constants.apiLocation, sandboxString));
            //As the whole api uses the same parser, 
            //is instanciated and fixed
            parser = new XMLParser();
        }

    }
}
