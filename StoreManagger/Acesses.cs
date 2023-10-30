using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace StoreManagger
{
    class Acesses
    {
        public static int c = 0;
        public int insertPData(string connectionString)
        {

            int categoryId, price;
            string name, img, descraption;
            Console.WriteLine("add more?");

            string addM = Console.ReadLine();

            while (addM == "y")
            {


                Console.WriteLine("insert CategoryId");
                categoryId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("insert Price");
                price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("insert name");
                name = Console.ReadLine();
                Console.WriteLine("insert img");
                img = Console.ReadLine();
                Console.WriteLine("insert Description");
                descraption = Console.ReadLine();


                string query = "INSERT INTO[dbo].[Products](categoryId, price, name, img, description)" +
            "VALUES (@categoryId,@price,@name,@img,@descraption)";
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                    cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
                    cmd.Parameters.Add("@img", SqlDbType.VarChar, 50).Value = img;
                    cmd.Parameters.Add("@descraption", SqlDbType.VarChar, 50).Value = descraption;
                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    c++;
                    cn.Close();
                    Console.WriteLine("add more?");

                    addM = Console.ReadLine();


                }

            }

            return c;
        }
        public void readData(string connectionString)
        {
            string queryString = "select * from Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]
                            );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();



            }
        }






        public int insertDataC(string connectionString)
        {
            int couunt = 0;
            string name;

            Console.WriteLine("add more?");

            string addM = Console.ReadLine();

            while (addM == "y")
            {



                Console.WriteLine("insert name");
                name = Console.ReadLine();



                string query = "INSERT INTO[dbo].[Category]( name)" +
            "VALUES (@name)";
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {


                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;

                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    couunt++;
                    cn.Close();
                    Console.WriteLine("add more?");

                    addM = Console.ReadLine();


                }

            }

            return couunt;
        }

        public void readDataC(string connectionString)
        {
            string queryString = "select * from Category";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]
                            );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();



            }
        }



    }
}
