using DataAccess.Helper;
using DWHEditForms;
using NLog;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DWHEditFormsnew
{
    public partial class ExcelForm : Form
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        public DataTable data;
        public FrmMain main = new FrmMain();
        public Bussiness.Parameters.TablesDto tablesDto;
        public FilterItems filter;
        public FilterItems pageNumber;
        private Bussiness.Settings.BussinessSettings bl;
        public ExcelForm(Bussiness.Parameters.TablesDto tablesDto, Bussiness.Settings.BussinessSettings bl)
        {
            this.tablesDto = tablesDto;
            this.bl = bl;
            InitializeComponent();
        }
        public void PopulateGrid(DataTable data)
        {
            dataGridView1.DataSource = data;
            this.data = data;
        }
        public void SaveData() 
        {
            var columnNames = data
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
                    if (columnNames.Contains(p.Name))
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
                        }
                        else
                        {
                          val = d[p.Name];
                        }
                        p.SetValue(item, val);
                    }
                }
                bl.DisplayList.Add(item);
            }
            bl.SaveListToDb();
        }
        private void ExSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
