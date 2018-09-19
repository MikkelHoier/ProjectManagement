using RygOgRejs.DataAccess;
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

namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RepositoryJourney repositoryJourney = new RepositoryJourney();
        public MainWindow()
        {
            InitializeComponent();
            UpdataDataGrid();
            
        }

        private void CheckBoxIsFirstClass_CheckedEvent(object sender, RoutedEventArgs e)
        {

        }

        private void UpdataDataGrid()
        {
            DataGrid_sqlData.ItemsSource = repositoryJourney.GetAll();
        }
    }
}
