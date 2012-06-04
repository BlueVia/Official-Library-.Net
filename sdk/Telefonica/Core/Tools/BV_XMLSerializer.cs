// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BV_XMLSerializer.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to serialize a bluevia object into a sendable byteArray.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BV_XMLSerializer: ISerializer
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to transform a full builded object from the Bluevia Schemas,
        /// to a single XML byte array, by creating the proper nameSpace, and calling the generic
        /// serialize XMLSerializer method.</summary>
        /// <remarks>   2012/03/16. </remarks>
        /// <typeparam name="T">The type of the Schemas object.</typeparam>
        /// <param name="entity">Bluevia Schemas object to be serialized.</param>
        /// <returns> The serialized object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] Serialize<T>(T entity)
        {
            /// <value>The object namespace.</value>
            string nameSpace;

            if (entity == null)
            {
                return null;
            }

            nameSpace = typeof(T).Namespace;
            System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();

            //Mandatory namespace
            ns.Add("com", Constants.spaceNameCommon);

            //API dependant namespace
            //ATTENTION: To consider that, if new services added, use POST application/xml bodies
            //Probably the nameSpace should be added here.
            if (nameSpace.Contains("Directory")) 
            {
                ns.Add("dir", Constants.spaceNameDirectory);
            }
            if (nameSpace.Contains("MMS"))
            {
                ns.Add("mms", Constants.spaceNameMMS);
            }
            if (nameSpace.Contains("SMS"))
            {
                ns.Add("sms", Constants.spaceNameSMS);
            }                

            XMLSerializer xmlSerializer = new XMLSerializer();
            xmlSerializer.nameSpace = ns;
            return xmlSerializer.Serialize(entity);
        }
    }
}
