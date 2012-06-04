// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.Core.Tools
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Extension.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>   Method extensions, and common tools. </summary>
    /// <remarks>   2012 04 13. This class has been cleaned from version 1.5</remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class Extension
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtains the before last element (or the default element). </summary>
        /// <remarks>   22/04/2010. </remarks>
        /// <typeparam name="T">The type of the list contents.</typeparam>
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
        /// <typeparam name="T">The type of the list contents.</typeparam>
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

        //ENCODING WITHOUTBOM
        public static Encoding encodingWithoutBOM = new System.Text.UTF8Encoding(false);

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
        /// <summary>This function checks if a generic number parameter isn't null,
        /// and matches numeric format.</summary>
        /// <param name="number">The number to be checked. </param>
        /// <param name="name">The name of the parameter that is going to be checked.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void checkIsNumber(string number, string name)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new Core.Schemas.BlueviaException("Null or empty " + name + " when using service."
                        , Core.Schemas.ExceptionCode.InvalidArgumentException);
            }
            long result = 0;
            bool isNumericDestination = false;
            isNumericDestination = long.TryParse(number, out result);
            if (!isNumericDestination || result <= 0)
            {
                throw new Core.Schemas.BlueviaException("Invalid " + name + ": " + number + ", when using service."
                    , Core.Schemas.ExceptionCode.InvalidArgumentException);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function counts the number of string occurrences in a text.
        /// <a href="http://www.dotnetperls.com/string-occurrence">dotnetperls</a></summary>
        /// <param name="text"> The text to explore. </param>
        /// <param name="pattern"> The pattern to be counted. </param>
        /// <returns> The number of occurrences of the patern in the text. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }



    }
}
