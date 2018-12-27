using ClassLibrary.Common;
using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ClassLibrary.Infrastructure
{
    public interface TblMeteoStationsDAO
    {
        List<MeteoStations> FetchAllStationDataList(DBConnection dbConnection);
    }

    public class TblMeteoStationsDAOImpl : TblMeteoStationsDAO
    {
        string libraryName = ConfigurationSettings.AppSettings["libraryName"].ToString();

        public List<MeteoStations> FetchAllStationDataList(DBConnection dbConnection)
        {
            try
            {
                dbConnection.cmd.CommandText = "SELECT * FROM " + libraryName + ".tbl_mast_meteo_stations";
                dbConnection.cmd.CommandType = System.Data.CommandType.Text;

                if (dbConnection.cmd.Connection.State != System.Data.ConnectionState.Open  )
                {
                    dbConnection.cmd.Connection.Open();

                }
                using (dbConnection.dr = dbConnection.cmd.ExecuteReader())
                {
                    DataAccessObject dataAccessObject = new DataAccessObject();
                    return dataAccessObject.ReadCollection<MeteoStations>(dbConnection.dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
