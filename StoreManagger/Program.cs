using System;

namespace StoreManagger
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=StoreDataBase1;Integrated Security=True";
            //Acesses.insertData(connectionString);
            Acesses da = new Acesses();

            //int c= da.insertPData(connectionString);
            //Console.WriteLine(c+"row Effected");
            //da.readData(connectionString);

            int t = da.insertDataC(connectionString);
            Console.WriteLine(t + "row Effected");



            da.readDataC(connectionString);
        }
    }
}
