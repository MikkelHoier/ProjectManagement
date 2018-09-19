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
    /// Interaction logic for ProjectUserControl.xaml
    /// </summary>
    public partial class ProjectUserControl : UserControl
    {
        protected Model model;
        protected Project selectedProject;
        protected List<Team> availableTeams;        

        public ProjectUserControl()
        {
            InitializeComponent();
            model = new Model();
            buttonDeleteProject.IsEnabled = false;
            buttonAddTeam.IsEnabled = false;
            buttonDeleteTeam.IsEnabled = false;
            comboBoxTeams.IsEnabled = false;
            buttonUpdateProject.IsEnabled = false;
            FillProjectDataGrid();
        }

        private void FillProjectDataGrid()
        {
            dataGridProjects.ItemsSource = model.Projects.ToList();
        }

        protected void FillTeamDataGrid()
        {
            dataGridTeams.ItemsSource = selectedProject.Teams.ToList();
        }

        protected void FillTeamComboBox()
        {
            List<Team> teams = model.Teams.ToList();
            if (selectedProject.Teams != null)
            {
                availableTeams = teams.Except(selectedProject.Teams).ToList();
                comboBoxTeams.ItemsSource = availableTeams;
                comboBoxTeams.DisplayMemberPath = "Name";
            }
        }

        protected void EmptyTools()
        {
            textBoxProjectName.Text = string.Empty;
            textBoxProjectDescription.Text = string.Empty;
            textBoxBudget.Text = string.Empty;
            datePickerProjectStartDate.SelectedDate = null;
            datePickerProjectEndDate.SelectedDate = null;
        }

        #region Validation Methods
        protected bool ProjectToolsIsValid()
        {
            if (TextBoxProjectNameIsValid() && DatePickerProjectStartDateIsValid() && DatePickerProjectEndDateIsValid() && TextBoxBudgetIsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool TextBoxProjectNameIsValid()
        {
            if (textBoxProjectName.Text == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool TextBoxBudgetIsValid()
        {
            if (string.IsNullOrEmpty(textBoxBudget.Text))
            {
                MessageBox.Show("Budget ikke udfyldt", "Fejl", MessageBoxButton.OK);
                return false;
            }
            else
            {
                foreach (char c in textBoxBudget.Text)
                {
                    if (char.IsLetter(c))
                    {
                        MessageBox.Show("Budget må ikke inholde bogstaver", "Fejl", MessageBoxButton.OK);
                        return false;
                    }
                }
                return true;
            }
        }

        protected bool TextBoxProjectDescriptionIsValid()
        {
            if (textBoxProjectDescription.Text == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool DatePickerProjectStartDateIsValid()
        {
            if (datePickerProjectStartDate.SelectedDate.Value == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool DatePickerProjectEndDateIsValid()
        {
            if (datePickerProjectEndDate.SelectedDate.Value == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
        #endregion

        #region Event Handlers
        private void ButtonSaveProject_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (ProjectToolsIsValid())
            {
                Project project = new Project(textBoxProjectName.Text, Convert.ToDecimal(textBoxBudget.Text), datePickerProjectStartDate.SelectedDate.Value, datePickerProjectEndDate.SelectedDate.Value);
                if (TextBoxProjectDescriptionIsValid())
                {
                    project.Description = textBoxProjectDescription.Text;
                }
                model.Projects.Add(project);
                model.SaveChanges();
                FillProjectDataGrid();
            }
        }

        private void DataGridProjects_SelectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            selectedProject = dataGridProjects.SelectedItem as Project;

            if (selectedProject == null)
            {
                return;
            }
            else
            {
                textBoxProjectName.Text = selectedProject.Name;
                textBoxProjectDescription.Text = selectedProject.Description;
                textBoxBudget.Text = Convert.ToString(selectedProject.Budget);
                datePickerProjectStartDate.SelectedDate = selectedProject.StartDate;
                datePickerProjectEndDate.SelectedDate = selectedProject.EndDate;
            }

            if (selectedProject.Teams != null)
            {
                FillTeamDataGrid();
            }

            FillTeamComboBox();

            buttonUpdateProject.IsEnabled = true;
            buttonSaveProject.IsEnabled = false;
            buttonAddTeam.IsEnabled = true;
            buttonDeleteTeam.IsEnabled = true;
            comboBoxTeams.IsEnabled = true;
            buttonDeleteProject.IsEnabled = true;
        }

        private void ButtonAddTeam_ClickEvent(object sender, RoutedEventArgs e)
        {
            selectedProject.Teams.Add(comboBoxTeams.SelectedItem as Team);
            model.SaveChanges();
            FillProjectDataGrid();
            FillTeamDataGrid();
            comboBoxTeams.SelectedItem = null;
            FillTeamComboBox();
        }

        private void ButtonDeleteTeam_CLickEvent(object sender, RoutedEventArgs e)
        {
            selectedProject.Teams.Remove(dataGridTeams.SelectedItem as Team);
            model.SaveChanges();
            FillProjectDataGrid();
            FillTeamDataGrid();
            FillTeamComboBox();
        }

        private void dataGridProjects_KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dataGridProjects.SelectedItem = selectedProject = null;
                buttonDeleteProject.IsEnabled = false;
                buttonAddTeam.IsEnabled = false;
                buttonDeleteTeam.IsEnabled = false;
                comboBoxTeams.IsEnabled = false;
                buttonSaveProject.IsEnabled = true;
                buttonDeleteProject.IsEnabled = false;
                buttonUpdateProject.IsEnabled = false;
                dataGridTeams.ItemsSource = null;
                EmptyTools();
            }
        }

        private void ButtonUpdateProject_ClickEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProjectToolsIsValid())
                {
                    selectedProject.Name = textBoxProjectName.Text;
                    selectedProject.Description = textBoxProjectDescription.Text;
                    selectedProject.Budget = Convert.ToDecimal(textBoxBudget.Text);
                    selectedProject.StartDate = datePickerProjectStartDate.SelectedDate.Value;
                    selectedProject.EndDate = datePickerProjectEndDate.SelectedDate.Value;
                    model.SaveChanges();
                    FillProjectDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der skete en uvented fejl: {ex.ToString()}", "Fejl", MessageBoxButton.OK);
            }
        }
        #endregion        
    }
}
