using Bussinesss.Excel;
using Bussinesss.Helper;
using ExcelDataReader;
using Microsoft.Win32;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using DataTable = System.Data.DataTable;

namespace Bussiness.Excel
{
    public class ExcelValidation
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public Bussiness.Parameters.TablesDto tablesDto;
        public ExcelReadResponse ExcelOpen(Bussiness.Parameters.TablesDto tablesDto, List<ExcelParameters> validates)
        {
            this.tablesDto = tablesDto;
            OpenFileDialog fil = new OpenFileDialog();
            fil.ShowDialog();
            string path = fil.FileName.ToString();
            return ExcelRead(path, validates);
        }
        public ExcelReadResponse ExcelRead(string path, List<ExcelParameters> validates)
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
            ExcelReadResponse ret = new ExcelReadResponse
            {
                dataTable = tables.FirstOrDefault()
            };
            ret.isValid = ValidateDataTable(ret.dataTable, validates);
            return ret;
        }
        private bool ValidateDataTable(DataTable dt, List<ExcelParameters> validates)
        {
            foreach (ExcelParameters v in validates)
            {
                switch (v.ValidateMethod)
                {
                    case ExcelEnu.ColumnNumber:
                        {
                            if (!ValidateColumnCount(dt, (int)v.Parameter))
                            {
                                return false;
                            }
                            break;
                        }
                    case ExcelEnu.ColumnNameFromList:
                        {
                            if (!ValidateColumnNameFromList(dt, (List<string>)v.Parameter))
                            {
                                return false;
                            }
                            break;
                        }
                    case ExcelEnu.NotEmpty:
                        {
                            if (!ValidateNotEmptyColumns(dt, (int)v.Parameter))
                            {
                                return false;
                            }
                            break;
                        }
                    case ExcelEnu.SameDataType:
                        {
                            if (!DataValidation(dt, (List<System.Tuple<string, Type>>)v.Parameter))
                            {
                                return false;
                            }
                            break;
                        }
                    default:
                        return false;
                }
            }
            return true;
        }
        private bool ValidateColumnNameFromList(DataTable dt, List<string> columnNames)
        {
            List<string> dtColumns = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            if (dtColumns.All(x => columnNames.Contains(x)))
            {
                return true;
            }
            else
            {
                MessageBox.Show("edw na bei text");
                return false;
            }
        }
        private bool ValidateColumnCount(DataTable dt, int columnCount)
        {
            columnCount = dt.Columns.Count;
            if (columnCount == 0)
            {
                MessageBox.Show("edw na bei text");
                return false;
            }
            else
            { return true; }
        }
        private bool ValidateNotEmptyColumns(DataTable dt, int rowCount)
        {
            rowCount = dt.Rows.Count;
            if (rowCount > 0)
            { return true; }
            else
            {
                MessageBox.Show("edw na bei text");
                return false;
            }
        }
        private bool DataValidation(DataTable dt, List<Tuple<string, Type>> columnNames)
        {
            if (DataTypeFlip(dt) == true)
            { 
                //foreach (Tuple<string, Type> t in columnNames)
                //{
                //    if (t.Item2 != dt.Columns[t.Item1].DataType)
                //    {
                //        MessageBox.Show("edw na bei text");
                //        return false;
                //    }
                //}
                return true;
            }
            return false;
        }
        public bool DataTypeFlip(DataTable dt)
        {
            var data = dt;
            var coNames = data
               .Columns
               .Cast<DataColumn>()
               .Select(x => x.ColumnName)
               .ToArray();
            foreach (DataRow d in data.Rows)
            {
                var item = Activator.CreateInstance(tablesDto.ClassTypeBussiness);
                foreach (var p in item.GetType()
                        .GetProperties(
                         BindingFlags.Public
                       | BindingFlags.Instance))
                {
                    if (coNames.Contains(p.Name))
                    {
                        var val = d[p.Name];
                        if (p.PropertyType != val.GetType())
                        {
                            if (p.PropertyType == typeof(int)) { val = Convert.ToInt32(val); }
                            if (p.PropertyType == typeof(string)) { val = Convert.ToString(val); }
                            if (p.PropertyType == typeof(DateTime)) { val = Convert.ToDateTime(val); }
                            if (p.PropertyType == typeof(double)) { val = d[p.Name]; }
                            if (Nullable.GetUnderlyingType(p.PropertyType) != null)
                            {
                                if (Nullable.GetUnderlyingType(p.PropertyType) == typeof(int)) { val = Convert.ToInt32(val); }
                                if (Nullable.GetUnderlyingType(p.PropertyType) == typeof(string)) { val = Convert.ToString(val); }
                                if (Nullable.GetUnderlyingType(p.PropertyType) == typeof(DateTime)) { val = Convert.ToDateTime(val); }
                                if (Nullable.GetUnderlyingType(p.PropertyType) == typeof(double)) { val = d[p.Name]; }
                            }
                            if (p.PropertyType.IsCastableTo(val.GetType()) != true)
                            {
                                return false;
                            }
                        }          
                    }
                }
            }
            return true;
        }
    }
}
