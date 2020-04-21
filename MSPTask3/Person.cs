using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MSPTask3
{
    class Person
    {
        public string Name;
        public int age;
        public int ID;
        public string Email;
        string connString = "Data Source=DESKTOP-TMO81QG;Initial Catalog=Person;Integrated Security=True;Pooling=False";

        public void AddToDatabase(string name, int age, string email)
        {
            // ADD To SQL Data Base
            using (SqlConnection cnn = new SqlConnection())
            {
                cnn.ConnectionString = connString;
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tablee (fName, Email, Age) VALUES (@name, @email, @age);", cnn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.ExecuteNonQuery();
                }
                
            }
        }

        public void SearchByEmail(string email)
        {
            using (SqlConnection cnn = new SqlConnection())
            {
                cnn.ConnectionString = connString;
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Select ID FROM tablee where Email LIKE '%' + @email + '%'", cnn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.ID = (int)reader["ID"];
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("Select fName FROM tablee where Email LIKE '%' + @email + '%'", cnn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.Name = (string)reader["fName"];
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("Select Age FROM tablee where Email LIKE '%' + @email + '%'", cnn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.age = (int)reader["Age"];
                        }
                    }
                }

            }
        }
       
    }
}
//(new SqlParameter("name", name));
/*
 SqlCommand cmd = new SqlCommand("INSERT INTO tablee (fName, Email, Age) VALUES (@name, @email, @age);", cnn);
                cmd.Parameters.Add("@name", name);
                cmd.Parameters.Add("@email", email);
                cmd.Parameters.Add("@age", age);
                //cmd.ExecuteNonQuery(); 
 */
