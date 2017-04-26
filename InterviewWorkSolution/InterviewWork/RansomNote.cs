using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork
{
    internal class RansomNote
    {
        public static bool CanMakeNoteFromMagazine(string note, string magazine)
        {
            string[] notewords = note.Split(' ');
            string[] magwords = magazine.Split(' ');
            return CanMakeNoteFromMagazine(notewords, magwords);
        }

        public static bool CanMakeNoteFromMagazine(string[] note, string[] magazine)
        {
            HashSet<string> magWords = new HashSet<string>(magazine, StringComparer.CurrentCulture);
            
            bool magHasAllWords = true;
            foreach (string word in note)
            {
                if (!String.IsNullOrEmpty(word))
                {
                    var magWord = magWords.FirstOrDefault(w => w == word);
                    if (null == magWord)
                    {
                        magHasAllWords = false;
                        break;
                    }
                    else
                    {
                        magWords.Remove(word);
                    }
                }
            }

            return magHasAllWords;
        }
    }
}
