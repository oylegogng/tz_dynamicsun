using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tz.Models;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using tz.Models;

namespace tz.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly WeatherDbContext _context;

        public HomeController(WeatherDbContext context)
        {
            _context = context;
        }

        private void FromXSLSXtoBD(string filepath)
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(fileStream);

                foreach (ISheet sheet in workbook)
                {
                    for (int i = (sheet.FirstRowNum + 4); i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null || row.GetCell(0) == null)
                        {
                            break;
                        }

                        WeatherData weatherData = new WeatherData();

                        weatherData.Date = DateTime.TryParse(row.GetCell(0).ToString(), out DateTime date) ? date : DateTime.MinValue;
                        weatherData.MoscowTime = TimeSpan.TryParse(row.GetCell(1).ToString(), out TimeSpan time) ? time : TimeSpan.MinValue;
                        weatherData.Temperature = double.TryParse(row.GetCell(2).ToString(), out double temp) ? temp : 0;
                        weatherData.Humidity = int.TryParse(row.GetCell(3).ToString(), out int humidity) ? humidity : 0;
                        weatherData.DewPoint = double.TryParse(row.GetCell(4).ToString(), out double dewPoint) ? dewPoint : 0;
                        weatherData.Pressure = int.TryParse(row.GetCell(5).ToString(), out int pressure) ? pressure : 0;
                        weatherData.WindDirection = row.GetCell(6)?.ToString() ?? "none";
                        weatherData.WindSpeed = int.TryParse(row.GetCell(7).ToString(), out int windSpeed) ? windSpeed : 0;
                        weatherData.Cloudiness = int.TryParse(row.GetCell(8).ToString(), out int cloudiness) ? cloudiness : 0;
                        weatherData.H = int.TryParse(row.GetCell(9).ToString(), out int h) ? h : 0;
                        weatherData.VV = int.TryParse(row.GetCell(10).ToString(), out int vv) ? vv : 0;
                        weatherData.WeatherPhenomena = row.GetCell(11)?.ToString() ?? "none";

                        _context.WeatherData.Add(weatherData);
                    }
                }

                _context.SaveChanges();
            }
        }

        public IActionResult Button_Moscow_2010_Clicked()
        {
            FromXSLSXtoBD("Controllers/ExcelFiles/moskva_2010.xlsx");
            return RedirectToAction("UploadWeatherArchive");
        }

        public IActionResult Button_Moscow_2011_Clicked()
        {
            FromXSLSXtoBD("Controllers/ExcelFiles/moskva_2011.xlsx");
            return RedirectToAction("UploadWeatherArchive");
        }

        public IActionResult Button_Moscow_2012_Clicked()
        {

            FromXSLSXtoBD("Controllers/ExcelFiles/moskva_2012.xlsx");
            return RedirectToAction("UploadWeatherArchive");
        }

        public IActionResult Button_Moscow_2013_Clicked()
        {
            FromXSLSXtoBD("Controllers/ExcelFiles/moskva_2013.xlsx");
            return RedirectToAction("UploadWeatherArchive");
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult WeatherArchive(int? year, int? month)
        {
            IQueryable<WeatherData> weatherDataQuery = _context.WeatherData;

            if (year != null)
            {
                weatherDataQuery = weatherDataQuery.Where(w => w.Date.Year == year);
            }

            if (month != null)
            {
                weatherDataQuery = weatherDataQuery.Where(w => w.Date.Month == month);
            }

            var weatherData = weatherDataQuery.ToList();

            // Сохраняем выбранные значения месяца и года в ViewBag для отображения на странице
            ViewBag.SelectedYear = year;
            ViewBag.SelectedMonth = month;

            return View(weatherData);
        }

        public IActionResult UploadWeatherArchive()
        {
            
            return View();
        }
    }

}
