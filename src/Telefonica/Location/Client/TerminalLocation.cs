// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia.Core;
using Common = Bluevia.Core.Schemas;

namespace Bluevia.Location.Client
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    ///     This functional block covers the set of functionality related to get the location of the users device.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class TerminalLocation : BaseClient, Bluevia.Location.Client.ITerminalLocation
    {
        public TerminalLocation (IServiceBuilder builder) : base(builder) { }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>provides access not just to the geographical coordinates of a terminal where Location is expressed through a latitude, longitude, altitude and accuracy,
        /// but also to the actual location addresses i.e. street, postal code, etc.  </summary>
        /// <param name="terminalLocationParams">A list of parameters needed to make the Location petition</param>
        /// <returns> An Object with the requested info</returns>
        /// ///////////////////////////////////////////////////////////////////////
        public Schemas.TerminalLocationListType GetLocation(Schemas.TerminalLocationParams terminalLocationParams)
        {
            Schemas.TerminalLocationListType terminalLocationListType = null;
            Schemas.LocationDataType locationDataType = null;

            // Build map with request params
            var requestParams = new List<KeyValuePair<string, string>>();
           

            string party = Location.Schemas.ItemChoiceType1.alias + ":" + BlueviaConsumer.TokenManager.getActiveToken() ;
            requestParams.Add(new KeyValuePair<string, string>("locatedParty", party));

            // optional 
            if (!string.IsNullOrEmpty(terminalLocationParams.AcceptableAccuracy)) requestParams.Add(new KeyValuePair<string, string>("acceptableAccuracy", terminalLocationParams.AcceptableAccuracy));

            
            callBuilder
                .SetBaseUri(Bluevia.Core.Configuration.UriManager.Location_Terminal_GetLocation)
                .AddQueryString(Common.QueryString.currentVersion)
                .AddQueryString(requestParams)
                .SetMethod(Bluevia.Core.Schemas.WebMethod.Get)
                .AddAcceptableStatus(200);

                callBuilder
                    .SetCallback(resp => { locationDataType = resp.ParseXml<Schemas.LocationDataType>(); })
                    .Call();
                
                terminalLocationListType=new Schemas.TerminalLocationListType();
                terminalLocationListType.terminalLocation = new Schemas.LocationDataType[1];
                terminalLocationListType.terminalLocation[0] = locationDataType;
          
            return terminalLocationListType;

        }


        

    }
}
