using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Coaching coaching = new Coaching("Horse riding", 8, "like, 8?", 60.0m);
            coaching.DisplayDetails();
        }
    }
}
