using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public class GenerationOfDiet
    {
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        private DateTime _dateTime;
        private string _clientType, _dietType, _sex;
        private int _bmi, _height, _age, _id;

        public GenerationOfDiet(string clientType, string dietType, int height, DateTime dateTime, int age, string sex, int id)
        {
            _clientType = clientType;
            _dietType = dietType;
            _height = height;
            _dateTime = dateTime;
            _age = age;
            _sex = sex;
            _id = id;

            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    CommandText = "SELECT bmi FROM clientshistory WHERE datetime = @datetime AND id = @id;",
                    Connection = conn
                };
                cmd.Parameters.Add("@datetime", NpgsqlDbType.Date).Value = _dateTime;
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _id;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _bmi = short.Parse(reader[0].ToString());
                }
                conn.Dispose();
                conn.Close();
                
            }
            catch (SqlException e)
            {
                //
            }
        }

        public string dietGeneration()
        {
            string diet;
            var main = new string[2];  
            var conn = new NpgsqlConnection(Cs);
            var cmdMain = new NpgsqlCommand
            {
                CommandText = "SELECT * FROM food_options WHERE type = 'Main';",
                Connection = conn 
            };
            var reader = cmdMain.ExecuteReader();
            var i = 0;
            while (reader.Read())
            {
                //main[i] = reader[]
                i++;
            }
            
            return null;
        }
    }
}