using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using AutoNuoma.ViewModels;
using MySql.Data.MySqlClient;

namespace AutoNuoma.Repos
{
    public class UzsakymasRepository
    {
        public List<UzsakymaiViewModel> GetUzsakymas()
        {
            List<UzsakymaiViewModel> uzsakymasViewModels = new List<UzsakymaiViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `uzsakymas`";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                uzsakymasViewModels.Add(new UzsakymaiViewModel
                {
                    uzsakymo_data = Convert.ToString(item["uzsakymo_data"]),
                    uzsakymo_busena = Convert.ToString(item["uzsakymo_busena"]),
                    pristatymo_data = Convert.ToString(item["pristatymo_data"]),
                    uzsakovas = Convert.ToString(item["uzsakovas"]),
                    uzsakymo_kodas = Convert.ToString(item["uzsakymo_kodas"]),
                    mokejimo_data = Convert.ToString(item["mokejimo_data"]),
                    kaina = Convert.ToString(item["kaina"])
                });
            }

            return uzsakymasViewModels;
        }
    }
}