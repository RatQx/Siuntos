using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using AutoNuoma.ViewModels;
using MySql.Data.MySqlClient;
using AutoNuoma.Models;




namespace AutoNuoma.Repos
{
    public class UzsakymasRepository
    { 

        public static string uniqValue { get; set; }
        public static string getValue()
        {
            return uniqValue;
        }

        public bool addUzsakymas(Uzsakymas uzsakymas,string uniqCode)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO " + Globals.dbPrefix + "uzsakymas(uzsakymo_data,uzsakymo_busena,pristatymo_data," +
                "uzsakovas,uzsakymo_kodas,mokejimo_data,kaina)VALUES(?uzsakymo_data,?uzsakymo_busena,?pristatymo_data,?uzsakovas,?uzsakymo_kodas,?mokejimo_data,?kaina)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?uzsakymo_data", MySqlDbType.DateTime).Value = DateTime.Now;
            mySqlCommand.Parameters.Add("?uzsakymo_busena", MySqlDbType.VarChar).Value = "Užregistruotas";
            mySqlCommand.Parameters.Add("?pristatymo_data", MySqlDbType.DateTime).Value = uzsakymas.pristatymo_data;
            mySqlCommand.Parameters.Add("?uzsakovas", MySqlDbType.Int32).Value = uzsakymas.uzsakovas;
            mySqlCommand.Parameters.Add("?uzsakymo_kodas", MySqlDbType.VarChar).Value = uniqCode;
            mySqlCommand.Parameters.Add("?mokejimo_data", MySqlDbType.DateTime).Value = uzsakymas.mokejimo_data;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Float).Value = 3.99;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool updateUzsakymas(Uzsakymas uzsakymas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `" + Globals.dbPrefix + @"uzsakymas` SET
                                    `uzsakymo_busena` = ?uzsakymo_busena,
                                    `mokejimo_data` = ?mokejimo_data
                                    WHERE nr=" + uzsakymas.id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?mokejimo_data", MySqlDbType.DateTime).Value = uzsakymas.mokejimo_data.ToString("yyyy-MM-dd hh:mm:ss");
            mySqlCommand.Parameters.Add("?uzsakymo_busena", MySqlDbType.VarChar).Value = "Apmoketas";
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public Uzsakymas getUzsakymas(string id)
        {
            Uzsakymas uzsakymas = new Uzsakymas();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `uzsakymas` WHERE id  = "+ id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                uzsakymas.id = Convert.ToInt32(item["id"]);
                uzsakymas.uzsakymo_data = Convert.ToDateTime(item["uzsakymo_data"]);
                uzsakymas.uzsakymo_busena = Convert.ToString(item["uzsakymo_busena"]);
                uzsakymas.pristatymo_data = Convert.ToDateTime(item["pristatymo_data"]);
                uzsakymas.uzsakovas = Convert.ToInt32(item["uzsakovas"]);
                uzsakymas.uzsakymo_kodas = Convert.ToInt32(item["uzsakymo_kodas"]);
                uzsakymas.mokejimo_data = Convert.ToDateTime(item["mokejimo_data"]);
                uzsakymas.kaina = Convert.ToDouble(item["kaina"]);
            }

            return uzsakymas;
        }
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