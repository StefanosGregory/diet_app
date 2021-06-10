using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public class GenerationOfDiet
    {
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        private readonly DateTime _dateTime;
        private List<NutritionInfo> _monday = new List<NutritionInfo>(), _tuesday = new List<NutritionInfo>(), _wednesday = new List<NutritionInfo>(), _thursday = new List<NutritionInfo>(), _friday = new List<NutritionInfo>(), _saturday = new List<NutritionInfo>(), _sunday = new List<NutritionInfo>();
        private ClientCalories _clientCalories = null;
        private readonly string _clientType, _dietType, _sex;
        private readonly int _age, _id, _clientshistoryid;

        public GenerationOfDiet()
        {
            
        }
        public GenerationOfDiet(string clientType, string dietType, DateTime dateTime, int age, string sex, int id, int clientshistoryid)
        {
            _clientType = clientType;
            _dietType = dietType;
            _dateTime = dateTime;
            _age = age;
            _sex = sex;
            _id = id;
            _clientshistoryid = clientshistoryid;
        }

        private void getCaloriesInfo()
        {
            //
            _clientCalories = new ClientCalories(_clientType, _age);
        }

        public NutritionInfo getOldDiet()
        {
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    CommandText = "SELECT typesa, diet_type, monday, tuesday, wednesday, thursday, friday, saturday, sunday FROM clientdiet WHERE clientsid = @clientsid AND datetime = @datetime AND clientshistoryid = @clientshistoryid;",
                    Connection = conn
                };
                cmd.Parameters.Add("@clientsid", NpgsqlDbType.Integer).Value = _id;
                cmd.Parameters.Add("@datetime", NpgsqlDbType.Date).Value = _dateTime;
                cmd.Parameters.Add("@clientshistoryid", NpgsqlDbType.Integer).Value = _clientshistoryid;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //
                        
                    }
                }
                else
                {
                    MessageBox.Show(@"No diet found for the selected date.");
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
        public NutritionInfo DietGeneration()
        {
            var conn = new NpgsqlConnection(Cs);
            var cmdMain = new NpgsqlCommand
            {
                CommandText = "SELECT * FROM food_options WHERE id = @id and type = 'Main';",
                Connection = conn 
            };
            cmdMain.Parameters.Add("@id", NpgsqlDbType.Integer).Value = "";
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