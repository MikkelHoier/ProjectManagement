using CarReservation.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.DataAccess
{
    /// <summary>
    /// Class designed to work sql data from CarReservation DB related to cars. Inheritance from Repository.
    /// </summary>
    public class CarRepository : Repository
    {
        /// <summary>
        /// Returns a list of all cars and their properties from the Cars table in CarReservationDB
        /// </summary>
        /// <returns></returns>
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>(0);
            string query = "SELECT * FROM Cars";
            DataSet dataSet = Execute(query);
            DataTable dataTable = dataSet.Tables[0];
            foreach(DataRow row in dataTable.Rows)
            {
                Car car = new Car(
                    (int)row["CarId"],
                    (bool)row["IsAvailable"],
                    (string)row["LicensePlate"],
                    (string)row["Make"],
                    (string)row["Model"],
                    (int)row["ProductionYear"]);
                cars.Add(car);
            }
            return cars;
        }

        /// <summary>
        /// Adds a new car to the Cars table in CarReservationDB
        /// </summary>
        /// <param name="car"></param>
        public void SaveCar(Car car)
        {
            string query = $"INSERT INTO Cars (LicensePlate, ProductionYear, Make, Model, IsAvailable) " +
                $"VALUES ('{car.LicensePlate}', {car.ProductionYear}, '{car.Make}', '{car.Model}', 1)";
            ExecuteNonQuery(query);
        }

        public void BookCar(Car car, Employee employee)
        {
            string query = $"UPDATE Cars " +
                $"SET IsAvailable = 0 " +
                $"WHERE CarId = {car.Id}";
            ExecuteNonQuery(query);

            query = $"INSERT INTO Bookings (CarsId, EmployeesId) " +
                $"VALUES ({car.Id}, {employee.Id})";
            ExecuteNonQuery(query);            
        }

        public void RemoveBookingFrom(Car c)
        {
            string query = $"UPDATE Cars " +
                $"SET IsAvailable = 1 " +
                $"WHERE CarId={c.Id}";
            ExecuteNonQuery(query);
            
            query = $"DELETE FROM Bookings " +
                $"WHERE CarsId={c.Id}";
            ExecuteNonQuery(query);
        }

        public List<Car> GetCarsBookedTo(Employee employee)
        {
            List<Car> cars = new List<Car>(0);
            string query = $"SELECT * " +
                $"FROM Bookings " +
                $"INNER JOIN Cars ON Bookings.CarsId=Cars.CarId " +
                $"WHERE EmployeesId={employee.Id}";
            DataSet dataSet = Execute(query);
            DataTable dataTable = dataSet.Tables[0];
            foreach(DataRow row in dataTable.Rows)
            {
                Car car = new Car(
                   (int)row["CarId"],
                   (bool)row["IsAvailable"],
                   (string)row["LicensePlate"],
                   (string)row["Make"],
                   (string)row["Model"],
                   (int)row["ProductionYear"]);
                cars.Add(car);
            }
            return cars;
        }

        public List<Car> GetAvailableCars()
        {
            List<Car> cars = new List<Car>(0);
            string query = "SELECT * FROM Cars " +
                "WHERE IsAvailable=1";
            DataSet dataSet = Execute(query);
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                Car car = new Car(
                    (int)row["CarId"],
                    (bool)row["IsAvailable"],
                    (string)row["LicensePlate"],
                    (string)row["Make"],
                    (string)row["Model"],
                    (int)row["ProductionYear"]);
                cars.Add(car);
            }
            return cars;
        }
    }    
}
