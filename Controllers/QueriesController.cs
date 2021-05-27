using Databaze_lab_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databaze_lab_2.Controllers
{
    public class QueriesController : Controller
    {
        private const string CONNECTION_STRING = "Server=DESKTOP-G7C8QEC;Database=TourBase;Trusted_Connection=True;MultipleActiveResultSets=true";
        private const string ERR = "Немає результатів для даного запиту";
        private const string DEFAULT_PATH = @"F:\C#\Databaze_lab_2\Queries\";
        private readonly TourBaseContext _context;

        public QueriesController(TourBaseContext context)
        {
            _context = context;
        }
        public IActionResult Index(int errorCode)
        {
            ViewBag.TouristsList = new SelectList(_context.Tourists, "TouristName", "TouristName");
            ViewBag.CountriesList = new SelectList(_context.Countries, "CountryName", "CountryName");
            ViewBag.ToursList = new SelectList(_context.Tours, "TourName", "TourName");
            ViewBag.TransportsList = new SelectList(_context.Transports, "TransportName", "TransportName");
            ViewBag.HotelsList = new SelectList(_context.Hotels, "HotelName", "HotelName");
            if (errorCode == 1) ViewBag.Error1 = "Недопустиме значення";
            if (errorCode == 2) ViewBag.Error2 = "Недопустиме значення";
            if (errorCode == 3) ViewBag.Error3 = "Недопустиме значення";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQuery1(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "SQLQuery1.sql");
            query = query.Replace("TouristName", "N\'" + queryModel.TouristName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S1";
            queryModel.ToursNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.ToursNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult SimpleQuery2(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "SQLQuery2.sql");
            query = query.Replace("CountryName", "N\'" + queryModel.CountryName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S2";
            queryModel.HotelsNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.HotelsNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult SimpleQuery3(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "SQLQuery3.sql");
            query = query.Replace("TransportName", "N\'" + queryModel.TransportName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S3";
            queryModel.ToursNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.ToursNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult SimpleQuery4(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "SQLQuery4.sql");
            query = query.Replace("HotelName", "N\'" + queryModel.HotelName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S4";
            queryModel.ToursNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.ToursNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult DifficultSimpleQuery1(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "DIFSQLQuery1.sql");
            query = query.Replace("TouristName", "N\'" + queryModel.TouristName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "D1";
            queryModel.TouristsNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.TouristsNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult DifficultSimpleQuery2(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "DIFSQLQuery2.sql");
            query = query.Replace("CountryName", "N\'" + queryModel.CountryName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "D2";
            queryModel.CountriesNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.CountriesNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult DifficultSimpleQuery3(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "DIFSQLQuery3.sql");
            query = query.Replace("TourName", "N\'" + queryModel.TourName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "D3";
            queryModel.TransportsNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.TransportsNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult DifficultSimpleQuery4(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "DIFSQLQuery4.sql");

            queryModel.QueryId = "D4";
            queryModel.ToursNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.ToursNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult MasterSimpleQuery1(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "MASTERSQLQuery1.sql");
            query = query.Replace("TouristName", "N\'" + queryModel.TouristName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "M1";
            queryModel.TouristsNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.TouristsNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult MasterSimpleQuery2(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(DEFAULT_PATH + "MASTERSQLQuery2.sql");
            query = query.Replace("Seredne", queryModel.Seredne.ToString());
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "M2";
            queryModel.CountriesNames = new List<string>();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.CountriesNames.Add(reader.GetString(0));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = ERR;
                        }
                    }

                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        public IActionResult Result(Query queryResult)
        {
            return View(queryResult);
        }
    }
}
