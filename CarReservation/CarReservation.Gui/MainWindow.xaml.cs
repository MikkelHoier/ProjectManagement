using CarReservation.DataAccess;
using CarReservation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarReservation.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CarRepository carRepository = new CarRepository();
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        public MainWindow()
        {
            InitializeComponent();
            FillEmployeeComboBox();
            FillCarDatagrid();
        }

        private void Button_ReserveCar_Click(object sender, RoutedEventArgs e)
        {
            Car car = (Car)DataGrid_Cars.SelectedItem;
            Employee employee = (Employee)ComboBox_Employees.SelectedItem;
            carRepository.BookCar(car, employee);
            FillCarDatagrid();
        }

        private void FillCarDatagrid()
        {
            DataGrid_Cars.ItemsSource = carRepository.GetAllCars();
        }

        private void FillEmployeeComboBox()
        {
            try
            {
                List<Employee> employees = employeeRepository.GetAllEmployees();
                ComboBox_Employees.ItemsSource = employees;                
            }
            catch
            {
                
            }
        }

        private void Button_AddCar_Click(object sender, RoutedEventArgs e)
        {            
        
            AddCarWindow addCarWindow = new AddCarWindow();
            addCarWindow.Show();
        
            
        }

        private void ComboBox_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employee = (Employee)ComboBox_Employees.SelectedItem;
            label_Name.Content = ComboBox_Employees.SelectedItem;
            Label_Email.Content = $"{employee.Initials}{employee.EmailDomain}";
            Label_TelephoneNumber.Content = employee.PhoneNumber;
        }

        private void Button_ShowAllCars_Click(object sender, RoutedEventArgs e)
        {
            FillCarDatagrid();
        }

        private void Button_RemoveCarFromEmployee_Click(object sender, RoutedEventArgs e)
        {
            Car car = (Car)DataGrid_Cars.SelectedItem;
            carRepository.RemoveBookingFrom(car);
            FillCarDatagrid();
        }

        private void Button_ShowReservedCars_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee)ComboBox_Employees.SelectedItem;
            List<Car> cars = carRepository.GetCarsBookedTo(employee);
            DataGrid_Cars.ItemsSource = cars;
        }

        private void Button_ShowCars_Click(object sender, RoutedEventArgs e)
        {
            List<Car> cars = carRepository.GetAvailableCars();
            DataGrid_Cars.ItemsSource = cars;
        }
    }
}
