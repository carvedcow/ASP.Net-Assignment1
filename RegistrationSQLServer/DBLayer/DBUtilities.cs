using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace RegistrationSQLServer.DBLayer
{
    public class DBUtilities
    {
        //private static SqlConnection GetSqlConnection()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();

        //    return new SqlConnection(connectionString);

        //}

        //public static int InsertUserInformation(BusinessLayer.UserInformation ui)
        //{

        //    int result;

        //    using (SqlConnection cnn = GetSqlConnection())
        //    {
        //        String sql = $"Insert into UserInformation(FirstName,LastName,Address,City,Province,PostalCode,Country) values ('{ui.FirstName}','{ui.LastName}','{ui.Address}','{ui.City}','{ui.Province}','{ui.PostalCode}','{ui.Country}')";

        //        using (SqlCommand command = new SqlCommand(sql, cnn))
        //        {
        //            using (SqlDataAdapter adapter = new SqlDataAdapter())
        //            {
        //                cnn.Open();

        //                adapter.InsertCommand = new SqlCommand(sql, cnn);

        //                result = adapter.InsertCommand.ExecuteNonQuery();
        //            }
        //        }
        //    }

        //    return result;

        //}

        private static SqlConnection GetSqlConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();

            return new SqlConnection(connectionString);

        }

        public static int InsertUserInformation(BusinessLayer.UserInformation ui)
        {

            int result;

            using (SqlConnection cnn = GetSqlConnection())
            {
                String sql = $"INSERT INTO UserInformation(FirstName,LastName,Address,City,Province,PostalCode,Country) OUTPUT INSERTED.ID VALUES ('{ui.FirstName}','{ui.LastName}','{ui.Address}','{ui.City}','{ui.Province}','{ui.PostalCode}','{ui.Country}')";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    cnn.Open();

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;
                    result = (int)command.ExecuteScalar();
                    //result = command.ExecuteNonQuery();
                }
            }

            return result;

        }

        public static BusinessLayer.UserInformation SelectUserInformationById(int userId)
        {
            BusinessLayer.UserInformation userInformation = new BusinessLayer.UserInformation();

            using (SqlConnection cnn = GetSqlConnection())
            {
                String sql = $"Select * From UserInformation Where Id = {userId}";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    cnn.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            userInformation.Id = (int)dataReader.GetValue(0);
                            userInformation.FirstName = (string)dataReader.GetValue(1);
                            userInformation.LastName = (string)dataReader.GetValue(2);
                            userInformation.Address = (string)dataReader.GetValue(3);
                            userInformation.City = (string)dataReader.GetValue(4);
                            userInformation.Province = (string)dataReader.GetValue(5);
                            userInformation.PostalCode = (string)dataReader.GetValue(6);
                            userInformation.Country = (string)dataReader.GetValue(7);
                        }
                    }
                }
            }

            return userInformation;
        }

        public static int UpdateUserInformationById(int userId, BusinessLayer.UserInformation ui)
        {
            int result;

            using (SqlConnection cnn = GetSqlConnection())
            {
                String sql = $"UPDATE UserInformation SET FirstName = '{ui.FirstName}', LastName = '{ui.LastName}', Address = '{ui.Address}', City = '{ui.City}', Province = '{ui.Province}', PostalCode = '{ui.PostalCode}', Country = '{ui.Country}' WHERE Id = {userId}";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    cnn.Open();

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;
                    result = command.ExecuteNonQuery();
                }
            }

            return result;
        }

    }
}