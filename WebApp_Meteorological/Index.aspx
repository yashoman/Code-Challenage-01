<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApp_Meteorological.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Weather Data Services</title>
    <meta name="description" content="Love appster." />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!--Bootstrap 4-->
    <link href="AppResources/css/nav/bootstrap.css" rel="stylesheet" />
    <link href="AppResources/css/nav/bootstrap.min.css" rel="stylesheet" />
    <link href="AppResources/css/bootstrap.min.css" rel="stylesheet" />
    <%--   <link href="AppResources/css/animate.min.css" rel="stylesheet" />--%>
    <!--icons-->
    <%--   <link href="AppResources/css/ionicons.min.css" rel="stylesheet" />
   <link href="AppResources/css/familyIcon.css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css">
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link href="AppResources/css/bootstrap-datepicker.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap.min.css" />


    <style>
        #tableCols {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            #tableCols td, #tableCols th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #tableCols tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #tableCols tr:hover {
                background-color: #ddd;
            }

            #tableCols th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #4CAF50;
                color: white;
            }

        .toolbar {
            float: left;
        }
    </style>

    <style>
       

        .dataTables_paginate a {
            padding: 6px 9px !important;
            background: #ddd !important;
            border-color: #ddd !important;
        }

        .pagination > li > a, .pagination > li > span {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin-left: -1px;
            line-height: 1.42857143;
            color: #337ab7;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }
    </style>
    <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY"></script>
   

</head>
<body>
    <!--header-->
    <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-primary sticky-navigation" style="top: 0px;">
        <a class="navbar-brand" href="#"><strong>ADASA</strong></a>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item mr-3">
                    <a class="nav-link page-scroll" href="#features">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item mr-3">
                    <a class="nav-link page-scroll" href="#graps">Graphs</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <!--main section-->

        <!--main features-->
        <br />
        <section class="bg-white" id="features" style="color:black">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 col-sm-8 mx-auto text-center wow fadeIn">
                        <h2 class="text-primary">Analyzing Factors for Water</h2>
                        <p class="lead">
                            Environmental Measurements.
                        </p>
                    </div>
                </div>

                <div id="map-canvas" style="width: 100%; height: 400px;" class="row col-md-12">
                </div>



            </div>
        </section>

        <!-- Charts-->
        <section class="badge-dark text-white" id="graps">

            <div class="container">
                <div class="row">
                    <div class="col-md-6 offset-md-3 col-sm-8 offset-sm-2 col-xs-12 text-center wow fadeIn">
                        <h2 class="text-orange">Graphical Representation</h2>
                        <p class="lead">
                            Comparable Data Representation by Stations
                        </p>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="info-box">
                            <div class="info-box-content">
                                <label for="exampleInputEmail1">Stations</label>
                                <asp:DropDownList ID="ddlStations" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                        </div>
                    </div>

                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="info-box">

                            <div class="info-box-content">
                                <label for="exampleInputEmail1">Variable Type</label>
                                <asp:DropDownList ID="ddlVariable" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3 col-sm-6 col-xs-12">
                        <div class="info-box">

                            <div class="info-box-content">
                                <label runat="server" for="exampleInputEmail1">Graph Type</label>
                                <asp:DropDownList ID="ddlGraphs" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="area" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="column" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="bar" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="line" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix visible-sm-block"></div>

                    <div class="col-md-3 col-sm-6 col-xs-12" style="padding-top: 28px;">
                        <div class="info-box">

                            <div class="info-box-content">

                                <asp:Label runat="server" Visible="false" for="exampleInputEmail1">View </asp:Label>
                                <asp:Button ID="btnView" Text="View Data" OnClick="btnView_Click" CssClass="form-control btn-success" runat="server" />
                            </div>

                        </div>

                    </div>

                </div>
           
                <section class="badge-dark text-white">

                    <div class="container">
                        <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
                        <br /><br />
                        <div class=" bg-light text-black-50" style="min-width: 310px; height: 500px; margin: 0 auto">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class=" col-md-8 card-body ">
                                    
                        <div class="col-md-6 offset-md-3 col-sm-8 offset-sm-2 col-xs-12 text-center wow fadeIn">
                                        <h5 class="text-linkedin" id="meteoStation"></h5>


                                        <br />
                                    </div>
                                    <table class="tableCol table-responsive" id="tableCols">
                                        <thead>
                                            <tr>
                                                <th class="thCol" width="10%">Year
                                            <br />
                                                    2018 </th>
                                                <th class="thCol" width="18%">Temperature
                                            <br />
                                                    (ºC)</th>
                                                <th class="thCol" width="18%">Wind
                                            <br />
                                                    (km/h)</th>
                                                <th class="thCol" width="18%">Precipitation
                                            <br />
                                                    (mm)</th>
                                                <th class="thCol" width="18%">Presure
                                            <br />
                                                    (hPa)</th>
                                                <th class="thCol" width="18%">Humidity
                                            <br />
                                                    (%)</th>
                                            </tr>
                                        </thead>
                                        <tbody class="tbodyCol" id="tbodyCol">
                                        </tbody>


                                    </table>
                                    </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </section>

        <!--footer-->


    </form>
    <script src="AppResources/js/scripts.js"></script>

    <script src="AppResources/js/jquery-3.1.1.min.js"></script>
    <script src="AppResources/js/popper.min.js"></script>
    <script src="AppResources/js/bootstrap.min.js"></script>
    <script src="AppResources/js/jquery.easing.min.js"></script>
    <script src="AppResources/js/wow.js"></script>
    <script src="AppResources/js/exporting.js"></script>
    <script src="AppResources/js/highcharts.js"></script>

   

    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap.min.js"></script>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCiODeQ73wJ9oVR6kHG3mwTABet2e4mLc4"></script>



    <script type="text/javascript">

        var DataListGraph = <%= listVaribaleData %>; //variable data by station
        var DataListDates = <%= listDates %>; //datelist
        var allData = <%= jsonArrAllData %>; // variable data for all stations

        var graphType = '<%= grahType %>';
        var variable = '<%= varibaleType %>';
        var stationName = '<%= station %>';

        if (stationName == "All Stations") {
            document.getElementById('meteoStation').innerHTML = "Data Rerpresentation for "+"Meteo 01";
      
        }
        else{
            document.getElementById('meteoStation').innerHTML = "Data Rerpresentation for "+stationName;
      
        }
       

        var allData1; var allData2; var allData3; var allData4;

        //convert station wise string data to numbers
        if (typeof allData !== 'undefined' && allData.length > 0) 
        {
            allData1 = JSON.parse(allData[0]).map(Number);
            allData2 = JSON.parse(allData[1]).map(Number);
            allData3 = JSON.parse(allData[2]).map(Number);
            allData4 = JSON.parse(allData[3]).map(Number);
        }
        
        //Convert string to numbers
        var variableResultList=DataListGraph.map(Number);

        var colors = ['#7CB5EC', '#EBCE58','#90EC7D', '#F7A35B']

        var isAllStations = <%= isAll %>;
        
        //Get variable values from server side
        var temperature = '<%= tempratureForTable %>';
        var wind = '<%= windForTable %>';
        var precipitation = '<%= precipitationForTable %>';
        var presure = '<%= presureForTable %>';
        var humidity = '<%= humidityForTable %>';

        //Create json objects for varibales
        if (temperature!='') {
            temperature = JSON.parse(temperature).map(Number);
            
        }
        if (wind!='') {
            wind = JSON.parse(wind).map(Number);
            
        }
        if (precipitation!='') {
            precipitation = JSON.parse(precipitation).map(Number);
            
        }
        if (presure!='') {
            presure = JSON.parse(presure).map(Number);

        }
        if (humidity!='') {
            humidity = JSON.parse(humidity).map(Number);
        }

        //Load grahs accrodingly
        if (isAllStations == "0")
        {
            GetStationsWiseData();
        }
        else
        {
            GetAllStatinsData();
        }

        //Load table data
        LoadData();

        //Changes for the dataTable pager
        $('#tableCols').DataTable( {
            "dom": '<"toolbar">frtip',
            "pageLength": 5,
            "bInfo" : false
        } );
 
       
        //Get  Stations Wise Data Representation      
        function GetStationsWiseData()
        {
            $('#container').highcharts({
                chart: {
                    type: graphType
                },
                title: {
                    text: 'Data Representation for ' + variable.split(" ")[0]

                },
                subtitle: {
                    text: 'Source: adasa.com 2018'
                },
                xAxis: {
                    categories:DataListDates,
                    crosshair: true,
                       
                   
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: variable
                    }
                },

                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                      '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0,

                    },
                    series: {
                        color: GetStatonColor(stationName)
                    }

                },
                credits: {
                    enabled: false
                },
                series: [{

                    name: stationName,
                    data: variableResultList

                }]
            });

        }
         
        //Get all Stations Data Representation
        function GetAllStatinsData()
        {
           
            $('#container').highcharts({
                chart: {
                    type: graphType,
                    borderColor: '#ff0000',
                    width: null,
                    height: null
                },
                title: {
                    text: 'Data Representation for '+ variable.split(" ")[0]
                },
                subtitle: {
                    text: 'Source: adasa.com 2018'
                },
                xAxis: {
                    categories:DataListDates,
                    crosshair: true,
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: variable
                    }
                },
                tooltip: {
                    shared: true,
                    crosshairs: true
                },
                exporting: {
                    buttons: {
                        contextButton: {
                            theme: {
                                zIndex: 100   
                            }
                        }
                    }
                },
                series: [{
                    name: 'Meteo 1',
                    data: allData1,
                    color: colors[0]
                },
                {
                    name: 'Meteo 2',
                    data:allData2,
                    color: colors[1]
                },{
                    name: 'Meteo 3',
                    data:allData3,
                    color: colors[2]
                },{
                    name: 'Meteo 4',
                    data:allData4,
                    color: colors[3]
                }

                ]
            });
        }

        //Get colors for graphs
        function GetStatonColor(station){
            var color;

            if (station == "Meteo 1" ) {
                color = colors[0];
            }
            else  if (station == "Meteo 2" ) {
                color = colors[1];
            }
            else  if (station == "Meteo 3" ) {
                color = colors[2];
            }
            else  if (station == "Meteo 4" ) {
                color = colors[3];
            }

            return color;
        }
       
        //Load data for the html data table
        function LoadData()
        {
            var text = "";

            var field0 = "";
            var field1 = "";
            var field2 = "";
            var field3 = "";
            var field4 = "";
            var field5 = "";
                
            for (var i = 1; i <= DataListDates.length-1; i++) {
                field0 = DataListDates[i]; 
                field1 = temperature[i];
                field2 = wind[i];
                field3 = precipitation[i];
                field4 = presure[i];
                field5 = humidity[i];
                var htmlcode =
            ' <tr> ' +
      
            ' <td class=tdCol>' + field0 + '</td> ' +
            ' <td class=tdCol>' + field1 + '</td> ' +
            ' <td class=tdCol>' + field2 + '</td> ' +
            ' <td class=tdCol>' + field3 + '</td> ' +
            ' <td class=tdCol>' + field4 + '</td> ' +
            ' <td class=tdCol>' + field5 + '</td> ' +
            ' </tr> ' + ''
                text += htmlcode;
            }
            document.getElementById("tbodyCol").innerHTML = text;
        }


    </script>

    <script>
   
        var map;

        // The JSON data
        var json = [{"id":48,"title":"Meteo 1","longitude":"41.646749","latitude":"-0.586661"},
            {"id":46,"title":"Meteo 2","longitude":"40.168905","latitude":"-2.826892"},
            {"id":44,"title":"Meteo 3","longitude":"41.794352","latitude":"-6.34098"},
            {"id":43,"title":"Meteo 4","longitude":"41.974296","latitude":"2.026942"}];



        function initialize() {
  
            var mapOptions = {
                zoom: 4,
                center: new google.maps.LatLng(2.026942 , 41.974296)
            };
  
            // Creating the map
            map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
  
  
            // Looping through all the entries from the JSON data
            for(var i = 0; i < json.length; i++) {
    
                
                var obj = json[i];

                 var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(obj.latitude,obj.longitude),
                    map: map,
                    title: obj.title 
                });
    
                 var clicker = addClicker(marker, obj.title);
    
            } 
  
            function addClicker(marker, content) {
                google.maps.event.addListener(marker, 'click', function() {
      
                    if (infowindow) {infowindow.close();}
                    infowindow = new google.maps.InfoWindow({content: content});
                    infowindow.open(map, marker);
      
                });
            }
        }

        // Initialize the map
        google.maps.event.addDomListener(window, 'load', initialize); 
    </script>


</body>
</html>
