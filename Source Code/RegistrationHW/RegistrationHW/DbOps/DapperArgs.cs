using Dapper;
using Newtonsoft.Json.Linq;
using RegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegistrationAPI.DbOps
{
    public class DapperArgs
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString);

        public bool Insert(JObject jsonData)
        {
            try
            {
                //Check if extra properties are being added
               if(jsonData.Property("ID") != null || jsonData.Property("DateCreated") != null)
                {
                    return false;
                }

                var data = jsonData.ToObject<RegisteredUsers>();

                //Validate inputs
                if (data.Validate())
                {
                    var dp = new DynamicParameters();

                    //Paramaterization to prevent injection
                    dp.Add("ID", data.ID);
                    dp.Add("FirstName", data.FirstName);
                    dp.Add("LastName", data.LastName);
                    dp.Add("Address1", data.Address1);
                    dp.Add("Address2", data.Address2);
                    dp.Add("City", data.City);
                    dp.Add("State", data.State);
                    dp.Add("Zip", data.Zip);
                    dp.Add("Country", data.Country);
                    dp.Add("DateCreated", data.DateCreated);

                    var query = $"INSERT INTO {nameof(RegisteredUsers)} VALUES (@{nameof(RegisteredUsers.ID)}, @{nameof(RegisteredUsers.FirstName)}," +
                        $"@{nameof(RegisteredUsers.LastName)},@{nameof(RegisteredUsers.Address1)},@{nameof(RegisteredUsers.Address2)}," +
                        $"@{nameof(RegisteredUsers.City)},@{nameof(RegisteredUsers.State)},@{nameof(RegisteredUsers.Zip)}," +
                        $"@{nameof(RegisteredUsers.Country)},@{nameof(RegisteredUsers.DateCreated)})";

                    con.Open();

                    var result = con.Execute(query, dp) > 0;

                    con.Close();

                    return result;
                }

                return false;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public IEnumerable<RegisteredUsers> GetUsers()
        {
            var query = $"SELECT * FROM {nameof(RegisteredUsers)} ORDER BY DateCreated DESC";

            con.Open();

            var result = con.Query<RegisteredUsers>(query);

            con.Close();

            return result;
        }
    }
}