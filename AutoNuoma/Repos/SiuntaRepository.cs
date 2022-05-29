using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using AutoNuoma.ViewModels;
using MySql.Data.MySqlClient;
using AutoNuoma.Models;

namespace AutoNuoma.Repos
{
    public class SiuntaRepository
    {
        

        public Siunta GetSiunta(string id)
        {

            Siunta siunta = new Siunta();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from " + Globals.dbPrefix + "siunta where siuntos_kodas=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                siunta.id = Convert.ToInt32(item["id"]);
                siunta.siuntos_busena = Convert.ToString(item["siuntos_busena"]);
                siunta.siuntos_svoris = Convert.ToDouble(item["siuntos_svoris"]);
                siunta.siuntejo_adresas = Convert.ToString(item["siuntejo_adresas"]);
                siunta.gavejo_adresas = Convert.ToString(item["gavejo_adresas"]);
                siunta.gavejo_el_pastas = Convert.ToString(item["gavejo_el_pastas"]);
                siunta.gavejo_numeris = Convert.ToString(item["gavejo_numeris"]);
                siunta.uzsakymo_kodas = Convert.ToString(item["uzsakymo_kodas"]);
            }

            return siunta;
        }

        public bool addSiunta(Siunta siunta, string uniqCode)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "siunta(siuntos_busena,siuntos_svoris,siuntejo_adresas," +
                    "gavejo_adresas,gavejo_el_pastas,gavejo_numeris,siuntos_kodas)VALUES(?siuntos_busena,?siuntos_svoris,?siuntejo_adresas,?gavejo_adresas,?gavejo_el_pastas,?gavejo_numeris,?siuntos_kodas)";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?siuntos_busena", MySqlDbType.VarChar).Value = "Sukurta";
                mySqlCommand.Parameters.Add("?siuntos_svoris", MySqlDbType.Float).Value = siunta.siuntos_svoris;
                mySqlCommand.Parameters.Add("?siuntejo_adresas", MySqlDbType.VarChar).Value = siunta.siuntejo_adresas;
                mySqlCommand.Parameters.Add("?gavejo_adresas", MySqlDbType.VarChar).Value = siunta.gavejo_adresas;
                mySqlCommand.Parameters.Add("?gavejo_el_pastas", MySqlDbType.VarChar).Value = siunta.gavejo_el_pastas;
                mySqlCommand.Parameters.Add("?gavejo_numeris", MySqlDbType.VarChar).Value = siunta.gavejo_numeris;
                mySqlCommand.Parameters.Add("?siuntos_kodas", MySqlDbType.VarChar).Value = uniqCode;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public bool atsiimtiSiunta(string siunta)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `siunta` SET `siuntos_busena`=?busena WHERE `siuntos_kodas`='"+ siunta + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.VarChar).Value = "Prsitatyta";
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public bool ChangeBusena(string kodas, string busena)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `siunta` SET `siuntos_busena`=?busena WHERE `siuntos_kodas`='" + kodas + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.VarChar).Value = busena;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public List<Siunta> Select()
        {
            List<Siunta> siuntos = new List<Siunta>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `siunta`";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                siuntos.Add(new Siunta
                {
                    id = Convert.ToInt32(item["id"]),
                    siuntos_busena = Convert.ToString(item["siuntos_busena"]),
                    siuntos_svoris = Convert.ToDouble(item["siuntos_svoris"]),
                    siuntejo_adresas = Convert.ToString(item["siuntejo_adresas"]),
                    gavejo_adresas = Convert.ToString(item["gavejo_adresas"]),
                    gavejo_el_pastas = Convert.ToString(item["gavejo_el_pastas"]),
                    gavejo_numeris = Convert.ToString(item["gavejo_numeris"]),
                    uzsakymo_kodas = Convert.ToString(item["siuntos_kodas"])
                });

            }
            return siuntos;
        }
    }
}