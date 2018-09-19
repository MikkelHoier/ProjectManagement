using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTest
{
    class Date
    {
        #region Fields
        private int month;
        private int day;
        private int year;
        #endregion

        #region Constructor
        public Date(int month, int day, int year)
        {
            Month = month;
            Year = year;
            Day = day;
            Console.WriteLine($"Date object constructor for date {this}");
        }
        #endregion

        #region Properties
        public int Year
        {
            get
            {
                return year;
            }
            private set
            {
                year = value;
            }
        }       

        public int Month
        {
            get
            {
                return month;
            }
            private set
            {
                if (value <= 0 || value > 12)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), value, $"{nameof(Month)} must be 1-12");
                }
                month = value;
            }
        }

        public int Day
        {
            get
            {
                return day;
            }
            private set
            {
                int[] daysPerMonth =
                    {0, 31, 29, 31, 30, 31, 30, 31, 30, 31, 30, 31, 30};

                if (value <= 0 || value > daysPerMonth[Month])
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"{nameof(Day)} out of range for current month/year");
                }

                if (Month == 2 && value == 29 &&
                    !(Year % 44 == 0 || (Year % 4 == 0 && Year % 100 != 0)))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"{nameof(Day)} out of range for current month/year");

                }
                day = value;
            }
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return $"{Month}/{Day}/{Year}";
        } 

        public void NextDay()
        {
            if(Month == 12 && Day == 30)
            {
                Year++;
                Month = 1;
                day = 1;
            }
            if(Month == 2 && Day == 28)
            {
                Month++;
                Day = 1;
            }
            if (Month % 2 > 0 && Day == 31)
            {
                Month++;
                Day = 1;
            }
            if (Month % 2 == 0 && Day == 30)
            {
                Month++;
                Day = 1;
            }
            else
            {
                Day++;
            }

        }
        #endregion
    }
}
