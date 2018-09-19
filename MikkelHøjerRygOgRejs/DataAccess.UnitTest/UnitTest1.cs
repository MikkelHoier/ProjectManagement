using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RygOgRejs.DataAccess;

namespace DataAccess.UnitTest
{
    [TestClass]
    public class RepositoryJourneyTests : Repository
    {
        [TestMethod]
        public void GetAllJourney_WhenCalled_ReturnsAListOfJourney()
        {
            //Arrange
            int expectedResult;
            RepositoryJourney repositoryJourney = new RepositoryJourney();
            string sqlTestQuery = "SELECT COUNT (*) FROM Journeys";
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RygOgRejsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
            using (SqlCommand cmd = new SqlCommand(sqlTestQuery, sqlConnection))
            {
                cmd.Connection.Open();
                expectedResult = (int)cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            List<Journey> journeys = repositoryJourney.GetAll();
            int actualResult = journeys.Count;
            //Act            


            //Assert
            
        }
    }
}
