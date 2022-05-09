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
    public class ZanraiRepository
    {
        public List<Zanrai> GetZanrai()
        {
            List<Zanrai> zanrai = new List<Zanrai>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `zanrai`";// @"SELECT a.id_formos, a.name FROM "  + "formos a";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                zanrai.Add(new Zanrai
                {
                    id_zanrai = Convert.ToInt32(item["id_zanrai"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"])
                });
            }

            return zanrai;
        }
    }
}