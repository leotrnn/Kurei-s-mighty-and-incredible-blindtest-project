using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KureiBlindTest
{
    internal class AddSong
    {
        // Sélectionne tous les genres de la base de données
        public List<Genre> SelectAllGenres()
        {
            List<Genre> lstGenres = new List<Genre>();
            string connectionString = ConfigurationManager.ConnectionStrings["KureiBlindTest"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM GENRES";

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int idGenre = Convert.ToInt32(row["idGenre"]);
                            string nameGenre = row["nameGenre"].ToString();

                            lstGenres.Add(new Genre(idGenre, nameGenre));
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message);
                }
            }

            return lstGenres;
        }
    }
}
