using MikkelHøjerJensen.DataApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikkelHoierJensen.DataApp.DataAccess
{
    //Class designed to access data in the person table from the GenericDB database
    public class PersonRepository : Repository
    {        
        public List<Person> GetAllPersons()
        {
            List<Person> people = new List<Person>();
            string getAllQuery = "SELECT * FROM ContactInfomations INNER JOIN Persons ON ContactInfomations.PersonsId=Persons.PersonId";
                        
            DataSet resultSet = Execute(getAllQuery);

            DataTable peopleTable = resultSet.Tables[0];

            foreach(DataRow row in peopleTable.Rows)
            {
                ContactInfomation contactInfomation = new ContactInfomation(
                    (int)row["ContactInfomationId"],
                    (string)row["Mail"],
                    (string)row["PhoneNumber"],
                    (string)row["HomePage"]);
                Person person = new Person(
                    (int)row["PersonId"],
                    contactInfomation,
                    (string)row["FirstName"],
                    (string)row["LastName"],
                    (string)row["SocialSecurityNumber"]);
                people.Add(person);
            }
            return people;
        }
    }
}
