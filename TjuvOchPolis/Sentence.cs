using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TjuvOchPolis
{
    class Sentence
    {
        public Person Inmate { get; set; }
        public long Time { get; set; }

        public Sentence(Person inmate)
        {
            Inmate = inmate;
            Time = DateTime.Now.Ticks;
        }

        public double TimeElapsed()
        {
            TimeSpan elapsedSpan = new TimeSpan(DateTime.Now.Ticks - Time);
            return elapsedSpan.TotalSeconds;
        }
    }
}
