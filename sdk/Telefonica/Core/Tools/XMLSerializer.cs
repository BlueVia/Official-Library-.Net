// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Text;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="XMLSerializer.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to serialize a bluevia object into a sendable byteArray.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class XMLSerializer : ISerializer
    {
        public System.Xml.Serialization.XmlSerializerNamespaces nameSpace = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to transform a full builded object into a single XML string.</summary>
        /// <remarks>   2012/03/05. </remarks>
        /// <typeparam name="T">The type of the Schemas object.</typeparam>
        /// <param name="entity">Bluevia Schemas object to be serialized.</param>
        /// <returns> The serialized object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] Serialize<T>(T entity)
        {
            byte[] xmlizedEntity = null;

            if(entity==null){
                return xmlizedEntity;
            }
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                if(nameSpace!=null){
                    serializer.Serialize(stream, entity, nameSpace);
                }else{
                    serializer.Serialize(stream, entity);
                }
                xmlizedEntity = stream.ToArray();                
            }

            return xmlizedEntity;
        }
    }
}
