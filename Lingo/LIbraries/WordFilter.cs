using System;
using System.Linq;
//TEST WORD FILTER IN TEST UNIT TEST CLASS
public sealed class WordFilter
{
    /// <summary>
    /// Singleton for WordFilter
    /// </summary>
	private static WordFilter _instance = null;

    public static WordFilter Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WordFilter();
            }
            return _instance;
        }
    } 

    /// <summary>
    /// Checks if letter count matches word length
    /// </summary>
    /// <param name="word"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public Boolean FilterLetterCount(String word, int count)
    {
        return word.Length == count ? true : false;
    }

    /// <summary>
    /// Checks if word is lowercase
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public Boolean FilterLowercaseLetters(String word)
    {
        return word.Any(c => char.IsUpper(c)); 
    }

    /// <summary>
    /// Checks if a word has punctuation
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public Boolean FilterNoPunctuation(String word)
    {
        return word.Any(c => char.IsPunctuation(c));
    }

}
