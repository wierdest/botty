using System;
using System.Threading;

public static class ThreadSafeRandom
    {
        [ThreadStatic] private static System.Random Local;
        public static System.Random ThisThreadRandom
        {
            get 
            { 
                return Local ?? (Local = new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));
            }
        }
    }
