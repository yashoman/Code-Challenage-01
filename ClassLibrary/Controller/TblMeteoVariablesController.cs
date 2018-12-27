using ClassLibrary.Common;
using ClassLibrary.Domain;
using ClassLibrary.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Controller
{
    public interface TblMeteoVariablesController
    {
        List<MeteoVariables> FetchAllVariableDataList();
    }

    public class TblMeteoVariablesControllerImpl : TblMeteoVariablesController
    {
        public List<MeteoVariables> FetchAllVariableDataList()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TblMeteoVariablesDAO tblMeteoVariablesDAO = DAOFactory.CreateTblMeteoVariablesDAO();
                return tblMeteoVariablesDAO.FetchAllVariableDataList(dbConnection);
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
