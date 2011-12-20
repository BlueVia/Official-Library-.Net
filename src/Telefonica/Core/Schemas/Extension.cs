// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DotNetOpenAuth.Messaging;
using System.IO;

namespace Bluevia.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Method extensions. </summary>
    /// <remarks>   22/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class Extension
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtains the before last element (or the default element). </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T">    </typeparam>
        /// <param name="list"> List of elements. </param>
        /// <returns>   Before last / default item. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static T BeforeLastOrDefault<T>(this IEnumerable<T> list)
        {
            return list.Reverse().Skip(1).FirstOrDefault();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Before last. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T">    . </typeparam>
        /// <param name="list"> List of elements. </param>
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static T BeforeLast<T>(this IEnumerable<T> list)
        {
            return list.Reverse().Skip(1).First();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a value to a string 1 or 0. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="value">    Instance. </param>
        /// <returns>   This object as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ToString1Or0(this bool value)
        {
            return value ? "1" : "0";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Uri Header location. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="instance"> The instance. </param>
        /// <returns>   Uri. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Uri HeadersLocation(this DotNetOpenAuth.Messaging.IncomingWebResponse instance)
        {
            return new Uri(instance.Headers["Location"]);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an enum value from the string value. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T">    . </typeparam>
        /// <param name="value">    Instance. </param>
        /// <returns>   Enum. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static T EnumParse<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a flag enumeration to an string concatenation of the values. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T"> Enum type. </typeparam>
        /// <param name="flags"> The (enum) flags. </param>
        /// <returns>   This object as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ToFlagString<T>(this T flags)
        {
            // Check null argument
            if (flags == null)
                throw new ArgumentNullException();

            // Check argument type
            Type typeofFlag = typeof(T);
            if (!typeofFlag.IsEnum)
                throw new ArgumentException();
            
            // Extract enum values
            var values = Enum.GetValues(typeofFlag);

            List<string> flagValues = new List<string>();
            foreach (dynamic item in values)
            {
                if ((flags & item) == item)
                    flagValues.Add(Enum.Format(typeofFlag, item, "g"));
            }
            return String.Join(",", flagValues.ToArray());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a flag enumeration to an quoted string concatenation of the values. </summary>
        /// <remarks>   26/11/2010. </remarks>
        /// <typeparam name="T"> Enum type. </typeparam>
        /// <param name="flags"> The (enum) flags. </param>
        /// <returns>   This object as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ToFlagStringQuoted<T>(this T flags)
        {
            return "'" + ToFlagString<T>(flags)+ "'";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Format an string with some values. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        /// <returns>   The formatted with. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string FormatWith(this string format, params object[] args)
        {
            return String.Format(format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Format an string with some values with an invariant culture. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="format">   Instance. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        /// <returns>   The formatted string with invariant culture. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string FormatWithInvariantCulture(this string format, params object[] args)
        {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts an input to a base 64 string. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="input">    The input. </param>
        /// <returns>   This object as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ToBase64String(this byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the bytes. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="input">    The input. </param>
        /// <returns>   The bytes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static byte[] GetBytes(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        private static System.Xml.XmlReaderSettings xmlReaderSettings = new System.Xml.XmlReaderSettings()
            {
                CloseInput = true,
                ConformanceLevel = System.Xml.ConformanceLevel.Auto,
                MaxCharactersInDocument = 0,
                IgnoreWhitespace = true,
                IgnoreProcessingInstructions = true,
                DtdProcessing = System.Xml.DtdProcessing.Ignore,
            };

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Parse the response xml to an object. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T">    . </typeparam>
        /// <param name="response"> The response. </param>
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static T ParseXml<T>(this DotNetOpenAuth.Messaging.IncomingWebResponse response)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (var x = System.Xml.XmlReader.Create(response.ResponseStream, xmlReaderSettings))
            {
                return (T)xmlSerializer.Deserialize(x);
            }
        }

        public static T ParseXmlInMultiFile<T>(this DotNetOpenAuth.Messaging.IncomingWebResponse response)
        {
            string boundary = "--" + response.ContentType.Boundary;
            StringBuilder xml = new StringBuilder();
            using (var reader = response.GetResponseReader())
            {
                while (reader.ReadLine() != boundary) ; // reach up to boundary
                while (reader.ReadLine().Length != 0) ; // reach up to body

                string line = string.Empty;
                while (!(line = reader.ReadLine()).StartsWith(boundary, StringComparison.CurrentCultureIgnoreCase)) // read until next boundary
                {
                    xml.Append(line);
                };
            }

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(new System.IO.StringReader(xml.ToString()));
        }

        public static Bluevia.Core.Schemas.MIMEContent ParseAttachment(this DotNetOpenAuth.Messaging.IncomingWebResponse response)
        {
            Bluevia.Core.Schemas.MIMEContent mime = new Schemas.MIMEContent ();

            string boundary = "--" + response.ContentType.Boundary;
            StringBuilder file = new StringBuilder();
            using (var reader = response.GetResponseReader())
            {
                string line = string.Empty;

                while (reader.ReadLine() != boundary) ; // reach up to boundary
                while ((line = reader.ReadLine()).Length != 0) {
                    if (line.StartsWith("content-type", StringComparison.CurrentCultureIgnoreCase))
                    {
                        System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType(line.Substring(line.IndexOf(':') + 1).Trim());
                        mime.ContentType = contentType;
                    }
                } // reach up to body

                while (!(line = reader.ReadLine()).StartsWith(boundary, StringComparison.CurrentCultureIgnoreCase)) // read until next boundary
                {
                    file.Append(line);
                };

                mime.Content = reader.CurrentEncoding.GetBytes(file.ToString());
            }

            return mime;
        
        }

        private static System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings()
        {
            Encoding = new System.Text.UTF8Encoding(false), OmitXmlDeclaration = true
        };
        private static Encoding encodingWithoutBOM = new System.Text.UTF8Encoding(false);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a content as xml. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="instance"> The instance. </param>
        /// <param name="obj">      The object. </param>
        /// <param name="type">     The type. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void SetContentAsXml(this System.Net.HttpWebRequest instance, object obj, Type type)
        {
            instance.ContentType = "application/xml; charset=utf-8";
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("com", "http://www.telefonica.com/schemas/UNICA/REST/common/v1");
            ns.Add("sms", "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/");
            ns.Add("mms", "http://www.telefonica.com/schemas/UNICA/REST/mms/v1/");
            ns.Add("dir", "http://www.telefonica.com/schemas/UNICA/REST/directory/v1/");

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                serializer.Serialize(ms, obj, ns);
                var bytes = ms.ToArray();
                instance.ContentLength = bytes.Length;
                using (var requestStream = new System.IO.StreamWriter(instance.GetRequestStream(), encodingWithoutBOM))
                {
                    requestStream.BaseStream.Write(bytes, 0, bytes.Length);
                }
            }                       
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the Content as url encoded, for form Post like requests. </summary>
        ///
        /// <remarks>   22/08/2010. </remarks>
        ///
        /// <param name="instance">     Http request. </param>
        /// <param name="queryString">  Data content. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void SetContentAsUrlEncoded(this System.Net.HttpWebRequest instance, ICollection<KeyValuePair<string, string>> queryString)
        {
            var body = string.Join("&", queryString.Select(q => q.Key + "=" + Uri.EscapeDataString(q.Value)).ToArray());
            instance.ContentType = "application/x-www-form-urlencoded";
            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            instance.ContentLength = bodyBytes.Length;

            using (var requestStream = new System.IO.StreamWriter(instance.GetRequestStream(), encodingWithoutBOM))
            {
                requestStream.BaseStream.Write(bodyBytes, 0, bodyBytes.Length);
            }
        }

        internal static MultipartPostPart SetAttachmentAsXml (object entity, Type type)
        {
            MultipartPostPart post = new MultipartPostPart("form-data");
            var stream = new System.IO.MemoryStream();
            var contentLength = SerializeEntityIntoStream(stream, entity, type);
            post.Content = new System.IO.MemoryStream(stream.ToArray());
            post.ContentAttributes.Add("name", "root-fields");
            // post.ContentAttributes.Add("filename", "root-field");
            post.PartHeaders.Add("Content-Type", "application/xml");
            post.PartHeaders.Add("Content-Transfer-Encoding", "binary");
            post.PartHeaders.Add("Content-Length", contentLength.ToString());
            return post;
        }

        internal static MultipartPostPart SetAttachmentAsXml(string filePath, string mimeType)
        {
            MultipartPostPart post = new MultipartPostPart("form-data");
            post.Content = System.IO.File.OpenRead(filePath);

            post.ContentAttributes.Add("name", "attachments");
            post.ContentAttributes.Add("filename", System.IO.Path.GetFileName(filePath));
            post.PartHeaders.Add("Content-Type", mimeType);
            post.PartHeaders.Add("Content-Transfer-Encoding", "binary");
            post.PartHeaders.Add("Content-Length", post.Content.Length.ToString());
            return post;
        }

        internal static MultipartPostPart SetAttachmentAsXml(System.IO.Stream data, string mimeType, string filename)
        {
            MultipartPostPart post = new MultipartPostPart("form-data");
            post.Content = data;

            post.ContentAttributes.Add("name", "attachments");
            post.ContentAttributes.Add("filename", filename);
            post.PartHeaders.Add("Content-Type", mimeType);
            post.PartHeaders.Add("Content-Transfer-Encoding", "binary");
            post.PartHeaders.Add("Content-Length", post.Content.Length.ToString());
            return post;
        }

        private static int SerializeEntityIntoStream (System.IO.Stream stream, object obj, Type type)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("com", "http://www.telefonica.com/schemas/UNICA/REST/common/v1");
            ns.Add("sms", "http://www.telefonica.com/schemas/UNICA/REST/sms/v1/");
            ns.Add("mms", "http://www.telefonica.com/schemas/UNICA/REST/mms/v1/");
            ns.Add("dir", "http://www.telefonica.com/schemas/UNICA/REST/directory/v1/");

            
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
            int contentLength = 0;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                serializer.Serialize(ms, obj, ns);
                var bytes = ms.ToArray();
                contentLength = bytes.Length;
                using (var requestStream = new System.IO.StreamWriter(stream, encodingWithoutBOM))
                {
                    requestStream.BaseStream.Write(bytes, 0, bytes.Length);
                }
            }

            return contentLength;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the request to some xml string. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T">    . </typeparam>
        /// <param name="instance"> Instance. </param>
        /// <param name="obj">      The object to convert to xml. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void SetContentAsXml<T>(this System.Net.HttpWebRequest instance, T obj)
        {
            SetContentAsXml(instance, obj, typeof(T));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts a webMethod to a httpDeliveryMethods. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="instance"> Instance. </param>
        /// <returns>   This object as the DotNetOpenAuth.Messaging.HttpDeliveryMethods. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static DotNetOpenAuth.Messaging.HttpDeliveryMethods ToHttpDeliveryMethods(this Bluevia.Core.Schemas.WebMethod instance)
        {
            switch (instance)
            {
                case Bluevia.Core.Schemas.WebMethod.Get:
                    return DotNetOpenAuth.Messaging.HttpDeliveryMethods.GetRequest;
                case Bluevia.Core.Schemas.WebMethod.Post:
                    return DotNetOpenAuth.Messaging.HttpDeliveryMethods.PostRequest;
                case Bluevia.Core.Schemas.WebMethod.Delete:
                    return DotNetOpenAuth.Messaging.HttpDeliveryMethods.DeleteRequest;
                case Bluevia.Core.Schemas.WebMethod.Put:
                    return DotNetOpenAuth.Messaging.HttpDeliveryMethods.PutRequest;
                default:
                    return DotNetOpenAuth.Messaging.HttpDeliveryMethods.None;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Object to string xml. </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T">    . </typeparam>
        /// <param name="instance"> The instance. </param>
        /// <returns>   String. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ObjectToStringXml<T>(object instance)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            using (System.IO.StringWriter stringWriter = new System.IO.StringWriter (sb))
            {
                xs.Serialize(stringWriter, instance);
            }

            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Add a key/value pair.</summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <param name="instance"> Instance. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    Value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Add(this ICollection<KeyValuePair<string, string>> instance, string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                instance.Add(new KeyValuePair<string, string>(key, value));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the web response in string format with ASCII encoding
        /// </summary>
        /// <param name="response">Stream of response</param>
        /// <returns></returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string WebResponseToString(System.IO.Stream response)
        {
            System.IO.StreamReader oReader = new System.IO.StreamReader(response, Encoding.ASCII);
            return oReader.ReadToEnd();
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   List of pairs Key-Value to use in case that content-type is x-www-formurlencoded </summary>
    /// <remarks>   23/03/2011. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class KeyValueUrl : List<KeyValuePair<string, string>>
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Parses the object KeyValueUrl to an IDictionary object to manage OAuth calls.
        /// The KeyValue should be sort by name, using ascending byte value ordering. In case two or more parameters share the same name, sort them by value.
        /// </summary>
        /// <returns>   an IDictionary of string string </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IDictionary<string, string> getIDictionary()
        {
            IDictionary<string, string> pairs = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> pair in this)
            {
                pairs.Add(pair);
            }
            return pairs;
        }
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Parser to transform a multipart response into objects. </summary>
    /// <remarks>   19/05/2011. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
        public class Parser
        {

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Defines how the xml parsing must be done. </summary>
            /// <remarks>   19/05/2011. </remarks>
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Parse the xml string to an object. </summary>
        /// <remarks>   19/05/2011. </remarks>
        /// <typeparam name="T"> The xml defined object </typeparam>
        /// <param name="response"> the xml text object. </param>
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static T ParseXml<T>(string response)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var x = System.Xml.XmlReader.Create(new StringReader(response), xmlReaderSettings);
            return (T)xmlSerializer.Deserialize(x);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a Bluevia.Core.Schemas.MIMEContent from an attachment text. </summary>
        /// <remarks>   20/05/2011. </remarks>
        /// <param name="text"> the text with the attachment data. </param>
        /// <param name="bound"> the boundary string. </param>
        /// <returns>   A MIMEContent object. </returns>
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List<Bluevia.Core.Schemas.MIMEContent> ParseAttachment(string text, string bound)
        {
            List<Bluevia.Core.Schemas.MIMEContent> list = new List<Schemas.MIMEContent>();
            Bluevia.Core.Schemas.MIMEContent mime;
            Boolean escape = false;
            int counter = 0;
            string boundary = "--" + bound;
            int pointer = 0;

            System.Net.Mime.ContentType contentType;

            StringBuilder file = new StringBuilder();
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new MemoryStream(byteArray);
            var reader = new System.IO.StreamReader(stream);
            string line = string.Empty;

            while (reader.ReadLine() != boundary) { } // reach up to first boundary

            while (!escape)
            {
                mime = new Schemas.MIMEContent();
                pointer = 0;

                while ((line = reader.ReadLine()).Length != 0)
                {
                    if (line.StartsWith("content-type", StringComparison.CurrentCultureIgnoreCase))
                    {

                        if (line.Contains(";"))//case more options in the same line
                        {
                            string CTLine = line.Substring(line.IndexOf(':') + 1).Trim();
                            pointer = CTLine.IndexOf(";");
                            contentType = new System.Net.Mime.ContentType(CTLine.Substring(0, pointer).Trim());
                            pointer = CTLine.IndexOf("name=");
                            if (pointer != -1)
                            {
                                mime.Name = CTLine.Substring(pointer + 5);
                            }

                        }
                        else//case contentype is alone
                        {
                            contentType = new System.Net.Mime.ContentType(line.Substring(line.IndexOf(':') + 1).Trim());
                        }

                        mime.ContentType = contentType;
                    }
                    else if (line.StartsWith("content-transfer-encoding", StringComparison.CurrentCultureIgnoreCase))
                    {
                        mime.Encoding = line.Substring(line.IndexOf(':') + 1).Trim();
                    }

                    if (string.IsNullOrEmpty(mime.Name))
                    {
                        mime.Name = string.Concat("file", counter);
                    }

                } // reach up to body

                while (!(line = reader.ReadLine()).StartsWith(boundary, StringComparison.CurrentCultureIgnoreCase)) // read until next boundary
                {
                    file.Append(line);
                }

                mime.Content = file.ToString().GetBytes();
                list.Add(mime);

                counter++;
                file.Clear();

                if (line.StartsWith(boundary + "--"))//End of attachment list reached
                {
                    escape = true;
                }
            }
            return list;

        }

        }

    }
