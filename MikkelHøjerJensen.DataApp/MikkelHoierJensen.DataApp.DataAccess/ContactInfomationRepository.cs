using MikkelHøjerJensen.DataApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikkelHoierJensen.DataApp.DataAccess
{
    // designed to access data from the ContactInfomations table from the GenericDB database
    public class ContactInfomationRepository : Repository
    {
        #region Methods
        public List<ContactInfomation> GetAllContactInfomations()
        {
            List<ContactInfomation> contactInfomations = new List<ContactInfomation>(0);
            string getAllQuery = "SELECT * FROM ContactInfomations";

            DataSet resultSet = Execute(getAllQuery);

            DataTable ContactInfomationsTable = resultSet.Tables[0];

            foreach (DataRow row in ContactInfomationsTable.Rows)
            {
                ContactInfomation contactInformation = new ContactInfomation(
                    (int)row["ContactInfomationId"],
                    (string)row["Mail"],
                    (string)row["PhoneNumber"],
                    (string)row["HomePage"]);
                contactInfomations.Add(contactInformation);
            }
            return contactInfomations;
        }

        public ContactInfomation GetContactInfomationByMail(string mail)
        {
            ContactInfomation contactInfomation = null;
            string getContactinfomationByMailQuery = $"SELECT * FROM ContactInfomations WHERE Mail LIKE '{mail}'";

            DataSet resultSet = Execute(getContactinfomationByMailQuery);

            DataTable contactInfomationTable = resultSet.Tables[0];

            foreach (DataRow contactInformationRow in contactInfomationTable.Rows)
            {
                contactInfomation = new ContactInfomation(
                    (int)contactInformationRow["ContactInfomationId"],
                    (string)contactInformationRow["Mail"],
                    (string)contactInformationRow["PhoneNumber"],
                    (string)contactInformationRow["HomePage"]);
            }
            return contactInfomation;
        }

        public void AllNewContactInformation(ContactInfomation contactInfomation)
        {
            string AllNewContactInformationQuery = $"INSERT INTO ContactInfomations (Mail, PhoneNumber, HomePage)" +
                $"VALUES('{contactInfomation.Mail}', '{contactInfomation.PhoneNumber}', '{contactInfomation.HomePage}')";
            Execute(AllNewContactInformationQuery);
        }

        public void UpDateContactInfomation(ContactInfomation contactInfomation)
        {
            string UpDataContactInformationQuery = $"UPDATE ContactInfomations " +
                $"SET Mail = '{contactInfomation.Mail}', PhoneNumber = '{contactInfomation.PhoneNumber}', HomePage = '{contactInfomation.HomePage}' " +
                $"WHERE ContactInfomationId = {contactInfomation.Id}";

            Execute(UpDataContactInformationQuery);
        } 
        #endregion
    }
}
