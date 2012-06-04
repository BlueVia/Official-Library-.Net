// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

namespace Bluevia.Core.Schemas
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="BlueviaException.cs" company="Telefonica R&D">GNU LPL v3.</copyright>
    /// <summary>Exception class with the neccesary data fields for Bluevia using.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class BlueviaException : ApplicationException
    {

        /// <value>The Bluevia service Exception code.</value>
        public string code = string.Empty;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BlueviaException"/>. Void constructor.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BlueviaException() : base() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Initializes a new instance of the <see cref="BlueviaException"/>. Full constructor.</summary>
        /// <param name="message">A message acording to Bluevia using. Either the service or sdk exception.</param>
        /// <param name="code">The Bluevia service Exception code.</param>
        /// <param name="ex">Optional (for cases that another exception has been catched):The internal exception.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public BlueviaException(string message, string code = "", Exception ex = null): base(message,ex) 
        {
            this.code = code;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>Class to contain the list of possible .NET's SDK exceptions, and their codes.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class ExceptionCode
    {
        public static readonly string InvalidArgumentException = "-1";
        public static readonly string ConnectionErrorException = "-2";
        public static readonly string NotImplementedException = "-3";
        //public static readonly string MandatoryParserException = "-6";
        public static readonly string InvalidModeException = "-7";
        public static readonly string InvalidFunctionException = "-8";
        //public static readonly string MandatoryParameterException = "-9";
        public static readonly string ParserErrorException = "-10";
        public static readonly string SerializerErrorException = "-11";

    }

}
