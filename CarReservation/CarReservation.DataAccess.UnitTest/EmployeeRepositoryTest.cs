using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarReservation.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarReservation.DataAccess.UnitTest
{
    [TestClass]
    public class EmployeeRepositoryTest : Repository
    {
        [TestMethod]
        public void GetAllEmployees_WhenCalled_ReturnsAlistOfEmployee()
        {
            //Arrange
            int actualResult;
            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Employee> employees = employeeRepository.GetAllEmployees();

            //Act
            string sqlTestQuery = "SELECT COUNT (*) FROM Employees";
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarReservationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            using(SqlCommand cmd = new SqlCommand(sqlTestQuery, sqlConnection))
            {
                cmd.Connection.Open();
                actualResult = (int)cmd.ExecuteScalar();
                cmd.Connection.Close();
            }         
            //Assert
            Assert.AreEqual(actualResult, employees.Count);
        }
    }
}
