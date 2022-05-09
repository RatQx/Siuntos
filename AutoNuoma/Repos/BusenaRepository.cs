using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using AutoNuoma.Models;
using MySql.Data.MySqlClient;

namespace AutoNuoma.Repos
{
    public class BusenaRepository
    {
        public List<Busena> GetBusena()
        {
            List<Busena> busenos = new List<Busena>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `busenos`";// @"SELECT a.id_formos, a.name FROM "  + "formos a";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                busenos.Add(new Busena
                {
                    id_busenos = Convert.ToInt32(item["id_busenos"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"])
                });
            }

            return busenos;
        }
    }
}