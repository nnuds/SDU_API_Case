using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

using SDU_API_Models_CustomerOrder;

namespace SDU_API_AFnc.DAL
{
    public static class CustomerRepository
    {
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SDU_db1;Integrated Security=True;";

        public static List<SDU_API_Models_CustomerOrder.Kunde> GetCustomers(string customerID)
        {
            List<SDU_API_Models_CustomerOrder.Kunde> customers = new List<SDU_API_Models_CustomerOrder.Kunde>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [Id], [Firma], [Efternavn], [Fornavn], [E-mail-adresse], [Stilling], " +
                                   "[Telefon (arbejde)], [Telefon (privat)], [Mobiltelefon], [Faxnummer], " +
                                   "[Adresse], [By], [Stat/provins], [Postnummer], [Land/område], " +
                                   "[Webside], [Noter], [Vedhæftede filer] " +
                                   "FROM [dbo].[Kunder] ";

                if (string.IsNullOrWhiteSpace(customerID) == false)
                {
                    query += "WHERE [Id]=@CustomerID ";    
                }
                                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SDU_API_Models_CustomerOrder.Kunde customer = new SDU_API_Models_CustomerOrder.Kunde
                    {
                        Id = Helper.ConvertDataFromDb.ToInt(reader["Id"]),
                        Firma = Helper.ConvertDataFromDb.ToString(reader["Firma"]),
                        Efternavn = Helper.ConvertDataFromDb.ToString(reader["Efternavn"]),
                        Fornavn = Helper.ConvertDataFromDb.ToString(reader["Fornavn"]),
                        E_mail_adresse = Helper.ConvertDataFromDb.ToString(reader["E-mail-adresse"]),
                        Stilling = Helper.ConvertDataFromDb.ToString(reader["Stilling"]),
                        Telefon_arbejde = Helper.ConvertDataFromDb.ToString(reader["Telefon (arbejde)"]),
                        Telefon_privat = Helper.ConvertDataFromDb.ToString(reader["Telefon (privat)"]),
                        Mobiltelefon = Helper.ConvertDataFromDb.ToString(reader["Mobiltelefon"]),
                        Faxnummer = Helper.ConvertDataFromDb.ToString(reader["Faxnummer"]),
                        Adresse = Helper.ConvertDataFromDb.ToString(reader["Adresse"]),
                        By = Helper.ConvertDataFromDb.ToString(reader["By"]),
                        Stat_provins = Helper.ConvertDataFromDb.ToString(reader["Stat/provins"]),
                        Postnummer = Helper.ConvertDataFromDb.ToString(reader["Postnummer"]),
                        Land_omraede = Helper.ConvertDataFromDb.ToString(reader["Land/område"]),
                        Webside = Helper.ConvertDataFromDb.ToString(reader["Webside"]),
                        Noter = Helper.ConvertDataFromDb.ToString(reader["Noter"]),
                        Vedhaeftede_filer = Encoding.ASCII.GetBytes(Helper.ConvertDataFromDb.ToString(reader["Vedhæftede filer"]))
                    };

                    customers.Add(customer);
                }

                reader.Close();
            }

            return customers;
        }
    }
    namespace SDU_API_AFnc.DAL
    {
        internal class CustomerRepository
        {
        }
    }
}