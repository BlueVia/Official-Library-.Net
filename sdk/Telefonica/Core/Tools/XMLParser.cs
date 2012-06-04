// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System.Text;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="XMLParser.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Class to parse a XML message string(in byte arrayformat), into the proper Bluevia Schemas object.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
   public class XMLParser : IParser
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Method to parse a XML string, to a full object from the Bluevia Schemas</summary>
        /// <remarks>   2012/03/07. </remarks>
        /// <param name="stream">An object serialized in a XML string</param>
        /// <typeparam name="T">The object type to be retrieved.</typeparam>
        /// <returns>A full Bluevia Schemas object.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public T Parse<T>(byte[] stream)
        {
            if (stream == null)
            {
                return (T)(object)stream;
            }
            string str = Encoding.Default.GetString(stream);
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var x = System.Xml.XmlReader.Create(new System.IO.StringReader(str), xmlReaderSettings);
            return (T)xmlSerializer.Deserialize(x);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Defines how the xml parsing must be done. </summary>
        /// <remarks>   19/05/2011. </remarks>
        /// <returns> Settings for the xml parser.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static System.Xml.XmlReaderSettings xmlReaderSettings = new System.Xml.XmlReaderSettings()
        {
            CheckCharacters = false,
            CloseInput = true,
            ConformanceLevel = System.Xml.ConformanceLevel.Auto,
            MaxCharactersInDocument = 0,
            IgnoreWhitespace = true,
            IgnoreProcessingInstructions = true,
            DtdProcessing = System.Xml.DtdProcessing.Ignore,
        };
    }
}
