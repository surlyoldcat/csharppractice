using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFBD.Arr
{
    internal static class Transformer
    {
        static readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
        
        public static char[] Transform(char[] arr)
        {
            // do a reverse, do a projection, check to
            //see if a char is a vowel. note, i just included
            //both cases in the vowels array, instead of
            //having an extra ToLowerInvariant call on each            
            var transformed = arr.Reverse().Select(c =>
            {
                return Vowels.Contains(c) ? Char.ToUpperInvariant(c) : Char.ToLowerInvariant(c);
                
            });
            return transformed.ToArray();
        }
    }
}
