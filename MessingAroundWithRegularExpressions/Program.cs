using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessingAroundWithRegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "wkfk";
            person.Age = 1000;
            Console.ReadLine();
        }
    }

    public class Person
    {
        private string name;

        /*[RegularExpression(@"^[a-zA-Z''-'\s]$",
            ErrorMessage ="Characters are not allowed")]*/
        [StringLength(2, ErrorMessage ="google")]


        [Range(1, 100, ErrorMessage = "Price must be between $1 and $100")]
        public int Age { get; set; }

        [StringLength(2, ErrorMessage = "google")]
        public string Name { get => name; set => name = value; }
    }
}
