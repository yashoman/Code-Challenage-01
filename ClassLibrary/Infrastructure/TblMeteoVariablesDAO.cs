using ClassLibrary.Common;
using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Infrastructure
{
    public interface TblMeteoVariablesDAO
    {
        List<MeteoVariables> FetchAllVariableDataList(DBConnection dbConnection);
    }

    public class TblMeteoVariablesDAOImpl : TblMeteoVariablesDAO
    {
        string libraryName = ConfigurationSettings.AppSettings["libraryName"].ToString();

        public List<MeteoVariables> FetchAllVariableDataList(DBConnection dbConnection)
        {
            try
            {
                dbConnection.cmd.CommandText = "SELECT * FROM " + libraryName + ".tbl_mast_meteo_variables";
                dbConnection.cmd.CommandType = System.Data.CommandType.Text;

                if (dbConnection.cmd.Connection.State != System.Data.ConnectionState.Open)
                {
                    dbConnection.cmd.Connection.Open();

                }
                using (dbConnection.dr = dbConnection.cmd.ExecuteReader())
                {
                    DataAccessObject dataAccessObject = new DataAccessObject();
                    return dataAccessObject.ReadCollection<MeteoVariables>(dbConnection.dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
