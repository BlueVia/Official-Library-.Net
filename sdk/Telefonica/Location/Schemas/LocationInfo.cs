// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Location.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="LocationInfo.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Object to contain the Location Info data.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class LocationInfo
    {
        /// <value>Element indicating whether the response contains valid location data, or an error has occurred.</value>
        public string reportStatus;

        /// <value>The device's latitude.</value>
        public float coordinatesLatitude;

        /// <value>The device's longitude.</value>
        public float coordinatesLongitude;

        /// <value>Accuracy of location provided in meters.</value>
        public int accuracy;

        /// <value>Date and time that location was collected.</value>
        public string timestamp;
    }
}
