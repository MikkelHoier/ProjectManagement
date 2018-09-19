using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlAssignment
{
    public class PersonRepository
    {
        public List<Person> GetAllPersons()
        {
            Person person1 = new Person("John", "Johnson");
            Person person2 = new Person("Kevin", "Kvinson");
            Person person3 = new Person("Judy", "Judyson");

            List<Person> people = new List<Person>{person1, person2 , person3};
            return people;
        }
    }
}
