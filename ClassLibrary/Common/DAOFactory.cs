using ClassLibrary.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Common
{
   public class DAOFactory
    {

       public static TblMeteoStationsDAO CreateTblMeteoStationsDAO()
       {
           TblMeteoStationsDAO tblMeteoStationsDAO = new TblMeteoStationsDAOImpl();
           return (TblMeteoStationsDAO)tblMeteoStationsDAO;
       }

       public static TblMeteoVariablesDAO CreateTblMeteoVariablesDAO()
        {
            TblMeteoVariablesDAO tblMeteoVariablesDAO = new TblMeteoVariablesDAOImpl();
            return (TblMeteoVariablesDAO)tblMeteoVariablesDAO;
        }
    }
}
