using Bussiness.Helper;
using Bussiness.Parameters;
using DataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace DWEFormsWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //private Logger logger = LogManager.GetCurrentClassLogger();
        //public IList<TablesDto> listOfTables;
        //public Bussiness.Excel.ExcelValidation ex;
        //private Bussiness.Settings.BussinessSettings bl;
        //public List<ColumnAccess> ColumnAccesseList = new List<ColumnAccess>();
        //private bool hasChanges = false;
        //public FilterItems filter = null;
        //private Bussiness.Parameters.TablesDto SelectedClass;
        //private List<DataGridItem> s = new List<DataGridItem>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var ll = new Bussiness.ParametersInputs(Settings.Log.logger);
            Settings.Settings.listOfTables = ll.GetListOfTablesInputs();
            TableList.DataSource = Settings.Settings.listOfTables;
            TableList.DataTextField = "Name";
            TableList.DataValueField = "ID";
            TableList.DataBind();
            //toolStrip1.Enabled = false;
            //ExcelImport.Enabled = false;
            //Search_btn.Enabled = false;
            //ButtonAdd.Enabled = false;
            //ButtonSave.Enabled = false;
        }

        protected void DataBind_Click(object sender, EventArgs e)
        {
            Settings.Settings.SelectedClass = Settings.Settings.listOfTables.Where(x => x.ID.ToString() == TableList.SelectedValue).FirstOrDefault();
            DoFilter(Settings.Settings.filter);
            //ExcelImport.Enabled = true;
            //Search_btn.Enabled = true;
            //ButtonAdd.Enabled = true;
            //ButtonSave.Enabled = true;
        }
        public void DoFilter(FilterItems filter)
        {
            Settings.Settings.SelectedClass = Settings.Settings.listOfTables.Where(x => x.ID.ToString() == TableList.SelectedValue).FirstOrDefault();
            Settings.Settings.filter = filter;
            DataGridView.DataSource = null;
            DataGridView.Columns.Clear();
            PageValidation(Settings.Settings.SelectedClass);
            //NextButton.Enabled = true;
            //PreviousButton.Enabled = false;            
        }
        private void ReBoundListToGrid()
        {
            Settings.Settings.ColumnAccesseList.Clear();
            try
            {
                if (Settings.Settings.SelectedClass == null)
                {
                    Settings.Settings.SelectedClass = Settings.Settings.listOfTables.Where(x => x.ID.ToString() == TableList.SelectedValue).FirstOrDefault();
                }
                Settings.Settings.SelectedClass = Settings.Settings.listOfTables.Where(x => x.ID.ToString() == TableList.SelectedValue).FirstOrDefault();
                DataGridView.DataSource = null;
                DataGridView.Columns.Clear();
                DataGridView.DataSource = Settings.Settings.bl.DisplayList;
                DataGridView.AutoGenerateColumns = true;
                DataGridView.DataBind();


                //List<DataControlField> dgvC = (List<DataControlField>)DataGridView.Columns.CloneFields();
                
                foreach (GridView c in DataGridView.Columns.CloneFields())
                {
                    var i = "" ;
                    i = c.HeaderRow.Cells[0].Text;
                    //i = c.Rows[0].Cells[0].Text;
                    //var i = Settings.Settings.SelectedClass.TableColumns.FindLast(x => x.Name == c.Name);
                    //var cNew = DataGridView.Columns[DataGridView.Columns.IndexOf(c)];
                    var columnAccess = new Bussiness.Helper.ColumnAccess();
                    //columnAccess.Name = cNew.HeaderText;
                    //columnAccess.Caption = cNew.HeaderText;
                    if (i != null)
                    {
                        //columnAccess.DataList = ApplySettingsToColumn(cNew, i, Settings.Settings.filter);
                        //columnAccess.ComboDisplayMember = i.ComboDisplayMember;
                        //columnAccess.ComboValueMember = i.ComboValueMember;
                        //columnAccess.Type = SearchTypesMapping.GetSearchTypesMappingFromType((Type)cNew.GetPropValue("") /*i.isCombo*/);
                        //columnAccess.Visible = i.Visible;
                    }
                    else
                    {
                        //columnAccess.Type = SearchTypesMapping.GetSearchTypesMappingFromType((Type)cNew.GetPropValue("")) ;
                        columnAccess.Visible = true;
                    }
                    Settings.Settings.ColumnAccesseList.Add(columnAccess);
                    Debug.Print("A");
                }
                Settings.Settings.hasChanges = false;
            }
            catch (Exception exc)
            {
                Settings.Settings.hasChanges = false;
                Settings.Settings.logger.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, exc);
                Console.ReadLine();
            }
        }
        private List<object> ApplySettingsToColumn(GridView c, Bussiness.Parameters.ColumnsDto i, FilterItems filter)
        {
            try
            {
                if (i.isCombo)
                {
                    GridView bc = new GridView();
                    //to thelw gia na mhn zhtaw apo thn vash an exei combobox
                    List<object> DataSourceList = Settings.Settings.bl.GetComBoxList(i, filter);
                    bc.DataSource = DataSourceList;
                    bc.DataMember = i.ComboDisplayMember;
                    //bc.SelectedValue = i.ComboValueMember;

                    GridView newC = new GridView();
                    //c.SelectedIndex;
                    //newC.SelectedIndex = c.SelectedIndex;
                    c.Visible = false;
                    c = newC;
                    //DataGridView.Columns.Add(newC);

                    foreach (GridViewRow item in DataGridView.Rows)
                    {
                        item.Cells[newC.SelectedIndex].GetPropValue(""); 
                        item.Cells[c.SelectedIndex].GetPropValue("");
                    }
                    //ApplySpecificPropertiesToColumn(i, newC);
                    return DataSourceList;
                }
                else
                {
                    //ApplySpecificPropertiesToColumn(i, c);
                    return null;
                }

            }
            catch (Exception exc)
            {
                Settings.Settings.logger.Error(System.Reflection.MethodBase.GetCurrentMethod().Name, exc);
                Console.ReadLine();
            }
            return null;
        }
        private static void ApplySpecificPropertiesToColumn(GridView i, GridView c)
        {
            c.Visible = i.Visible;
            //c.HeaderRow = i.HeaderRow.ToString();
            //c.Frozen = i.;
            //c.ReadOnly = i.ReadOnly;
        }
        public void PageValidation(TablesDto SelectedClass)
        {
            Settings.Settings.SelectedClass = SelectedClass;
            int pageNumber = 1;
            
            Settings.Settings.bl = new Bussiness.Settings.BussinessSettings(Settings.Settings.logger, SelectedClass, Settings.Settings.filter, pageNumber);
            Settings.Settings.bl.FillListToDisplay(Settings.Settings.filter, pageNumber);
            if (DataAccess.Helper.PaginatedStatus.paginatedStatus.usePagination == true)
            {
                pageNumber = 1;
                //OfLabel.Text = "Of";
                OfCounter.Text = Settings.Settings.bl.GetNunmberOfPages().ToString();
                //toolStrip1.Enabled = true;
                ReBoundListToGrid();
            }
            else
            {
                //toolStrip1.Enabled = false;
                //counter.Visible = false;
            }

            //counter.Text = pageNumber.ToString();
            ReBoundListToGrid();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Οι αλλαγες αποθηκευτηκαν");
            Settings.Settings.bl.SaveListToDb();
            //hasChanges = false;
        }
        public void ButtonAdd_Click(object sender, EventArgs e)
        {
            Settings.Settings.bl.AddRowToList();
            ReBoundListToGrid();

        }
        //private void Wizzard_Click(object sender, EventArgs e)
        //{
        //    var f = new Wizzard();
        //    f.campaignsDto = Settings.Settings.listOfTables.Where(x => x.Name == "Campaigns").FirstOrDefault();
        //    f.wavesDto = Settings.Settings.listOfTables.Where(x => x.Name == "CampaignWaves").FirstOrDefault();
        //    f.Show();
        //}
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
                    //Close();
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
                        if (Convert.ToInt32(counter.Text) <= 1) { PreviousButton.Enabled = false; }
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
                        if (Convert.ToInt32(counter.Text) == Convert.ToInt32(OfCounter.Text)) { NextButton.Enabled = false; }
                        else
                        {
                            counter.Text = (Convert.ToInt64(counter.Text) + 1).ToString();
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
                        if (Convert.ToInt64(counter.Text) > 1)
                        {
                            FirstPageButton.Enabled = true;
                            counter.Text = "1";
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
                        if (Convert.ToInt64(counter.Text) < Convert.ToInt64(OfCounter.Text))
                        {
                            LastPageButton.Enabled = true;
                            counter.Text = Settings.Settings.bl.GetNunmberOfPages().ToString();
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
                Settings.Settings.bl.FillListToDisplay(null, Convert.ToInt32(counter.Text));
                //Bussiness.Parameters.TablesDto SelectedClass = (Bussiness.Parameters.TablesDto)TableList.SelectedItem;
                ReBoundListToGrid();
            }
        }
        public void OfCounter_TextChanged(object sender, EventArgs e)
        {

        }
        public bool UnsavedChecker()
        {
            if (Settings.Settings.hasChanges == true)
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
            Settings.Settings.hasChanges = true;
        }
        public bool NullCheckUp()
        {
            if (string.IsNullOrEmpty(counter.Text) || Convert.ToInt32(counter.Text) == 0)
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
        //private void Search_btn_Click(object sender, EventArgs e)
        //{
        //    SearchForm form2 = new SearchForm(this, ColumnAccesseList.Where(x => x.Visible == true).ToList());
        //    form2.Show();
        //}
        private void ExcelImport_Click(object sender, EventArgs e)
        {
            var tablesDto = Settings.Settings.SelectedClass;
            //ExcelForm excel = new ExcelForm((Bussiness.Parameters.TablesDto)TableList.SelectedItem, bl);
            List<string> pp = new List<string>();
            var tt = new List<Tuple<string, Type>>();
            foreach (DataGridViewColumn column in DataGridView.Columns)
            {
                if (!HelpingMethod.myColumns.Any(x => x == column.Name))
                {
                    pp.Add(column.Name);
                }
            }
            foreach (DataGridViewColumn column in DataGridView.Columns)
            {
                if (!HelpingMethod.myColumns.Any(x => x == column.Name))
                {
                    tt.Add(Tuple.Create(column.Name, column.ValueType));

                }
            }
            Bussiness.Excel.ExcelValidation ll = new Bussiness.Excel.ExcelValidation();
            //List<ExcelParameters> validates = new List<ExcelParameters>()
            //{
            //   new ExcelParameters(ExcelEnu.ColumnNumber, 3),
            //   new ExcelParameters(ExcelEnu.ColumnNameFromList, pp),
            //   new ExcelParameters(ExcelEnu.NotEmpty, 1),
            //   new ExcelParameters(ExcelEnu.SameDataType, tt)
            //};
            //ExcelReadResponse resp = ll.ExcelOpen(tablesDto, validates);
            //if (resp.isValid)
            //{
            //    var data = resp.dataTable;
            //    excel.PopulateGrid(data);
            //    excel.Show();
            //}
        }

    }
}