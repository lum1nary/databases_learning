using System;

namespace Databases
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvProvider = new CsvDataProvider();
            var sqlProvider = new SqlDataProvider();

            Console.WriteLine("Hello World!");

            var serverAddress = "127.0.0.1";
            var dbName = "test";
            var userName = "lmnr";
            var userPass = "19954428";

            sqlProvider.Open(serverAddress, dbName, userName, userPass);

            var data = csvProvider.GetUserData();

            sqlProvider.AddUserData(data);

            //foreach (var item in sqlProvider.GetUserData())
            //{
            //    Console.WriteLine($"User : {item}");
            //}

            Console.ReadKey();
        }

    }
}
