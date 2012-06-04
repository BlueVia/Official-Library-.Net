// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="IExample.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> Interface wich describes the examples functionality</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    interface IExample
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> This function retrives a textual description of the example's functionality.</summary>
        /// <returns>A string with the example's description.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        string getDescription();
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> this function executes the example.</summary>
        /// <param name="consumer">The appplication Identifier</param>
        /// <param name="ckey">The application Secret</param>
        /// <param name="token">The final customer Identifier</param>
        /// <param name="secret">The final customer Secret</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        void call(String consumer, String ckey, String token, String secret);
    }
}