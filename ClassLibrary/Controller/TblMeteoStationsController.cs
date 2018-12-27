using ClassLibrary.Common;
using ClassLibrary.Domain;
using ClassLibrary.Infrastructure;
using ClassLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Controller
{
    public interface TblMeteoStationsController
    {
        List<MeteoStations> FetchAllStationDataList();
    }

    public class TblMeteoStationsControllerImpl : TblMeteoStationsController
    {
        public List<MeteoStations> FetchAllStationDataList()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TblMeteoStationsDAO tblMeteoStationsDAO = DAOFactory.CreateTblMeteoStationsDAO();
                return tblMeteoStationsDAO.FetchAllStationDataList(dbConnection);
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }
    }

}
