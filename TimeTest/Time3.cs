using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTest
{
    class Time3
    {        
        private int totalSeconds;

        public Time3(int hour = 0, int minute = 0, int second = 0)
        {
            SetTime(hour, minute, second);
        }

        public Time3(Time3 time)
            : this(time.Hour, time.Minute, time.Second) { }

        public void SetTime(int hour, int minute, int second)
        {            
            if(hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour),
                   hour, $"{nameof(hour)} must be 0-23");
            }
            else if(minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minute),
                    minute, $"{nameof(minute)} must be 0-59");
            }
            else if(minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second),
                    second, $"{nameof(minute)} must be 0-59");
            }
            TotalSeconds = second + (minute*60) + (hour*3600);
        }

        public int TotalSeconds { get; set; }

        public int Hour
        {
            get
            {
                return TotalSeconds / 3600; 
            }
            
        }

        public int Minute
        {
            get
            {
                return (TotalSeconds / 60) % 60;
            }
            
        }

        public int Second
        {
            get
            {
                return TotalSeconds % 60;
            }                        
        }

        public string ToUniversalString() =>
            $"{Hour:D2}:{Minute:D2}:{Second:D2}";

        public override string ToString() =>
            $"{((Hour == 0 || Hour == 12) ? 12 : Hour % 12)}:" +
            $"{Minute:D2}:{Second:D2} {(Hour < 12 ? "AM" : "PM")}";
    }
}
