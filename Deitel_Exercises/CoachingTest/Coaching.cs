using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingTest
{
    class Coaching
    {
        private string Type { get; set; }
        private int Players { get; set; }
        private string ClassTimings { get; set; }
        private decimal Charges { get; set; }

        public Coaching(string type, int players, string classTimings, decimal charges)
        {
            Type = type;
            Players = players;
            ClassTimings = classTimings;
            Charges = charges;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Type: {Type}    Players: {Players}      Timings: {ClassTimings}     Charges: {Charges:c}");
            Console.ReadLine();
        }
    }
}
