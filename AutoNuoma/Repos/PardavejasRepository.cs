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
    public class PardavejasRepository
    {
        public string getUsername(string prisijungimo_vardass)
        {
            Pardavejas pardavejas = new Pardavejas();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "pardavejas where prisijungimo_vardas=?prisijungimo_vardass";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?prisijungimo_vardass", MySqlDbType.VarChar).Value = prisijungimo_vardass;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                pardavejas.prisijungimo_vardas = Convert.ToString(item["prisijungimo_vardas"]);
                pardavejas.slaptazodis = Convert.ToString(item["slaptazodis"]);
            }
            return pardavejas.slaptazodis;


        }

    }
}