using System;
using System.Data.SQLite;

namespace DIO.Series
{
    public class Conexao
    {
        public SQLiteConnection DbCon()
        {
            var connection = new SQLiteConnection("Data Source=D:/Curso .net c#/Dio.series/DIO.Series/Data/dio.db");
           
            try{
                connection.Open();
            }
            catch(SQLiteException ex)
            {
                Console.WriteLine("{0}", ex);
            }
            
            return connection;
            
        }
    }
}