using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLabel
{
    public int number;
    public string label;
    public NumberLabel FromNumber(int n)
    {
        return new NumberLabel()
        {
            number = n,
            label = NumberToWordsConverter.Convert(n)
        };
    }
}
