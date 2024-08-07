using Bussiness.Helper;
using Bussiness.Parameters;
using Bussinesss.Excel;
using DataAccess.Helper;
using DWHEditFormsnew;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DWHEditForms
{
    public partial class FrmMain : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public IList<TablesDto> listOfTables;
        public Bussiness.Excel.ExcelValidation ex;
        private Bussiness.Settings.BussinessSettings bl;
        public List<ColumnAccess> ColumnAccesseList = new List<ColumnAccess>();
        private bool hasChanges = false;
        public FilterItems filter = null;
        private Bussiness.Parameters.TablesDto SelectedClass;

        public FrmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var ll = new Bussiness.ParametersInputs(Settings.Settings.logger);
            listOfTables = ll.GetListOfTablesInputs();
            TableList.DataSource = listOfTables;
            toolStrip1.Enabled = false;
            ExcelImport.Enabled = false;
            Search_btn.Enabled = false;
            ButtonAdd.Enabled = false;
            ButtonSave.Enabled = false;
            SelectedClass = (TablesDto)TableList.SelectedItem;
        }
        private void DataBind_Click(object sender, EventArgs e)
        {
            SelectedClass = (TablesDto)TableList.SelectedItem;
            DoFilter(filter);
            ExcelImport.Enabled = true;
            Search_btn.Enabled = true;
            ButtonAdd.Enabled = true;
            ButtonSave.Enabled = true;
        }
        public void DoFilter(FilterItems filter)
        {
            SelectedClass = (TablesDto)TableList.SelectedItem;
            this.filter = filter;
            dataGridShow.DataSource = null;
            dataGridShow.Columns.Clear();
            PageValidation(SelectedClass);
            NextButton.Enabled = true;
            PreviousButton.Enabled = false;
        }
        private void ReBoundListToGrid()
        {
            this.ColumnAccesseList.Clear();
            try
            {
                //if (SelectedClass == null)
                //{
                //    SelectedClass = (Bussiness.Parameters.TablesDto)TableList.SelectedItem;
                //}
                SelectedClass = (TablesDto)TableList.SelectedItem;
                dataGridShow.DataSource = null;
                dataGridShow.Columns.Clear();
                dataGridShow.DataSource = bl.DisplayList;
                List<DataGridViewColumn> dgvC = dataGridShow.Columns.CloneDataGridColumns();
                foreach (DataGridViewColumn c in dgvC)
                {
                    var i = SelectedClass.TableColumns.FindLast(x => x.Name == c.Name);
                    var cNew = dataGridShow.Columns[c.Name];
                    var columnAccess = new Bussiness.Helper.ColumnAccess
                    {
                        Name = cNew.Name,
                        Caption = cNew.HeaderText
                    };
                    if (i != null)
                    {
                        columnAccess.DataList = ApplySettingsToColumn(cNew, i, filter);
                        columnAccess.ComboDisplayMember = i.ComboDisplayMember;
                        columnAccess.ComboValueMember = i.ComboValueMember;
                        columnAccess.Type = SearchTypesMapping.GetSearchTypesMappingFromType(cNew.ValueType, i.isCombo);
                        columnAccess.Visible = i.Visible;
                    }
                    else
                    {
                        columnAccess.Type = SearchTypesMapping.GetSearchTypesMappingFromType(cNew.ValueType);
                        columnAccess.Visible = true;
                    }
                    ColumnAccesseList.Add(columnAccess);
                }
                hasChanges = false;
            }
            catch (Exception exc)
            {
                hasChanges = false;
                logger.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, exc);
                Console.ReadLine();
            }
        }
        private List<object> ApplySettingsToColumn(DataGridViewColumn c, Bussiness.Parameters.ColumnsDto i, FilterItems filter)
        {
            try
            {
                if (i.isCombo)
                {
                    DataGridViewComboBoxCell bc = new DataGridViewComboBoxCell();
                    //to thelw gia na mhn zhtaw apo thn vash an exei combobox
                    List<object> DataSourceList = bl.GetComBoxList(i, filter);
                    bc.DataSource = DataSourceList;
                    bc.DisplayMember = i.ComboDisplayMember;
                    bc.ValueMember = i.ComboValueMember;

                    DataGridViewColumn newC = new DataGridViewColumn(bc)
                    {
                        //c.Index
                        DisplayIndex = c.Index
                    };
                    c.Visible = false;
                    //c = newC;
                    dataGridShow.Columns.Add(newC);

                    foreach (DataGridViewRow item in dataGridShow.Rows)
                    {
                        item.Cells[newC.Index].Value = item.Cells[c.Index].Value;
                    }
                    ApplySpecificPropertiesToColumn(i, newC);
                    return DataSourceList;
                }
                else
                {
                    ApplySpecificPropertiesToColumn(i, c);
                    return null;
                }

            }
            catch (Exception exc)
            {
                logger.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, exc);
                Console.ReadLine();
            }
            return null;
        }
        private static void ApplySpecificPropertiesToColumn(Bussiness.Parameters.ColumnsDto i, DataGridViewColumn c)
        {
            c.Visible = i.Visible;
            c.HeaderText = i.Header;
            c.Frozen = i.Freeze;
            c.ReadOnly = i.ReadOnly;

        }
        public void PageValidation(TablesDto SelectedClass)
        {
            this.SelectedClass = SelectedClass;
            int pageNumber = 1;
            bl = new Bussiness.Settings.BussinessSettings(logger, SelectedClass, this.filter, pageNumber);
            if (DataAccess.Helper.PaginatedStatus.paginatedStatus.usePagination == true)
            {
                pageNumber = 1;
                OfLabel.Text = "Of";
                OfCounter.Text = bl.GetNunmberOfPages().ToString();
                toolStrip1.Enabled = true;
                ReBoundListToGrid();
            }
            else
            {
                toolStrip1.Enabled = false;
                //counter.Visible = false;
            }
            
            counter.Text = pageNumber.ToString();
            ReBoundListToGrid();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Οι αλλαγες αποθηκευτηκαν");
            bl.SaveListToDb();
            hasChanges = false;
        }
        public void ButtonAdd_Click(object sender, EventArgs e)
        {
            bl.AddRowToList();
            ReBoundListToGrid();

        }
        private void Wizzard_Click(object sender, EventArgs e)
        {
            var f = new Wizzard
            {
                campaignsDto = listOfTables.Where(x => x.Name == "Campaigns").FirstOrDefault(),
                wavesDto = listOfTables.Where(x => x.Name == "CampaignWaves").FirstOrDefault()
            };
            f.Show();
        }
        private void Close_Button_Click(object sender, EventArgs e)
        {
            if (UnsavedChecker() == true)
            {
                MessageBox.Show("Υπαρχουν μη αποθηκευμενες αλλαγες");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Θελετε να κλεισετε την εφαρμογη", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }
        private void Previous_Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (UnsavedChecker() == true)
                {
                    // MessageBox.Show("Unsaved Changes");
                }
                else
                {
                    if (NullCheckUp() == true)
                    {
                        MessageBox.Show("Το πεδιο δεν μπορει να ειναι κενο η μηδεν");

                    }
                    else
                    {
                        if (Convert.ToInt32(counter.TextBox.Text) <= 1) { PreviousButton.Enabled = false; }
                        else
                        {
                            counter.Text = (Convert.ToInt64(counter.Text) - 1).ToString();
                            LastPageButton.Enabled = true;
                            NextButton.Enabled = true;
                            if (Convert.ToInt64(counter.ToString()) <= 1)
                            {
                                PreviousButton.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        private void NextButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (UnsavedChecker() == true)
                {
                    //MessageBox.Show("Unsaved Changes");
                }
                else
                {
                    if (NullCheckUp() == true)
                    {
                        MessageBox.Show("Το πεδιο δεν μπορει να ειναι κενο η μηδεν");
                    }
                    else
                    {
                        if (Convert.ToInt32(counter.TextBox.Text) == Convert.ToInt32(OfCounter.Text)) { NextButton.Enabled = false; }
                        else
                        {
                            counter.Text = (Convert.ToInt64(counter.TextBox.Text) + 1).ToString();
                            PreviousButton.Enabled = true;
                            FirstPageButton.Enabled = true;
                            if (Convert.ToInt64(counter.ToString()) == Convert.ToInt64(OfCounter.ToString()))
                            {
                                NextButton.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        private void FirstPageButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (UnsavedChecker() == true)
                {
                    //MessageBox.Show("Unsaved Changes");
                }
                else
                {
                    if (NullCheckUp() == true)
                    {
                        MessageBox.Show("Το πεδιο δεν μπορει να ειναι κενο η μηδεν");
                        FirstPageButton.Enabled = false;
                    }
                    else
                    {
                        if (Convert.ToInt64(counter.TextBox.Text) > 1)
                        {
                            FirstPageButton.Enabled = true;
                            counter.TextBox.Text = "1";
                            LastPageButton.Enabled = true;
                        }
                        else { FirstPageButton.Enabled = false; }
                    }
                }
            }
        }
        private void LastPageButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (UnsavedChecker() == true)
                {
                    //MessageBox.Show("Unsaved Changes");
                }
                else
                {
                    if (NullCheckUp() == true)
                    {
                        MessageBox.Show("Το πεδιο δεν μπορει να ειναι κενο η μηδεν");
                        LastPageButton.Enabled = false;
                    }
                    else
                    {
                        if (Convert.ToInt64(counter.TextBox.Text) < Convert.ToInt64(OfCounter.Text))
                        {
                            LastPageButton.Enabled = true;
                            counter.TextBox.Text = bl.GetNunmberOfPages().ToString();
                            FirstPageButton.Enabled = true;

                        }
                        else { LastPageButton.Enabled = false; }

                    }
                }
            }
        }
        private void Counter_TextChanged(object sender, EventArgs e)
        {
            if (NullCheckUp() == true)
            {
                //MessageBox.Show("Το πεδιο δεν μπορει να ειναι κενο η μηδεν");
            }
            else
            {
                bl.FillListToDisplay(null,Convert.ToInt32(counter.TextBox.Text));
                //Bussiness.Parameters.TablesDto SelectedClass = (Bussiness.Parameters.TablesDto)TableList.SelectedItem;
                ReBoundListToGrid();
            }
        }
        public void OfCounter_TextChanged(object sender, EventArgs e)
        {

        }
        public bool UnsavedChecker()
        {
            if (hasChanges == true)
            {
                DialogResult dialogResult = MessageBox.Show("Υπαρχουν μη αποθηκευμενες αλλαγες", "Θελετε να συνεχισετε?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                }
                else if (dialogResult == DialogResult.No)
                {
                    return true;
                }
            }
            return false;
        }
        public void DataGridShow_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            hasChanges = true;
        }
        public bool NullCheckUp()
        {
            if (string.IsNullOrEmpty(counter.TextBox.Text) || Convert.ToInt32(counter.TextBox.Text) == 0)
            {
                counter.Focus();
                NextButton.Enabled = false;
                PreviousButton.Enabled = false;
                return true;
            }
            else
            {
                NextButton.Enabled = true;
                PreviousButton.Enabled = true;
            }
            return false;
        }
        private void Search_btn_Click(object sender, EventArgs e)
        {
            SearchForm form2 = new SearchForm(this, ColumnAccesseList.Where(x => x.Visible == true).ToList());
            form2.Show();
        }
        private void ExcelImport_Click(object sender, EventArgs e)
        {
            var tablesDto = SelectedClass;
            ExcelForm excel = new ExcelForm((Bussiness.Parameters.TablesDto)TableList.SelectedItem, bl);
            List<string> pp = new List<string>();
            var tt = new List<Tuple<string, Type>>();
            foreach (DataGridViewColumn column  in dataGridShow.Columns)
            {
              if (!HelpingMethod.myColumns.Any(x => x == column.Name))
              {
                pp.Add(column.Name);
              }
            }
            foreach (DataGridViewColumn column in dataGridShow.Columns)
            {
              if (!HelpingMethod.myColumns.Any(x => x == column.Name))
              {
                tt.Add(Tuple.Create(column.Name, column.ValueType));
                    
              }
            }
            Bussiness.Excel.ExcelValidation ll = new Bussiness.Excel.ExcelValidation(); 
            List<ExcelParameters> validates = new List<ExcelParameters>()
            {
               new ExcelParameters(ExcelEnu.ColumnNumber, 3),
               new ExcelParameters(ExcelEnu.ColumnNameFromList, pp),
               new ExcelParameters(ExcelEnu.NotEmpty, 1),
               new ExcelParameters(ExcelEnu.SameDataType, tt)
            };
            ExcelReadResponse resp = ll.ExcelOpen(tablesDto,validates);
            if (resp.isValid)
            {
                var data = resp.dataTable;
                excel.PopulateGrid(data);
                excel.Show();
            }
         }

        private void TableList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
