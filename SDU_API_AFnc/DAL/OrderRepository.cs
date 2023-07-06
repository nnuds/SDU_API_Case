using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

using SDU_API_Models_CustomerOrder;

namespace SDU_API_AFnc.DAL
{
    public static class OrderRepository
    {
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SDU_db1;Integrated Security=True;";

        public static List<SDU_API_Models_CustomerOrder.Ordre> GetOrders(string customerID)
        {
            List<SDU_API_Models_CustomerOrder.Ordre> orders = new List<SDU_API_Models_CustomerOrder.Ordre>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [Ordre-id], [Medarbejder-id], [Kunde-id], [Ordredato], [Afsendelsesdato], " +
                           "[Speditør-id], [Modtagernavn], [Modtageradresse], [Modtagerby], [Modtagerstat/landsdel], " +
                           "[Modtagerpostnummer], [Modtagerland/-område], [Forsendelsesgebyr], [Skatter], " +
                           "[Betalingstype], [Betalt den], [Noter], [Momssats], [Momsstatus], [Status-id] " +
                           "FROM [dbo].[Ordrer] " +
                           "WHERE [Kunde-id]=@CustomerID ";
                                                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SDU_API_Models_CustomerOrder.Ordre order = new SDU_API_Models_CustomerOrder.Ordre
                    {
                        Ordre_id = reader.GetInt32(reader.GetOrdinal("Ordre-id")),
                        Medarbejder_id = reader.IsDBNull(reader.GetOrdinal("Medarbejder-id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Medarbejder-id")),
                        Kunde_id = reader.IsDBNull(reader.GetOrdinal("Kunde-id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Kunde-id")),
                        Ordredato = reader.IsDBNull(reader.GetOrdinal("Ordredato")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Ordredato")),
                        Afsendelsesdato = reader.IsDBNull(reader.GetOrdinal("Afsendelsesdato")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Afsendelsesdato")),
                        Speditoer_id = reader.IsDBNull(reader.GetOrdinal("Speditør-id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Speditør-id")),
                        Modtagernavn = reader.GetString(reader.GetOrdinal("Modtagernavn")),
                        Modtageradresse = reader.GetString(reader.GetOrdinal("Modtageradresse")),
                        Modtagerby = reader.GetString(reader.GetOrdinal("Modtagerby")),
                        Modtagerstat_landsdel = reader.GetString(reader.GetOrdinal("Modtagerstat/landsdel")),
                        Modtagerpostnummer = reader.GetString(reader.GetOrdinal("Modtagerpostnummer")),
                        Modtagerland_område = reader.GetString(reader.GetOrdinal("Modtagerland/-område")),
                        Forsendelsesgebyr = reader.GetDecimal(reader.GetOrdinal("Forsendelsesgebyr")),
                        Skatter = reader.GetDecimal(reader.GetOrdinal("Skatter")),
                        Betalingstype = reader.GetString(reader.GetOrdinal("Betalingstype")),
                        Betalt_den = reader.IsDBNull(reader.GetOrdinal("Betalt den")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Betalt den")),
                        Noter = reader.GetString(reader.GetOrdinal("Noter")),
                        Momssats = reader.GetDecimal(reader.GetOrdinal("Momssats")),
                        Momsstatus = reader.GetString(reader.GetOrdinal("Momsstatus")),
                        Status_id = reader.IsDBNull(reader.GetOrdinal("Status-id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Status-id"))
                    };

                    orders.Add(order);
                }

                reader.Close();
            }

            return orders;
        }
    }
}