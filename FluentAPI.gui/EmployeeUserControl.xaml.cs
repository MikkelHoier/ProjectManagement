using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FluentAPI.EF;
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
    /// Interaction logic for EmployeeUserControl.xaml
    /// </summary>
    public partial class EmployeeUserControl : UserControl
    {
        #region Fields
        protected Model model;
        protected Employee selectedEmployee;
        #endregion

        #region Constructor
        public EmployeeUserControl()
        {
            InitializeComponent();
            model = new Model();
            buttonUpdate.IsEnabled = false;
            buttonDelete.IsEnabled = false;
            FillEmployeeDataGrid();
        }
        #endregion        
        
        
        /// <summary>
        /// Fills the dataGridEmployee with Employees from the EF model.
        /// </summary>
        public void FillEmployeeDataGrid()
        {
            try
            {
                dataGridEmployee.ItemsSource = model.Employees.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der skete en unvented fejl: {ex.ToString()}","Fejl",MessageBoxButton.OK);
                throw;
            }          
        }      

        protected virtual void EmptyTextBoxes()
        {
            textBoxEmployeeFirstName.Text = string.Empty;
            textBoxEmployeeLastName.Text = string.Empty;
            datePickerBirthDate.SelectedDate = null;
            datePickerStartDate.SelectedDate = null;
            textBoxEmail.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
            textBoxSalary.Text = string.Empty;
            textBoxSocialSecurityNumber.Text = string.Empty;
        }        

        private void ButtonUpdate_ClickEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AllEmployeeInputToolsAreValid())
                {
                    AssignValuesTo(selectedEmployee);
                    model.SaveChanges();
                    FillEmployeeDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der skete en uvented fejl: {ex.ToString()}", "Fejl", MessageBoxButton.OK);                
            }
        }

        public void AssignValuesTo(Employee employee)
        {
            employee.FirstName = textBoxEmployeeFirstName.Text;
            employee.LastName = textBoxEmployeeLastName.Text;
            employee.BirthDate = datePickerBirthDate.SelectedDate;
            employee.SocialSecurityNumber = textBoxSocialSecurityNumber.Text;
            employee.StartDate = datePickerStartDate.SelectedDate;
            employee.Salary = Convert.ToDecimal(textBoxSalary.Text);

            if(TextBoxEmailIsValid() || TextBoxPhoneIsValid())
            {
                employee.ContactInfo = new ContactInfo();
            }
                              
        }

        #region Event Handlers
        private void DataGrid_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedEmployee = dataGridEmployee.SelectedItem as Employee;

                if (selectedEmployee != null)
                {
                    textBoxEmployeeFirstName.Text = selectedEmployee.FirstName;
                    textBoxEmployeeLastName.Text = selectedEmployee.LastName;
                    datePickerBirthDate.SelectedDate = selectedEmployee.BirthDate;
                    datePickerStartDate.SelectedDate = selectedEmployee.StartDate;
                    textBoxSocialSecurityNumber.Text = selectedEmployee.SocialSecurityNumber;
                    textBoxSalary.Text = Convert.ToString(selectedEmployee.Salary);
                }
                else
                {
                    return;
                }

                if (selectedEmployee.ContactInfo != null)
                {
                    textBoxEmail.Text = selectedEmployee.ContactInfo.Email;
                    textBoxPhone.Text = selectedEmployee.ContactInfo.Phone;
                }
                else
                {
                    textBoxEmail.Text = string.Empty;
                    textBoxPhone.Text = string.Empty;
                }

                buttonSave.IsEnabled = false;
                buttonUpdate.IsEnabled = true;
                buttonDelete.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der skete en uvented fejl: {ex.ToString()}", "Fejl", MessageBoxButton.OK);
            }
            
        }

        private void ButtonSave_ClickEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee;
                if (AllEmployeeInputToolsAreValid())
                {
                    employee = new Employee(textBoxEmployeeFirstName.Text, textBoxEmployeeLastName.Text, textBoxSocialSecurityNumber.Text, Convert.ToDecimal(textBoxSalary.Text), datePickerBirthDate.SelectedDate.Value, datePickerStartDate.SelectedDate.Value, null);
                    model.Employees.Add(employee);
                    if (TextBoxEmailIsValid() && TextBoxPhoneIsValid())
                    {
                        employee = new Employee(textBoxEmployeeFirstName.Text, textBoxEmployeeLastName.Text, textBoxSocialSecurityNumber.Text, Convert.ToDecimal(textBoxSalary.Text), datePickerBirthDate.SelectedDate.Value, datePickerStartDate.SelectedDate.Value, new ContactInfo(textBoxEmail.Text, textBoxPhone.Text));
                        model.Employees.Add(employee);
                    }
                    model.SaveChanges();
                    FillEmployeeDataGrid();
                }                
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Der skete en uventet fejl:{ex.ToString()}","Fejl",MessageBoxButton.OK);
            }
        }

        private void ButtonDelete_ClickEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = dataGridEmployee.SelectedItem as Employee;
                model.Employees.Remove(employee);
                model.SaveChanges();
                FillEmployeeDataGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Der skete uvented fejl: {ex.ToString()}", "Fejl", MessageBoxButton.OK);
            }
        }

        private void DataGridEmployees_KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dataGridEmployee.SelectedItem = selectedEmployee = null;
                buttonSave.IsEnabled = true;
                buttonUpdate.IsEnabled = false;
                buttonDelete.IsEnabled = false;
                EmptyTextBoxes();
            }
        }        
        #endregion


        #region Input Validation Methods
        private bool TextBoxSalaryIsValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxSalary.Text))
            {
                MessageBox.Show("Løn skal udfyldes", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else
            {
                foreach (char c in textBoxSalary.Text)
                {
                    if (char.IsLetter(c))
                    {
                        MessageBox.Show("Løn må kun indholde tal", "Fejl", MessageBoxButton.OK);
                        return false;
                    }
                }
                return true;
            }
        }

        private bool TextBoxPhoneIsValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                return false;
            }
            else if (textBoxEmail.Text == string.Empty)
            {
                MessageBox.Show("Hvis Telefon Nummer skal udfyldes skal Email også udfyldes.", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else
            {
                foreach (char c in textBoxPhone.Text)
                {
                    if (char.IsLetter(c))
                    {
                        MessageBox.Show("Telefon Nummer må ikke indholde bogstaver.", "Fejl", MessageBoxButton.OK);
                        return false;
                    }
                }
                return true;
            }
        } 

        private bool TextBoxEmployeeFirstNameIsValid()
        {
            if(Validator.NameIsValid(textBoxEmployeeFirstName.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Fornavn skal udfyldes, må ikke inholde numre, og må ikke være længer en 100 karakter.", "Fejl", MessageBoxButton.OK);
                return false;
            }
        }

        private bool TextBoxEmailIsValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                return false;
            }
            else if (!textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email skal inholde @.", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else if(textBoxPhone.Text == string.Empty)
            {
                MessageBox.Show("Hvis Email feltet skal udfyldes skal Telefon nummer også udfyldes.", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates textBoxSocialSecurityNumber. If textBoxSocialSecurityNumber content is null or empty, or contain a letter, returns false with appropiate message box.
        /// </summary>
        /// <returns></returns>
        private bool TextBoxSocialSecurityNumberIsValid()
        {
            if(string.IsNullOrWhiteSpace(textBoxSocialSecurityNumber.Text))
            {
                MessageBox.Show("CPR nummer skal udfyldes");
                return false;
            }            
            else
            {
                foreach(char c in textBoxSocialSecurityNumber.Text)
                {
                    if (char.IsLetter(c))
                    {
                        MessageBox.Show("CPR nummer må ikke inholder bogstaver", "Fejl", MessageBoxButton.OK);
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Validates datePickerBirthDate. Return false if datePickerStartDate is null or higher then DateTime.now with a MessageBox containing an error message. 
        /// </summary>
        /// <returns></returns>
        private bool DatePickerBirthDateIsValid()
        {
            if (datePickerBirthDate.SelectedDate == null)
            {
                MessageBox.Show("Ingen Fødselsdato valgt.","Fejl",MessageBoxButton.OK);
                return false;
            }
            else if (datePickerBirthDate.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Fødseldato skal være før i morgen.", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else if (datePickerBirthDate.SelectedDate > datePickerStartDate.SelectedDate)
            {
                MessageBox.Show("Fødseldato kan skal være før Start dato","fejl",MessageBoxButton.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates datePickerStartDate. Return false if datePickerStartDate is null or higher then DateTime.now with a MessageBox containing an error message. 
        /// </summary>
        /// <returns></returns>
        private bool DatePickerStartDateIsValid()
        {
            if(datePickerStartDate.SelectedDate == null)
            {
                MessageBox.Show("Ingen Starts Dato valgt", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else if(datePickerStartDate.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Starts Dato skal være før i morgen","Fejl",MessageBoxButton.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool TextBoxEmployeeLastNameIsValid()
        {
            if (Validator.NameIsValid(textBoxEmployeeLastName.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Efternavn skal udfyldes, må ikke inholde numre, og må ikke være længer en 100 karakter.", "Fejl", MessageBoxButton.OK);
                return false;
            }
        }

        /// <summary>
        /// Returns true if tools that can take input from the user in the Employee tab has a value in them. Note it dosen't validate data needed for ContactInfomation.
        /// </summary>
        /// <returns></returns>
        private bool AllEmployeeInputToolsAreValid()
        {
            if(TextBoxEmployeeFirstNameIsValid() && TextBoxSalaryIsValid() && TextBoxEmployeeLastNameIsValid() && TextBoxSocialSecurityNumberIsValid() && DatePickerBirthDateIsValid() && DatePickerStartDateIsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion
    }    
}
