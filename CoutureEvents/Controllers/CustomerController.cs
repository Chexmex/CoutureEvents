using CoutureEvents.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoutureEvents.Controllers
{
    public class CustomerController : Controller
    {
        public IEnumerable<CustomerModel> Get()
        {
            List<CustomerModel> model = new List<CustomerModel>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ceString"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "sp_GetCustomer";
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerModel Customer = new CustomerModel();
                        Customer.BrideFirstName = reader.GetString(reader.GetOrdinal("BrideFirstName"));
                        Customer.BrideLastName = reader.GetString(reader.GetOrdinal("BrideLastName"));
                        Customer.GroomFirstName = reader.GetString(reader.GetOrdinal("GroomFirstName"));
                        Customer.GroomLastName = reader.GetString(reader.GetOrdinal("GroomLastName"));
                        Customer.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                        Customer.Email = reader.GetString(reader.GetOrdinal("Email"));
                        Customer.Address = reader.GetString(reader.GetOrdinal("Address"));
                        Customer.City = reader.GetString(reader.GetOrdinal("City"));
                        Customer.WeddingDate = reader.GetDateTime(reader.GetOrdinal("WeddingDate"));
                        Customer.NumberOfGuests = reader.GetInt32(reader.GetOrdinal("NumberOfGuests"));
                        Customer.NumberOfBridesmaids = reader.GetInt32(reader.GetOrdinal("NumberOfBridesmaids"));
                        Customer.NumberOfGroomsmen = reader.GetInt32(reader.GetOrdinal("NumberOfGroomsmen"));
                        model.Add(Customer);
                    }
                }

                connection.Close();
            }
            return model;
        }
    }
}
