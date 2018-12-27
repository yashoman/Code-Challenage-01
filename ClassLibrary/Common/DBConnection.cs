using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace ClassLibrary.Common
{
    [Serializable()]
    public class DBConnection
    {
        [NonSerialized]
        public MySqlConnection con;

        //public MySqlConnection con;
        [NonSerialized]
        public MySqlCommand cmd;
        [NonSerialized]
        public MySqlTransaction tr;
        [NonSerialized]
        public MySqlDataReader dr;

        public DBConnection()
        {
            

            string myconstring = "server=localhost;userid=root;password=admin;database=adasa;";
            con = new MySqlConnection();
            con.ConnectionString = myconstring;

            //con = new MySqlConnection(System.Configuration.ConfigurationSettings.AppSettings["dbConString"].ToString());
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            try
            {
                this.con = new MySqlConnection(myconstring);
                this.con.Open();

                this.tr = con.BeginTransaction();
                this.cmd.Transaction = tr;
            }
            catch (Exception ex)
            {
                this.RollBack();
            }
        }

        

        public void Commit()
        {
            tr.Commit();
            this.cmd.Dispose();
            this.con.Close();
        }
        public void RollBack()
        {
            this.tr.Rollback();
            this.cmd.Dispose();
            this.con.Close();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
