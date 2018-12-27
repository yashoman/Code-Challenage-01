using ClassLibrary.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Common
{
    public class ControllerFactory
    {
        public static TblMeteoStationsController CreateTblMeteoStationsController()
        {
            TblMeteoStationsController tblMeteoStationsControllerImpl = new TblMeteoStationsControllerImpl();
            return (TblMeteoStationsController)tblMeteoStationsControllerImpl;
        }

        public static TblMeteoVariablesController CreateTblMeteoVariablesController()
        {
            TblMeteoVariablesController tblMeteoVariablesController = new TblMeteoVariablesControllerImpl();
            return (TblMeteoVariablesController)tblMeteoVariablesController;
        }
    }
}
