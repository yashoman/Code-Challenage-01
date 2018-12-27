using ClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.Common;
using WCF_Meteorological;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;

namespace WebApp_Meteorological
{
    public partial class Index : System.Web.UI.Page
    {
        public string listVaribaleData;
        public string listDates;
        public string isAll;
        public string jsonArrAllData;
        public string grahType;
        public string varibaleType;
        public string station;

        public string tempratureForTable;
        public string windForTable;
        public string precipitationForTable;
        public string presureForTable;
        public string humidityForTable;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Initialize data for page load

                LoadStationDDL();
                LoadVariableDDL();
                getJsonVariableData(1, 1);
                getJsonDates(1, 1);
                isAll = "0";
                jsonArrAllData = "0";
                station = "Meteo 1";
                varibaleType = "Temperature";
                grahType = "area";
                
                tempratureForTable = getJsonVariableData(1, 1);
                windForTable = getJsonVariableData(1, 2);
                precipitationForTable = getJsonVariableData(1, 3);
                presureForTable = getJsonVariableData(1, 4);
                humidityForTable = getJsonVariableData(1, 5);
            }
        }

        /// <summary>
        /// Load stations from database
        /// </summary>
        /// <returns></returns>
        public List<MeteoStations> LoadStationDDL()
        {
            try
            {

                string baseURL = ConfigurationSettings.AppSettings["WebServiceURL"].ToString() + "GetAllStations";
                string url = string.Format(baseURL);
                List<MeteoStations> listMeteoStations = new List<MeteoStations>();
                MeteoStations allStations = new MeteoStations();

                try
                {
                    WebRequest request = WebRequest.Create(url);
                    WebResponse ws = request.GetResponse();

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    Response response = (Response)jsonSerializer.ReadObject(ws.GetResponseStream());

                    if (response.ID == 200)
                    {
                        allStations.Id = 0;
                        allStations.Name = "All Stations";
                        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                        listMeteoStations = javaScriptSerializer.Deserialize<List<MeteoStations>>(response.Data);
                        listMeteoStations.Add(allStations);

                        if (listMeteoStations.Count != 0)
                        {
                            ddlStations.DataSource = listMeteoStations;
                            ddlStations.Items.Add("All");
                            ddlStations.DataTextField = "Name";
                            ddlStations.DataValueField = "Id";
                            ddlStations.DataBind();

                           
                        }

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return listMeteoStations;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Load variables from database
        /// </summary>
        /// <returns></returns>
        public List<MeteoVariables> LoadVariableDDL()
        {
            try
            {
                string baseURL = ConfigurationSettings.AppSettings["WebServiceURL"].ToString() + "GetAllVariables";
                string url = string.Format(baseURL);
                List<MeteoVariables> lisMeteoVariables = new List<MeteoVariables>();
                try
                {
                    WebRequest request = WebRequest.Create(url);
                    WebResponse ws = request.GetResponse();

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    Response response = (Response)jsonSerializer.ReadObject(ws.GetResponseStream());

                    if (response.ID == 200)
                    {
                        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                        lisMeteoVariables = javaScriptSerializer.Deserialize<List<MeteoVariables>>(response.Data);

                        if (lisMeteoVariables.Count != 0)
                        {
                            ddlVariable.DataSource = lisMeteoVariables;
                            ddlVariable.DataTextField = "Name";
                            ddlVariable.DataValueField = "Id";
                            ddlVariable.DataBind();

                        }

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return lisMeteoVariables;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get data from service
        /// </summary>
        /// <returns></returns>
        public List<AllDataSet> GetAllDataFromService()
        {
            try
            {
                WebRequest request = WebRequest.Create("https://demo4062187.mockable.io/meteo");
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                List<AllDataSet> lisMeteoVariables = new List<AllDataSet>();
                try
                {

                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    return javaScriptSerializer.Deserialize<List<AllDataSet>>(responseFromServer);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get variable list by stations
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="variableId"></param>
        /// <returns></returns>
        public List<string> GetVaribleValuesById(int stationId, int variableId)
        {
            var listStationData = GetAllDataFromService().FindAll(x => x.idStation == stationId).ToList();
            var list = listStationData.Select(v => v.variables.Find(c => c.id == variableId).value).ToList();


            return list;
        }

        /// <summary>
        /// Get date list for data representation
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="variableId"></param>
        /// <returns></returns>
        public List<string> GetDateRange(int stationId, int variableId)
        {
            var listStationData = GetAllDataFromService().FindAll(x => x.idStation == stationId).ToList().Select(c => c.date.Substring(0, c.date.Length - 5)).ToList();
            return listStationData;
        }

        /// <summary>
        /// Create json variables string for clientside
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="variableId"></param>
        /// <returns></returns>
        public string getJsonVariableData(int stationId, int variableId)
        {
            var DataList = GetVaribleValuesById(stationId, variableId);
            listVaribaleData = (new JavaScriptSerializer()).Serialize(DataList);

            return listVaribaleData;
        }

        /// <summary>
        ///  Create json date string for clientside
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="variableId"></param>
        public void getJsonDates(int stationId, int variableId)
        {
            var DataList = GetDateRange(stationId, variableId);
            listDates = (new JavaScriptSerializer()).Serialize(DataList);

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            var stationId = int.Parse(ddlStations.SelectedItem.Value);
            var variableId = int.Parse(ddlVariable.SelectedItem.Value);
            string[] allDataSet = new string[4];

            varibaleType = (ddlVariable.SelectedItem.Value == "1") ? ddlVariable.SelectedItem.Text + " ºC" : (ddlVariable.SelectedItem.Value == "2") ? ddlVariable.SelectedItem.Text + " km/h" : (ddlVariable.SelectedItem.Value == "3") ? ddlVariable.SelectedItem.Text + " mm" : (ddlVariable.SelectedItem.Value == "4") ? ddlVariable.SelectedItem.Text + " hPa" : ddlVariable.SelectedItem.Text + " %";
           
            station = ddlStations.SelectedItem.Text;
            grahType = ddlGraphs.SelectedItem.Text;
           

            if (stationId == 0)
            {
                isAll = "1";

                allDataSet[0] = getJsonVariableData(1, variableId);
                allDataSet[1] = getJsonVariableData(2, variableId);
                allDataSet[2] = getJsonVariableData(3, variableId);
                allDataSet[3] = getJsonVariableData(4, variableId);

                jsonArrAllData = (new JavaScriptSerializer()).Serialize(allDataSet);
                getJsonDates(1, variableId);

                tempratureForTable = getJsonVariableData(1, 1);
                windForTable = getJsonVariableData(1, 2);
                precipitationForTable = getJsonVariableData(1, 3);
                presureForTable = getJsonVariableData(1, 4);
                humidityForTable = getJsonVariableData(1, 5);
            }
            else
            {
                isAll = "0";
                getJsonVariableData(stationId, variableId);
                getJsonDates(stationId, variableId);
                jsonArrAllData = "0";

                tempratureForTable = getJsonVariableData(stationId, 1);
                windForTable = getJsonVariableData(stationId, 2);
                precipitationForTable = getJsonVariableData(stationId, 3);
                presureForTable = getJsonVariableData(stationId, 4);
                humidityForTable = getJsonVariableData(stationId, 5);
            }


        }

      
    }


    public class AllDataSet
    {
        public int idStation { get; set; }
        public string date { get; set; }
        public List<Variables> variables { get; set; }
    }

    public class Variables
    {
        public int id { get; set; }
        public string value { get; set; }
    }
}