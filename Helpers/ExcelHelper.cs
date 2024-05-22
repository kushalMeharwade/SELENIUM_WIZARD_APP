using Microsoft.Xaml.Behaviors.Media;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Helpers
{
    public static  class ExcelHelper
    {
        public static DataTable GetDataTable(string path)
        {
            DataTable dt = new DataTable();
            FileInfo fileInformation = new FileInfo(path);
            if(!fileInformation.Exists)
            {
                throw new Exception("FILE NOT FOUND");
            }
            else
            {
                Workbook excel_workbook = new Workbook();
                excel_workbook.LoadFromFile(path);
                Worksheet sheet_1 = excel_workbook.Worksheets[0];
                dt = sheet_1.ExportDataTable();
            }
            return dt;
        }

    }
}
