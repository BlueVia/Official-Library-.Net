// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

using Bluevia.Location.Schemas;

namespace Bluevia.Location.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="LocationSimplifiers.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class for response simplifier functions of Location API.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class LocationSimplifiers
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Converts a complex LocationDataType object, into a LocationInfo object.</summary>
        /// <param name="locationDataType">A complex LocationDataType.</param>
        /// <returns>The simplified location data in a LocationInfo object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static LocationInfo SimplifyLocationDataType(LocationDataType locationDataType)
        {
            LocationInfo locationInfo = null;
            if (locationDataType != null)
            {
                locationInfo = new LocationInfo()
                {
                    reportStatus = Convert.ToString(locationDataType.reportStatus),
                    coordinatesLatitude = locationDataType.currentLocation.coordinates.latitude,
                    coordinatesLongitude = locationDataType.currentLocation.coordinates.longitude,
                    accuracy = locationDataType.currentLocation.accuracy,
                    timestamp = Convert.ToString(locationDataType.currentLocation.timestamp)
                };
            }
            return locationInfo;
        }
    }
}
