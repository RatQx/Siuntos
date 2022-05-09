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
    public class NaudotojasRepository
    {
        public List<Naudotojas> getNaudotojai()
        {
            List<Naudotojas> naudotojai = new List<Naudotojas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from `naudotojas`";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                naudotojai.Add(new Naudotojas
                {
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    el_pastas = Convert.ToString(item["el_pastas"]),
                    telefono_numeris = Convert.ToInt32(item["telefono_numeris"]),
                    gyvenamosios_vietos_adresas = Convert.ToString(item["gyvenamosios_vietos_adresas"]),
                    gimimo_data = Convert.ToDateTime(item["gimimo_data"]),
                    prisijungimo_vardas = Convert.ToString(item["prisijungimo_vardas"]),
                    slaptazodis = Convert.ToString(item["slaptazodis"]),
                    lytis = Convert.ToInt32(item["lytis"]),
                    role = Convert.ToInt32(item["role"])
                });
            }

            return naudotojai;
        }
        public bool addNaudotojas(Naudotojas naudotojas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO " + "naudotojas(vardas,pavarde,el_pastas,telefono_numeris,gyvenamosios_vietos_adresas," +
                    "gimimo_data,prisijungimo_vardas,slaptazodis,lytis,role)VALUES(?v,?p,?el,?tel,?gva,?gt,?pv,?sl,?l,?r);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?v", MySqlDbType.VarChar).Value = naudotojas.vardas;
                mySqlCommand.Parameters.Add("?p", MySqlDbType.VarChar).Value = naudotojas.pavarde;
                mySqlCommand.Parameters.Add("?el", MySqlDbType.VarChar).Value = naudotojas.el_pastas;
                mySqlCommand.Parameters.Add("?tel", MySqlDbType.Int32).Value = naudotojas.telefono_numeris;
                mySqlCommand.Parameters.Add("?gva", MySqlDbType.VarChar).Value = naudotojas.gyvenamosios_vietos_adresas;
                mySqlCommand.Parameters.Add("?gt", MySqlDbType.Date).Value = naudotojas.gimimo_data;
                mySqlCommand.Parameters.Add("?pv", MySqlDbType.VarChar).Value = naudotojas.prisijungimo_vardas;
                mySqlCommand.Parameters.Add("?sl", MySqlDbType.VarChar).Value = naudotojas.slaptazodis;
                mySqlCommand.Parameters.Add("?l", MySqlDbType.Int32).Value = naudotojas.lytis;
                mySqlCommand.Parameters.Add("?r", MySqlDbType.Int32).Value = naudotojas.role;
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


    }
}