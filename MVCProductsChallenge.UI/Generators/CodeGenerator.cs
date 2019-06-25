using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProductsChallenge.UI.Generators
{
    public static class CodeGenerator
    {
        private const string CODE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz1234567890";
        private static readonly int _charactersLength = CODE_CHARACTERS.Length;
        private static readonly Random random = new Random();

        public static string GenerateCode(int maxCharacters = 5)
        {
            string code = string.Empty;

            for (int i = 0; i < maxCharacters; i++)
            {
                int index = random.Next(_charactersLength);
                code += CODE_CHARACTERS[index];
            }

            return code;
        }
    }
}