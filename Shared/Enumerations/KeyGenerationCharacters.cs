using System;
using System.ComponentModel.DataAnnotations;

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
        [Name("Numeric", "KEY_GENERATION_CHARACTERS_NUMERIC")]
        Numeric = 1,

        /// <summary>
        /// Generated keys will contain upper case characters. 
        /// </summary>
        [Name("Upper Case Characters", "KEY_GENERATION_CHARACTERS_UPPER_CASE_CHARACTERS")]
        UpperCaseCharacters = 2,

        /// <summary>
        /// Generated keys will contain numbers and upper case characters. 
        /// </summary>
        [Name("Alphanumeric", "KEY_GENERATION_CHARACTERS_ALPHANUMERIC")]
        Alphanumeric = Numeric | UpperCaseCharacters
    }
}
