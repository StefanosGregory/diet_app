using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public class ClientCalories
    {
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        private readonly int _id, _calories;
        public ClientCalories(string type, int age, string sex)
        {
            //
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT id, standard, active athletic FROM caloriesinfo WHERE type = @type AND (agemin >= @age AND agemax <= @age) AND sex = @sex;"
                };
                cmd.Parameters.Add("@type", NpgsqlDbType.Char).Value = type;
                cmd.Parameters.Add("@age", NpgsqlDbType.Integer).Value = age;
                cmd.Parameters.Add("@sex", NpgsqlDbType.Char).Value = sex;
                
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _id = short.Parse(reader[0].ToString());
                    _calories = type switch
                    {
                        "Standard" => short.Parse(reader[1].ToString()),
                        "Active" => short.Parse(reader[2].ToString()),
                        "Athletic" => short.Parse(reader[3].ToString()),
                        _ => _calories
                    };
                }
                
                conn.Dispose();
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public int GetId() { return _id; }
        public int GetCalories() { return _calories; }
    }
}