using System;
using System.Linq;
using System.Text.RegularExpressions;
//TEST WORD FILTER IN TEST UNIT TEST CLASS
public sealed class WordFilter
{
    /// <summary>
    /// Matches words on lowercase letters with length of 5 to 7
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public static bool FilterWord(String word)
    {
        var regex = new Regex(@"^[a-z]{5,7}$");
        return regex.IsMatch(word);
    }
}
