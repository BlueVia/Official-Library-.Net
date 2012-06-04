// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- //

namespace Bluevia.Advertising.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="CreativeElement.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Object that describes the different elements that shape the adsource. For 
    /// instance an small banner link in line, could have two objects (image&amp;text).</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public struct CreativeElement
    {
        /// <value> Category of the ad. Values included image, text.<see cref="TypeId"/></value>
        public TypeId type;

        /// <value> Tag used to invoke events, e.g: it contains the locator of click through URI. 
        /// When using isOfflineClient, there would be as many interaction elements as needed 
        /// in order to receive all the information the offline client will need (without ad-server connectivity) 
        /// for performing the interaction.</value>
        public string interaction;

        /// <value> It's the part of the ad that the user is going to see (a text or an Image).</value> 
        public string value;
    }
}
