using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Vedauri.CRUD
{
    public class ContactCRUD
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        public int StoreContactMessage(string email, string service, string msg)
        {
            int result = 0;
            string textCommand = "INSERT INTO tbl_ClientMessages (Email, Service, Message) OUTPUT INSERTED.ClientMessageId VALUES (@Email, @Service, @Message)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(textCommand, connection);

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Service", service);
                command.Parameters.AddWithValue("@Message", msg);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = Convert.ToInt32(reader["ClientMessageId"].ToString());
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
    }
}