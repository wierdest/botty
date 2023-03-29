using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharExtensions
{
    public static bool IsVowel(this char c)
    {
        return "aeiouáéíóúâêîôûàèìòùäëïöüãẽĩõũ".Contains(c, StringComparison.InvariantCultureIgnoreCase);
    }
} 