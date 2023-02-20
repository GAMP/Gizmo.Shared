using System;

namespace Gizmo
{
    /// <summary>
    /// Key generation characters.
    /// </summary>
    [Flags()]
    public enum KeyGenerationCharacters
    {
        /// <summary>
        /// Generated keys will contain numbers. 
        /// </summary>
        Numeric = 1,

        /// <summary>
        /// Generated keys will contain upper case characters. 
        /// </summary>
        UpperCaseCharacters = 2,

        /// <summary>
        /// Generated keys will contain numbers and upper case characters. 
        /// </summary>
        Alphanumeric = Numeric | UpperCaseCharacters
    }
}