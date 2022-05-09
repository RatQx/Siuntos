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
    public class RekomenduojamaKnygaRepository
    {       
        public List<RekomenduojamaKnygaViewModel> GetKnyga()
        {
            List<RekomenduojamaKnygaViewModel> knygaViewModels = new List<RekomenduojamaKnygaViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `rekomenduojamaknyga`";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                knygaViewModels.Add(new RekomenduojamaKnygaViewModel
                {
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    autorius = Convert.ToString(item["autorius"]),
                    kaina = Convert.ToDouble(item["kaina"]),
                    ISBN = Convert.ToString(item["ISBN"]),
                    isleidimo_metai = Convert.ToInt32(item["isleidimo_metai"]),
                    puslapiu_skaicius = Convert.ToInt32(item["puslapiu_skaicius"]),
                    leidykla = Convert.ToString(item["leidykla"]),
                    kiekis = Convert.ToInt32(item["kiekis"]),
                    //      iskeliama_saraso_pradzia = Convert.ToInt32(item["iskeliama_saraso_pradzia"]),
                    kalba = Convert.ToString(item["kalba"]),
                    zanras = Convert.ToString(item["zanras"])
                });
            }

            return knygaViewModels;
        }

        //tas pats kaip getknyga() tik biski pakeista kad nevisas paima
        //kai mergins reiks pakeist si bei ta
        //cia parametrai tai data nuo iki data iki. Paima ir parodo visas parduotas knygas pagal laikus
        public List<ParduotaKnygaViewModel> GetSold(string zanras, DateTime from, DateTime to)
        {
            List<ParduotaKnygaViewModel> knygaViewModels = new List<ParduotaKnygaViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `parduotaknyga` WHERE zanras = '" + zanras + "' AND data >= '" + from + "' AND data <= '" + to + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                knygaViewModels.Add(new ParduotaKnygaViewModel
                {
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    autorius = Convert.ToString(item["autorius"]),
                    kaina = Convert.ToDouble(item["kaina"]),
                    ISBN = Convert.ToString(item["ISBN"]),
                    isleidimo_metai = Convert.ToInt32(item["isleidimo_metai"]),
                    puslapiu_skaicius = Convert.ToInt32(item["puslapiu_skaicius"]),
                    leidykla = Convert.ToString(item["leidykla"]),
                    kiekis = Convert.ToInt32(item["kiekis"]),
                    //      iskeliama_saraso_pradzia = Convert.ToInt32(item["iskeliama_saraso_pradzia"]),
                    kalba = Convert.ToString(item["kalba"]),
                    zanras = Convert.ToString(item["zanras"])
                });
            }

            return knygaViewModels;
        }
        public void AddSold(string zanras, DateTime from, DateTime to)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `parduotuataskaita` SELECT * FROM `parduotaknyga` WHERE zanras = '" + zanras + "' AND data >= '" + from + "' AND data <= '" + to + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }


        public RekomenduojamaKnygaEditViewModel GetKnyga(string id)
        {
            RekomenduojamaKnygaEditViewModel knyga = new RekomenduojamaKnygaEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `rekomenduojamaknyga` WHERE ISBN='" + id + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                knyga.pavadinimas = Convert.ToString(item["pavadinimas"]);
                knyga.autorius = Convert.ToString(item["autorius"]);
                knyga.kaina = Convert.ToDouble(item["kaina"]);
                knyga.ISBN = Convert.ToString(item["ISBN"]);
                knyga.isleidimo_metai = Convert.ToInt32(item["isleidimo_metai"]);
                knyga.puslapiu_skaicius = Convert.ToInt32(item["puslapiu_skaicius"]);
                knyga.leidykla = Convert.ToString(item["leidykla"]);
                knyga.kiekis = Convert.ToInt32(item["kiekis"]);
                //knyga.iskeliama_saraso_pradzia = Convert.ToInt32(item["iskeliama_saraso_pradzia"]);
                knyga.kalba = Convert.ToString(item["kalba"]);
                knyga.zanras = Convert.ToString(item["zanras"]);
            }

            return knyga;
        }

        public void deleteKnyga(string id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM `rekomenduojamaknyga` WHERE `ISBN`='" + id + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("`ISBN`", id);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        public void AddKnyga(string id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `rekomenduojamaknyga` SELECT* FROM `knyga` WHERE `ISBN`='" + id + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("`ISBN`", id);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        //prideda knygas i atvaizduojamas
        public void AddKnygos()
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `atvaizduojama knyga` SELECT* FROM `rekomenduojamaknyga`";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);            
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        //istrina knygas is atvaizduojamu
        public void DeleteKnygos()
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM `atvaizduojama knyga`";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}