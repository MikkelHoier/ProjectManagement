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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarReservation.Gui
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public CarRepository carRepository = new CarRepository();
        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_AddCar0_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = new Car(TextBox_NumberPlate.Text, TextBox_Make.Text, TextBox_Model.Text, Convert.ToInt32(TextBox_YearOfProduction.Text));
                carRepository.SaveCar(car);
                Close();
            }
            catch(FormatException)
            {
                MessageBox.Show("Har du husket at fylde alle felter?","FEJL!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FEJL!");
            }
        }
    }
}
