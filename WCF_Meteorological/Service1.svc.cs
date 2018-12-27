using ClassLibrary.Common;
using ClassLibrary.Controller;
using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace WCF_Meteorological
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Response GetAllStations()
        {
            Response responce = new Response();
            TblMeteoStationsController tblMeteoStationsController = ControllerFactory.CreateTblMeteoStationsController();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            try
            {
                List<MeteoStations> MeteoStationsList = tblMeteoStationsController.FetchAllStationDataList();

                int status;
                if (MeteoStationsList.Count != 0)
                {
                    responce.ID = 200;
                    responce.Data = javaScriptSerializer.Serialize(MeteoStationsList);
                }

                else if (MeteoStationsList.Count == 0)
                {
                    responce.ID = 300;
                    responce.Data = "No records found.";
                }
            }
            catch (Exception ex)
            {
                responce.ID = 500;
                responce.Data = ex.Message; //"Something went wrong. Please try again later.";
            }
            return responce;
        }

        public Response GetAllVariables()
        {
            Response responce = new Response();
            TblMeteoVariablesController tblMeteoVariablesController = ControllerFactory.CreateTblMeteoVariablesController();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            try
            {
                List<MeteoVariables> MeteoVariableList = tblMeteoVariablesController.FetchAllVariableDataList();

                int status;
                if (MeteoVariableList.Count != 0)
                {
                    responce.ID = 200;
                    responce.Data = javaScriptSerializer.Serialize(MeteoVariableList);
                }

                else if (MeteoVariableList.Count == 0)
                {
                    responce.ID = 300;
                    responce.Data = "No records found.";
                }
            }
            catch (Exception ex)
            {
                responce.ID = 500;
                responce.Data = ex.Message; //"Something went wrong. Please try again later.";
            }
            return responce;
        }
    }
}
