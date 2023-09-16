using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /*
     * 383. Ransom Note
Solved
Easy
Topics
Companies
Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

Each letter in magazine can only be used once in ransomNote.

 

Example 1:

Input: ransomNote = "a", magazine = "b"
Output: false
Example 2:

Input: ransomNote = "aa", magazine = "ab"
Output: false
Example 3:

Input: ransomNote = "aa", magazine = "aab"
Output: true
 

Constraints:

1 <= ransomNote.length, magazine.length <= 105
ransomNote and magazine consist of lowercase English letters.
     */

    public partial class Solution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            char[] ransomNoteCharArray = ransomNote.ToCharArray();
            List<char> magazineCharArray = magazine.ToCharArray().ToList();


            for (int i = 0; i < ransomNoteCharArray.Length; i++)
            {
                if (!magazineCharArray.Contains(ransomNoteCharArray[i]))
                {
                    return false;
                }

                magazineCharArray.Remove(ransomNoteCharArray[i]);
            }

            return true;
        }
    }
}
