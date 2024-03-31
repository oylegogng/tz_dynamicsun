using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;

namespace tz
{
   
    public class UploadWeatherArchiveController : Controller
    {
        private readonly WeatherDbContext _context;

        public UploadWeatherArchiveController(WeatherDbContext context)
        {
            _context = context;
        }

        

        [HttpPost]
        public IActionResult UploadWeatherArchive(IFormFile file)
        {
            
            IWorkbook workbook;

            using (FileStream fileStream = new FileStream("ExcelFiles/moskva_2010.xlsx", FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fileStream);
            }

            ISheet sheet = workbook.GetSheetAt(0);

            return View();
        }
    }

}
