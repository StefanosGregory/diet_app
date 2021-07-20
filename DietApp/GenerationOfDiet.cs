using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public class GenerationOfDiet
    {
        private readonly Random _r = new();
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        private readonly DateTime _dateTime;
        private readonly List<NutritionInfo> _monday = new(), _tuesday = new(), _wednesday = new(), _thursday = new(), _friday = new(), _saturday = new(), _sunday = new();
        private string _clientType, _dietType;
        private readonly int _id, _clientshistoryid;

        // Getters for _clientType and _dietType and _days
        public string GetClientType() { return _clientType; }
        public string GetDietType() { return _dietType; }

        public IEnumerable<List<NutritionInfo>> GetDays()
        {
            var days = new List<List<NutritionInfo>> {_monday, _tuesday, _wednesday, _thursday, _friday, _saturday, _sunday};
            return days;
        }
        
        // Public Constructors
        public GenerationOfDiet(int id, int clientshistoryid, DateTime dateTime)
        {
            _id = id;
            _clientshistoryid = clientshistoryid;
            _dateTime = dateTime;
            
            GetOldDiet();
        }
        public GenerationOfDiet(string clientType, string dietType, DateTime dateTime, int id, int clientshistoryid)
        {
            if (clientshistoryid == 0)
            {
                MessageBox.Show(@"Client hasn't been measured for the select date " + dateTime);
                return;
            }
            
            _clientType = clientType;
            _dietType = dietType;
            _dateTime = dateTime;
            _id = id;
            _clientshistoryid = clientshistoryid;
            
            DietGeneration();
        }

        // Select old diet plan.
        private void SplitDietProgram(IEnumerable<string> days)
        {
            string[] separator = {","}, daySeparator = {"_", "{", "}"};
            var i = 1;
            foreach (var day in days)
            {
                // Split values per day
                var dayProgram = day.Split(separator, 7, StringSplitOptions.RemoveEmptyEntries);
                foreach (var details in dayProgram)
                {
                    var tmp = details.Split(daySeparator, 8, StringSplitOptions.RemoveEmptyEntries);
                    switch (i)
                    {
                            
                        // monday
                        case 1:
                            _monday.Add(tmp.Length == 1
                                ? new NutritionInfo(Convert.ToDouble(tmp[0]))
                                : new NutritionInfo(tmp[0], tmp[1], Convert.ToDouble(tmp[2]), Convert.ToDouble(tmp[3]),
                                    Convert.ToDouble(tmp[4]), Convert.ToDouble(tmp[5]), Convert.ToDouble(tmp[6])));
                            break;
                    
                        // Tuesday
                        case 2:
                            _tuesday.Add(tmp.Length == 1
                                ? new NutritionInfo(Convert.ToDouble(tmp[0]))
                                : new NutritionInfo(tmp[0], tmp[1], Convert.ToDouble(tmp[2]), Convert.ToDouble(tmp[3]),
                                    Convert.ToDouble(tmp[4]), Convert.ToDouble(tmp[5]), Convert.ToDouble(tmp[6])));
                            break;
                    
                        // Wednesday
                        case 3:
                            _wednesday.Add(tmp.Length == 1
                                ? new NutritionInfo(Convert.ToDouble(tmp[0]))
                                : new NutritionInfo(tmp[0], tmp[1], Convert.ToDouble(tmp[2]), Convert.ToDouble(tmp[3]),
                                    Convert.ToDouble(tmp[4]), Convert.ToDouble(tmp[5]), Convert.ToDouble(tmp[6])));
                            break;
                    
                        // Thursday
                        case 4:
                            _thursday.Add(tmp.Length == 1
                                ? new NutritionInfo(Convert.ToDouble(tmp[0]))
                                : new NutritionInfo(tmp[0], tmp[1], Convert.ToDouble(tmp[2]), Convert.ToDouble(tmp[3]),
                                    Convert.ToDouble(tmp[4]), Convert.ToDouble(tmp[5]), Convert.ToDouble(tmp[6])));
                            break;
                    
                        // Friday
                        case 5:
                            _friday.Add(tmp.Length == 1
                                ? new NutritionInfo(Convert.ToDouble(tmp[0]))
                                : new NutritionInfo(tmp[0], tmp[1], Convert.ToDouble(tmp[2]), Convert.ToDouble(tmp[3]),
                                    Convert.ToDouble(tmp[4]), Convert.ToDouble(tmp[5]), Convert.ToDouble(tmp[6])));
                            break;
                    
                        // Saturday
                        case 6:
                            _saturday.Add(tmp.Length == 1
                                ? new NutritionInfo(Convert.ToDouble(tmp[0]))
                                : new NutritionInfo(tmp[0], tmp[1], Convert.ToDouble(tmp[2]), Convert.ToDouble(tmp[3]),
                                    Convert.ToDouble(tmp[4]), Convert.ToDouble(tmp[5]), Convert.ToDouble(tmp[6])));
                            break;
                    
                        // Sunday
                        case 7:
                            _sunday.Add(tmp.Length == 1
                                ? new NutritionInfo(Convert.ToDouble(tmp[0]))
                                : new NutritionInfo(tmp[0], tmp[1], Convert.ToDouble(tmp[2]), Convert.ToDouble(tmp[3]),
                                    Convert.ToDouble(tmp[4]), Convert.ToDouble(tmp[5]), Convert.ToDouble(tmp[6])));
                            break;
                    }
                }
                i++;
            }
        }
        private void GetOldDiet()
        {
            var weekProgram = new List<string>();
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
                cmd.Parameters.Add("@datetime", NpgsqlDbType.Timestamp).Value = _dateTime;
                cmd.Parameters.Add("@clientshistoryid", NpgsqlDbType.Integer).Value = _clientshistoryid;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //
                    _clientType = reader[0].ToString();
                    _dietType = reader[1].ToString();
                    weekProgram.Add(reader[2].ToString());
                    weekProgram.Add(reader[3].ToString());
                    weekProgram.Add(reader[4].ToString());
                    weekProgram.Add(reader[5].ToString());
                    weekProgram.Add(reader[6].ToString());
                    weekProgram.Add(reader[7].ToString());
                    weekProgram.Add(reader[8].ToString());
                }


                conn.Dispose();
                conn.Close();
                
                SplitDietProgram(weekProgram);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        // Create new diet plan.
        private static string DayStringCreation(string day)
        {
            string[] separator = {","}, daySeparator = {"_", "{", "}"};
            var menu = day.Split(separator, 7, StringSplitOptions.RemoveEmptyEntries);
            var sum = menu.Select(details => details.Split(daySeparator, 8, StringSplitOptions.RemoveEmptyEntries)).Where(tmp => tmp.Length != 1).Sum(tmp => Convert.ToDouble(tmp[2]));
            var dayString = day + sum;
            return dayString;
        }
        private void AddToDb(IReadOnlyList<string> days)
        {
            var conn = new NpgsqlConnection(Cs);
            conn.Open();

            var cmd = new NpgsqlCommand
            {
                Connection = conn,
                CommandText = "INSERT INTO clientdiet VALUES (DEFAULT, @clientsid, @clientshistoryid, @datetime, @typesa, @diet_type, @monday, @tuesday, @wednesday, @thursday, @friday, @saturday, @sunday);"
            };
            cmd.Parameters.Add("@clientsid", NpgsqlDbType.Integer).Value = _id;
            cmd.Parameters.Add("@clientshistoryid", NpgsqlDbType.Integer).Value = _clientshistoryid;
            cmd.Parameters.Add("@datetime", NpgsqlDbType.Timestamp).Value = _dateTime;
            cmd.Parameters.Add("@typesa", NpgsqlDbType.Char).Value = _clientType;
            cmd.Parameters.Add("@diet_type", NpgsqlDbType.Char).Value = _dietType;
            cmd.Parameters.Add("@monday", NpgsqlDbType.Text).Value = days[0];
            cmd.Parameters.Add("@tuesday", NpgsqlDbType.Text).Value = days[1];
            cmd.Parameters.Add("@wednesday", NpgsqlDbType.Text).Value = days[2];
            cmd.Parameters.Add("@thursday", NpgsqlDbType.Text).Value = days[3];
            cmd.Parameters.Add("@friday", NpgsqlDbType.Text).Value = days[4];
            cmd.Parameters.Add("@saturday", NpgsqlDbType.Text).Value = days[5];
            cmd.Parameters.Add("@sunday", NpgsqlDbType.Text).Value = days[6];

            if (cmd.ExecuteNonQuery() > 0) MessageBox.Show(@"Diet plan inserted successfully!");
            
            conn.Dispose();
            conn.Close();
        }
        private void DietGeneration()
        {
            string[] breakfast = new string[7], main = new string[14], snack = new string[21];

            switch (_dietType)
            {
                default: 
                    for (var i = 0; i < 7; i++)
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();
                var cmdBreakfast = new NpgsqlCommand
                {
                    CommandText = "SELECT * FROM food_options WHERE id = @id and type = 'Breakfast';",
                    Connection = conn 
                };
                
                cmdBreakfast.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _r.Next(44, 50);
                var reader = cmdBreakfast.ExecuteReader();
                while (reader.Read())
                {
                    // FoodName_FoodType_{calories-fat-proteins-carbohydrates-carbs},...,totalCalories
                    var str = reader[1] + "_" + reader[2] + "_{" + reader[3] + "_" + reader[4] + "_" + reader[5] + "_" + reader[6] + "_" + reader[7] + "},";

                    breakfast[i] = str;
                }
                conn.Dispose();
                conn.Close();
            }
                    for (var i = 0; i < 14; i++)
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();
                var cmdMain = new NpgsqlCommand
                {
                    CommandText = "SELECT * FROM food_options WHERE id = @id and type = 'Main';",
                    Connection = conn 
                };
                cmdMain.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _r.Next(1, 44);
                var reader = cmdMain.ExecuteReader();
                while (reader.Read())
                {
                    // FoodName_FoodType_{calories-fat-proteins-carbohydrates-carbs},...,totalCalories
                    var str = reader[1] + "_" + reader[2] + "_{" + reader[3] + "_" + reader[4] + "_" + reader[5] + "_" + reader[6] + "_" + reader[7] + "},";

                    main[i] = str;
                }
                conn.Dispose();
                conn.Close();
            }
                    for (var i = 0; i < 21; i++)
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();
                var cmdSnack = new NpgsqlCommand
                {
                    CommandText = "SELECT * FROM food_options WHERE id = @id and type = 'Snack';",
                    Connection = conn 
                };
                cmdSnack.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _r.Next(50, 55);
                var reader = cmdSnack.ExecuteReader();
                while (reader.Read())
                {
                    // FoodName_FoodType_{calories-fat-proteins-carbohydrates-carbs},...,totalCalories
                    var str = reader[1] + "_" + reader[2] + "_{" + reader[3] + "_" + reader[4] + "_" + reader[5] + "_" + reader[6] + "_" + reader[7] + "},";

                    snack[i] = str;
                }
                conn.Dispose();
                conn.Close();
            }

                    break;
                case "Muscle Gain":
                    /*
                     * For random:
                     *      create a new array and insert ids ,
                     *      2 loops, 2 queries:
                     *          1) sql to insert ids
                     *          2) sql to select random given number from ids
                     */
                    string[] type = {"Breakfast", "Main", "Snack"};
                    var breakfastIds = new List<int>();
                    var mainIds = new List<int>();
                    var snacksIds = new List<int>();
                    
                    foreach (var s in type)
                    {
                        var connTmp = new NpgsqlConnection(Cs);
                        connTmp.Open();
                        var sql = new NpgsqlCommand
                        {
                            CommandText =
                                "SELECT id FROM food_options WHERE protein > 15 and type = @type;",
                            Connection = connTmp
                        };

                        sql.Parameters.Add("@type", NpgsqlDbType.Char).Value = s;
                        var reader = sql.ExecuteReader();
                        while (reader.Read())
                        {
                            switch (s)
                            {
                                case "Breakfast":
                                    breakfastIds.Add(short.Parse(reader[0].ToString()));
                                    break;
                                case "Main":
                                    mainIds.Add(short.Parse(reader[0].ToString()));
                                    break;
                                case "Snack":
                                    snacksIds.Add(short.Parse(reader[0].ToString()));
                                    break;
                            }
                        }
                        
                        connTmp.Dispose();
                        connTmp.Close();
                    }
                    for (var i = 0; i < 7; i++)
                    {
                        var conn = new NpgsqlConnection(Cs);
                        conn.Open();
                        var cmdBreakfast = new NpgsqlCommand
                        {
                            CommandText = "SELECT * FROM food_options WHERE id = @id and type = 'Breakfast' order by id;",
                            Connection = conn 
                        };
                        cmdBreakfast.Parameters.Add("@id", NpgsqlDbType.Integer).Value = breakfastIds[_r.Next(breakfastIds.Count)];
                        var reader = cmdBreakfast.ExecuteReader();
                        while (reader.Read())
                        {
                            // FoodName_FoodType_{calories-fat-proteins-carbohydrates-carbs},...,totalCalories
                            var str = reader[1] + "_" + reader[2] + "_{" + reader[3] + "_" + reader[4] + "_" + reader[5] + "_" + reader[6] + "_" + reader[7] + "},";

                            breakfast[i] = str;
                        }
                        conn.Dispose();
                        conn.Close();
                    }
                    for (var i = 0; i < 14; i++)
                    {
                        var conn = new NpgsqlConnection(Cs);
                        conn.Open();
                        var cmdMain = new NpgsqlCommand
                        {
                            CommandText = "SELECT * FROM food_options WHERE id = @id and type = 'Main' order by id;",
                            Connection = conn 
                        };
                        cmdMain.Parameters.Add("@id", NpgsqlDbType.Integer).Value = mainIds[_r.Next(mainIds.Count)];
                        var reader = cmdMain.ExecuteReader();
                        while (reader.Read())
                        {
                            // FoodName_FoodType_{calories-fat-proteins-carbohydrates-carbs},...,totalCalories
                            var str = reader[1] + "_" + reader[2] + "_{" + reader[3] + "_" + reader[4] + "_" + reader[5] + "_" + reader[6] + "_" + reader[7] + "},";

                            main[i] = str;
                        }
                        conn.Dispose();
                        conn.Close();
                    }
                    for (var i = 0; i < 21; i++)
                    {
                        var conn = new NpgsqlConnection(Cs);
                        conn.Open();
                        var cmdSnack = new NpgsqlCommand
                        {
                            CommandText = "SELECT * FROM food_options WHERE id = @id and type = 'Snack' order by id;",
                            Connection = conn 
                        };
                        cmdSnack.Parameters.Add("@id", NpgsqlDbType.Integer).Value = snacksIds[_r.Next(0, snacksIds.Count)];
                        var reader = cmdSnack.ExecuteReader();
                        while (reader.Read())
                        {
                            // FoodName_FoodType_{calories-fat-proteins-carbohydrates-carbs},...,totalCalories
                            var str = reader[1] + "_" + reader[2] + "_{" + reader[3] + "_" + reader[4] + "_" + reader[5] + "_" + reader[6] + "_" + reader[7] + "},";

                            snack[i] = str;
                        }
                        conn.Dispose();
                        conn.Close();
                    }
                    break;
            }

            // Create days string 
            var days = new List<string>
            {
                // Monday
                DayStringCreation(breakfast[0] + snack[0] + main[0] + snack[1] + snack[2] + main[1]),
                
                // Tuesday
                DayStringCreation(breakfast[1] + snack[3] + main[2] + snack[4] + snack[5] + main[3]),
                
                // Wednesday
                DayStringCreation(breakfast[2] + snack[6] + main[4] + snack[7] + snack[8] + main[5]),
                
                // Thursday
                DayStringCreation(breakfast[3] + snack[9] + main[6] + snack[11] + snack[11] + main[7]),
                
                // Friday
                DayStringCreation(breakfast[4] + snack[12] + main[8] + snack[13] + snack[14] + main[9]),
                
                // Saturday
                DayStringCreation(breakfast[5] + snack[15] + main[10] + snack[16] + snack[17] + main[11]),
                
                // Sunday
                DayStringCreation(breakfast[6] + snack[18] + main[12] + snack[19] + snack[20] + main[13])
            };
            
            // Add to _days
            SplitDietProgram(days);
            
            // Add to DB
            AddToDb(days);
        }
    }
}