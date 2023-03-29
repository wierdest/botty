using System;
using System.Collections;
using System.Collections.Generic;

public static class NumberToWordsConverter
{
    private static string[] units = 
    {
        "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", 
        "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" 
    };
    private static string[] tens = 
    {
        "Zero", "Ten", "Twenty","Thirty", "Forty",  "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" 
    };

    public static string Convert(int number, bool sentenceCase = false, bool allCaps = false)
    {
        if(number == 0)
        {
            return getCase(units[0].ToString(), sentenceCase, allCaps);
        }
        if(number < 0)
        {    
            return string.Concat(getCase("Minus ", sentenceCase, allCaps), Convert(Math.Abs(number)));
        }

        string words = "";

        if((number / 1000000) > 0)
        {
            words = string.Concat(Convert(number / 1000000), getCase(" Million ", sentenceCase, allCaps));
            number %= 1000000;
        }

        if((number / 1000) > 0)
        {
            words = string.Concat(words, Convert(number / 1000) + getCase(" Thousand ", sentenceCase, allCaps));
            number %= 1000;
        }

        if((number / 100) > 0)
        {
            words = string.Concat(words, Convert(number / 100) + getCase(" Hundred ", sentenceCase, allCaps ));
            number %= 100;
        }

        if((number > 0))
        {
            if(!string.IsNullOrEmpty(words))
            {
                words = string.Concat(words, getCase("And ", sentenceCase, allCaps));
            }

            if(number < 20)
            {
                words = string.Concat(words, getCase(units[number], sentenceCase, allCaps));
            }
            else
            {
                words = string.Concat(words, getCase(tens[number / 10], sentenceCase, allCaps));
                if((number % 10) > 0)
                {
                    words = string.Concat("-", getCase(units[number %10], sentenceCase, allCaps));
                }
            }
        }
        return words;
    }

    private static string getCase(string str, bool sc, bool ac)
    {
        return sc? str : ac? str.ToUpper() : str.ToLower();
    } 


};

