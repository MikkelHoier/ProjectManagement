using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.DataAccess
{
    public class RepositoryJourney : Repository
    {
        public List<Journey> GetAll()
        {
            List<Journey> journeys = new List<Journey>(0);
            string sqlQuery = "SELECT * FROM Journeys";
            DataSet resultSet = Execute(sqlQuery);

            DataTable JourneyTables = resultSet.Tables[0];

            foreach(DataRow row in JourneyTables.Rows)
            {                
                Journey journey = new Journey(
                    (int)row["Adults"],
                    (int)row["Children"],
                    (DateTime)row["DepatureTime"],
                    (Destination)Enum.Parse(typeof(Destination), row["Destination"].ToString(), true),
                    (bool)row["IsFirstClass"],
                    (decimal)row["LuggageAmount"]);
                journeys.Add(journey);
            }
            return journeys;
        }

        public Journey GetJourneyBy(string fullName)
        {
            Journey finalJourney = null;
            string sqlQuery = $"SELECT FirstName, LastName, JourneyId FROM Payers " +
                $"INNER JOIN Journeys ON Payers.JourneysId=Journeys.JourneyId WHERE FirstName LIKE '%{fullName}%' OR LastName LIKE '%{fullName}%'";
            DataSet resultset = Execute(sqlQuery);
            DataTable journeyTable = resultset.Tables[0];

            foreach (DataRow row in journeyTable.Rows)
            {                
                Journey journey = new Journey(
                    (int)row["Adult"],
                    (int)row["Children"],
                    (DateTime)row["DepartureTime"],
                    (Destination)Enum.Parse(typeof(Destination), (string)row["Destination"]),
                    (bool)row["IsFirstClass"],
                    (decimal)row["LuggageAmount"]);
                finalJourney = journey;
            }
            return finalJourney;
        }
    }
}
