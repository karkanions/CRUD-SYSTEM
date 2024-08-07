using ExcelDataReader;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace Bussiness.Helper
{
   public class ExcelValidation
    {
        private Logger logger;
        enum ExcelLocationRead { Main, Wizzard }
        enum ExcelParameters { }
        private System.Data.DataTable ret;



        public DataTable ExcelOpen()
        {
            OpenFileDialog fil = new OpenFileDialog();
            fil.ShowDialog();
            string path = fil.FileName.ToString();
            return ExcelRead(path);
        }

        public DataTable ExcelRead(string path)
        {
            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var conf = new ExcelReaderConfiguration();
            var reader = ExcelReaderFactory.CreateReader(stream);
            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            var tables = result.Tables.Cast<DataTable>();
            return tables.FirstOrDefault();
        }

        //public System.Data.DataTable Excel() 
        //{



        //    return null;
        //}
        //        try
        //    {
        //        //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file
        //        Microsoft.Office.Interop.Excel.Application excelApp =
        //            new Microsoft.Office.Interop.Excel.Application();
        //        Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
        //        Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = (_Worksheet)excelWorkbook.Sheets[1];
        //        Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

        //        ret = ExcelValidation.read(excelRange);

        //        //close and clean excel process
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        Marshal.ReleaseComObject(excelRange);
        //        Marshal.ReleaseComObject(excelWorksheet);
        //        //quit apps
        //        excelWorkbook.Close();
        //        Marshal.ReleaseComObject(excelWorkbook);
        //        Marshal.ReleaseComObject(excelWorkbook);
        //        excelApp.Quit();
        //        Marshal.ReleaseComObject(excelApp);
        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //}
        //public static System.Data.DataTable read(Range excelRange)
        //{
        //    DataRow row;
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    int rowCount = excelRange.Rows.Count; //get row count of excel data

        //    int colCount = excelRange.Columns.Count; // get column count of excel data

        //    //Get the first Column of excel file which is the Column Name

        //    for (int i = 1; i <= rowCount; i++)
        //    {
        //        for (int j = 1; j <= colCount; j++)
        //        {
        //            //dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
        //        }
        //        break;
        //    }

        //    //Get Row Data of Excel

        //    int rowCounter; //This variable is used for row index number
        //    for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
        //    {
        //        row = dt.NewRow(); //assign new row to DataTable
        //        rowCounter = 0;
        //        for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
        //        {
        //            //check if cell is empty
        //            //if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
        //            //{
        //            //    row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
        //            //}
        //            //else
        //            //{
        //            //    row[i] = "";
        //            //}
        //            //rowCounter++;
        //        }
        //        dt.Rows.Add(row); //add row to DataTable
        //    }

        //    return dt;
        //}
        //public bool ExcelValidateAsCampaignInput()
        //{

        //    if (ret.Columns?.Count == 3)
        //    {
        //        if (ret.Columns.Contains("ReferenceId"))
        //        {
        //            return true; 
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else 
        //    {
        //        return false;
        //    }
        //}

    }
}
