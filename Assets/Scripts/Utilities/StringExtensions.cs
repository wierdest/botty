using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

// collection of string extensions using LINQ to query

public static class StringExtensions
{
    public static string ReplaceAllLettersWithUnderline(this string str)
    {
        return new string(str.Select(c => char.IsLetter(c) ? '_' : c).ToArray());
    }

    public static string ReplaceHalfLettersWithUnderlineAtRandom(this string str)
    {
        string newString = "";
        int count = str.Length / 2;
        foreach(char c in str)
        {
            int chance = ThreadSafeRandom.ThisThreadRandom.Next(0, 4);
            if(char.IsLetter(c) && count > 0 && chance > 2)
            {
                count--;
                newString += '_';
                continue;
            }
            newString += c;
        }
        return newString;
    }

    public static string ReplaceVowelsWithUnderline(this string str)
    {
        return new string(str.Select(c => c.IsVowel() ? '_' : c).ToArray());
    }

    public static string ReplaceNonVowelsWithUnderline(this string str)
    {
        return new string(str.Select(c => !c.IsVowel() ? '_' : c).ToArray());
    }

    public static string ShuffleString(this string str)
    {
        char[] list = str. ToArray();
        list.Shuffle();
        return new string(list.ToArray());
    }

    public static string RemoveLastIfPunctuation(this string str)
    {
        return char.IsPunctuation(str.Last()) ? str.Remove(str.Length - 1) : str;
    }

    public static string RemoveFirstIfPunctuation(this string str)
    {
        return !string.IsNullOrEmpty(str) && char.IsPunctuation(str.First()) ? str.Remove(0) : str;
    }

    public static string RemoveFirstAndLastPunctuation(this string str)
    {
        string original = str;
        str = str.RemoveFirstIfPunctuation();
        if(string.IsNullOrEmpty(str))
        {
            return original;
        }

        str = str.RemoveLastIfPunctuation();
        if(string.IsNullOrEmpty(str))
        {
            return original;
        }
        return str;
    }

    public static string MakeOrdinal(this string str, int number)
    {
        switch(number % 10)
        {
            case 1:
                str = string.Concat(number, "st");
                break;
            case 2: 
                str = string.Concat(number, "nd");
                break;
            case 3: 
                str = string.Concat(number, "rd");
                break;
            default:
                str = string.Concat(number, "th");
                break;
        }
        return str;
    }

    public static string Plural(this string str, int value, string plural = "s")
    {
        // default plural is s
        return value > 1 || value <= 0 ? str + plural : str;
    }

} 
