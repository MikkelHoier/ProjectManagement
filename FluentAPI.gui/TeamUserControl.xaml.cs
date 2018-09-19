using FluentAPI.EF;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FluentAPI.gui
{
    /// <summary>
    /// Interaction logic for TeamUserControl.xaml
    /// </summary>
    public partial class TeamUserControl : UserControl
    {
        protected Model model;
        protected Team selectedTeam;
        protected List<Employee> availableEmployees;        

        public TeamUserControl()
        {
            InitializeComponent();
            model = new Model();
            FillTeamDataGrid();            
            buttonDeleteEmployee.IsEnabled = false;
            buttonAddEmployee.IsEnabled = false;
            buttonDeleteTeam.IsEnabled = false;
            comboBoxEmployees.IsEnabled = false;
            buttonUpdateTeam.IsEnabled = false;
        }

        private void ButtonSaveTeam_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (TeamToolsIsValid())
                {
                Team team = new Team(textBoxTeamName.Text, datePickerStartDate.SelectedDate.Value, datePickerEndDate.SelectedDate.Value);
                if (TextBoxTeamDescriptionIsValid())
                {
                    team.Description = textBoxTeamDescription.Text;
                }
                model.Teams.Add(team);
                model.SaveChanges();
                FillTeamDataGrid();
            }
        }

        private void FillTeamDataGrid()
        {
            try
            {
                dataGridTeams.ItemsSource = model.Teams.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Der skete en uvented fejl: {ex.ToString()}", "Fejl", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Fill dataGridEmployee from the current team selected by the user in dataGridTeam.
        /// </summary>
        private void FillEmployeeDataGrid()
        {
            dataGridEmployees.ItemsSource = selectedTeam.Employees.ToList();
        }
        
        /// <summary>
        /// Fill comboBoxEmployee with employee who isn't already in the team selected by the user.
        /// </summary>
        private void FillEmployeeComboBox()
        {
            List<Employee> employees = model.Employees.ToList();
            if (selectedTeam.Employees != null)
            {
                availableEmployees = employees.Except(selectedTeam.Employees).ToList();
                comboBoxEmployees.ItemsSource = availableEmployees;
                comboBoxEmployees.DisplayMemberPath = "FullName";
            }
        }
        
        private void DataGridTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeam = dataGridTeams.SelectedItem as Team;

            if (selectedTeam == null)
            {
                return;
            }
            else
            {
                textBoxTeamName.Text = selectedTeam.Name;
                textBoxTeamDescription.Text = selectedTeam.Description;
                datePickerStartDate.SelectedDate = selectedTeam.StartDate;
                datePickerEndDate.SelectedDate = selectedTeam.EndDate;

            }

            if(selectedTeam.Employees != null)
            {
                FillEmployeeDataGrid();
            }

            FillEmployeeComboBox();

            buttonAddEmployee.IsEnabled = true;
            buttonSaveTeam.IsEnabled = false;
            buttonDeleteTeam.IsEnabled = true;
            comboBoxEmployees.IsEnabled = true;
            buttonUpdateTeam.IsEnabled = true;
        }

        private bool TeamToolsIsValid()
        {
            if(TextBoxTeamNameIsValid() && DatePickerStartDateIsValid() && DatePickerEndDateIsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool TextBoxTeamNameIsValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxTeamName.Text))
            {
                MessageBox.Show("Hold Navn skal udfyldes", "Fejl", MessageBoxButton.OK);
                return false;                
            }           
            else
            {
                return true;
            }
        }

        private bool TextBoxTeamDescriptionIsValid()
        {
            if(textBoxTeamDescription.Text == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool DatePickerStartDateIsValid()
        {
            if (datePickerStartDate.SelectedDate.Value == null)
            {
                MessageBox.Show("Ingen Starts Dato valgt", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else if (datePickerStartDate.SelectedDate > datePickerEndDate.SelectedDate)
            {
                MessageBox.Show("Starts Dato skal være før Sluts Dato", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool DatePickerEndDateIsValid()
        {
            if (datePickerEndDate.SelectedDate.Value == null)
            {
                MessageBox.Show("Ingen Slut Dato valgt.", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else if(datePickerEndDate.SelectedDate < datePickerStartDate.SelectedDate)
            {
                MessageBox.Show("Sluts Dato kan ikke være før Starts Dato.", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void EmptyTeamTools()
        {
            textBoxTeamName.Text = string.Empty;
            textBoxTeamDescription.Text = string.Empty;
            datePickerStartDate.SelectedDate = null;
            datePickerEndDate.SelectedDate = null;
            comboBoxEmployees.IsEnabled = false;
            buttonAddEmployee.IsEnabled = false;
            buttonDeleteEmployee.IsEnabled = false;
        }

        /// <summary>
        /// Deselects everything when escape is pressed while dataGridTeam has focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridTeam_KeyDownEvent(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                dataGridTeams.SelectedItem = selectedTeam = null;
                buttonDeleteTeam.IsEnabled = false;
                buttonSaveTeam.IsEnabled = true;
                dataGridEmployees.ItemsSource = null;
                buttonUpdateTeam.IsEnabled = false;
                comboBoxEmployees.IsEnabled = false;
                buttonAddEmployee.IsEnabled = false;
                buttonDeleteEmployee.IsEnabled = false;
                EmptyTeamTools();
            }
        }

        private void ButtonDeleteTeam_ClickEvent(object sender, RoutedEventArgs e)
        {
            Team team = dataGridTeams.SelectedItem as Team;
            model.Teams.Remove(team);
            model.SaveChanges();
            FillTeamDataGrid();
        }
                        
        private void ButtonDeleteEmployee_ClickEvent(object sender, RoutedEventArgs e)
        {
            selectedTeam.Employees.Remove(dataGridEmployees.SelectedItem as Employee);
            model.SaveChanges();
            FillTeamDataGrid();
            FillEmployeeDataGrid();
            FillEmployeeComboBox();
        }

        private void ButtonAddEmployee_ClickEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboBoxEmployees.SelectedItem != null)
                {
                    selectedTeam.Employees.Add(comboBoxEmployees.SelectedItem as Employee);
                    model.SaveChanges();                           
                    comboBoxEmployees.SelectedItem = null;
                    FillTeamDataGrid();
                    FillEmployeeComboBox(); 
                }
                else
                {
                    MessageBox.Show("Der var ikke valgt nogen medarbejder til at tilføje", "Fejl", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Der skete en uvented fejl: {ex.ToString()}", "Fejl", MessageBoxButton.OK);
            }
        }

        private void DataGridEmployees_SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            buttonDeleteEmployee.IsEnabled = true;
        }

        private void ButtonUpdateTeam_ClickEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TeamToolsIsValid())
                {
                    selectedTeam.Name = textBoxTeamName.Text;
                    selectedTeam.Description = textBoxTeamDescription.Text;
                    selectedTeam.StartDate = datePickerStartDate.SelectedDate.Value;
                    selectedTeam.EndDate = datePickerEndDate.SelectedDate.Value;
                    model.SaveChanges();
                    FillTeamDataGrid(); 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Der skete en uvented fejl: {ex.ToString()}", "Fejl", MessageBoxButton.OK);
            }
        }
    }
}
