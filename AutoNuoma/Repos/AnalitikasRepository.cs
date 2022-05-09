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
    public class AnalitikasRepository
    {
        public string getUsername(string prisijungimo_vardass)
        {
            Analitikas a = new Analitikas();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "analitikas where prisijungimo_vardas=?prisijungimo_vardass";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?prisijungimo_vardass", MySqlDbType.VarChar).Value = prisijungimo_vardass;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                a.prisijungimo_vardas = Convert.ToString(item["prisijungimo_vardas"]);
                a.slaptazodis = Convert.ToString(item["slaptazodis"]);
            }
            return a.slaptazodis;
        }

    }
}