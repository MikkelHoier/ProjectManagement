using MikkelHoierJensen.DataApp.DataAccess;
using MikkelHøjerJensen.DataApp.Entities;
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

namespace MikkelHøjerjesen.DataApp.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContactInfomationRepository contactInfomationRepository = new ContactInfomationRepository();
        PersonRepository personRepository = new PersonRepository();
        public MainWindow()
        {            
            InitializeComponent();            
            UpdateDatagrid();
        }

        private void Button_save_ClickEvent(object sender, RoutedEventArgs e)
        {
            ContactInfomation contactInfomation = new ContactInfomation(TextBox_Mail.Text,TextBox_PhoneNumber.Text,TextBox_HomePage.Text);
            contactInfomationRepository.AllNewContactInformation(contactInfomation);
            UpdateDatagrid();
        }

        private void UpdateDatagrid()
        {
            DataGrid_ContactInfomationData.ItemsSource = contactInfomationRepository.GetAllContactInfomations();
        }

        private void Datatgrid_SQLData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContactInfomation contactInfomation = (ContactInfomation)DataGrid_ContactInfomationData.SelectedItem;
            if (contactInfomation != null)
            {
                TextBox_Mail.Text = contactInfomation.Mail;
                TextBox_HomePage.Text = contactInfomation.HomePage;
                TextBox_PhoneNumber.Text = contactInfomation.PhoneNumber;
            }            
        }

        private void ButtonUpdate_ClickEvent(object sender, RoutedEventArgs e)
        {
            ContactInfomation contactInfomation = (ContactInfomation)DataGrid_ContactInfomationData.SelectedItem;
            contactInfomation.Mail = TextBox_Mail.Text;
            contactInfomation.PhoneNumber = TextBox_PhoneNumber.Text;
            contactInfomation.HomePage = TextBox_HomePage.Text;
            contactInfomationRepository.UpDateContactInfomation(contactInfomation);
            UpdateDatagrid();
        }
    }
}
