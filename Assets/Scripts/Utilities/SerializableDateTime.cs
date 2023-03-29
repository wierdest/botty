using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDateTime
{
    public int Second, Minute, Hour, Day, Month, Year;
    public long Ticks;

    public SerializableDateTime CreateSerializableDateTime(DateTime dateTime)
    {
        return new SerializableDateTime()
        {
            Second = dateTime.Second,
            Minute = dateTime.Minute,
            Hour = dateTime.Hour,
            Day = dateTime.Day,
            Month = dateTime.Month,
            Year = dateTime.Year,
            Ticks = dateTime.Ticks
            
        }; 
    }

    public override string ToString()
    {
        return string.Format("{0}/{1}/{2} at {3}:{4}:{5}", Day, Month, Year, Hour, Minute, Second);
    }

    public long GetTicks()
    {
        return Ticks;
    }

}


