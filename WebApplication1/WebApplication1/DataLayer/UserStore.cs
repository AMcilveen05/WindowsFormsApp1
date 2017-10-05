using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace WebApplication1.DataLayer
{
    public class UserStore
    {
        public UserStore()
        {

        }

        public  User GetUsers()
        {
            //Store all users
            User person = new User();

            using (SqlConnection conn = new SqlConnection("Server=ALASTAIR-PC\\SQLEXPRESS; Database=TestDB; User Id=NewUser;Password = password"))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("Read_Users", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                   
                        person.UserName = rdr["UserName"].ToString();
                        person.Password = rdr["Password"].ToString();
                        person.FirstName = rdr["FirstName"].ToString();
                        person.LastName = rdr["LastName"].ToString();


                    }
                }
            }

            return person;
        }

        public int VerifyUsers(User user)
        {
            var result = 2;
            using (SqlConnection conn = new SqlConnection("Server=ALASTAIR-PC\\SQLEXPRESS; Database=TestDB; User Id=NewUser;Password = password"))
            {
               
                // 1.  create a command object identifying the stored procedure
                using (SqlCommand cmd = new SqlCommand("VerifyUser", conn))
                {
           
                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@userName", user.UserName));
                    cmd.Parameters.Add(new SqlParameter("@password", user.Password));
                    SqlParameter returnValueParam = cmd.Parameters.Add("@return_value", SqlDbType.Int);
                    returnValueParam.Direction = ParameterDirection.ReturnValue;

                    //4. open the connection and get the return value
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)returnValueParam.Value;
                }
            }
            return result;
        }
    }
}
