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
    public class KalbosRepository
    {
        public List<Kalbos> GetKalba()
        {
            List<Kalbos> kalbos = new List<Kalbos>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `kalbos`";// @"SELECT a.id_formos, a.name FROM "  + "formos a";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                kalbos.Add(new Kalbos
                {
                    id_kalbos = Convert.ToInt32(item["id_kalbos"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"])
                });
            }

            return kalbos;
        }
    }
}