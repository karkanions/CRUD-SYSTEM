using AutoMapper;
using Bussiness.Helper;
using Bussiness.Mapping;
using Bussiness.Parameters;
using DataAccess.Helper;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bussinesss.Helper.EnumHelp;
using static DataAccess.Helper.Enums;

namespace DWHEditForms
{
    public partial class SearchForm : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly AutomapperSettings mapper = new AutomapperSettings();
        public List<ColumnAccess> ColumnAccesseList;
        private readonly FrmMain frmMain;
        public SearchForm(FrmMain frmMain, List<ColumnAccess> ColumnAccesseList)
        {
            InitializeComponent();
            this.ColumnAccesseList = ColumnAccesseList;
            FillColumnNamesListBox();
            OutputBtn.Enabled = false;
            txtF.Enabled = false;
            NumF.Enabled = false;
            listbox.Enabled = false;
            this.frmMain = frmMain;
        }
        public void Form2_Load(object sender, EventArgs e)
        {

        }
        private void FillColumnNamesListBox()
        {
            var list = EnumWithName<Operators>.ParseEnum();// (IList<Oparators>)Enum.GetValues(typeof(Oparators));
            holderBox.DataSource = ColumnAccesseList;
            holderBox.ValueMember = "Name";
            holderBox.DisplayMember = "Caption";
            OparatorBox.DataSource = list;
            OparatorBox.ValueMember = "Value";
            OparatorBox.DisplayMember = "Name";
        }
        private void HolderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bussiness.Helper.ColumnAccess sel = (Bussiness.Helper.ColumnAccess)holderBox.SelectedItem;
            switch (sel.Type)
            {
                case SearchTypes.String:
                    txtF.Enabled = true;
                    NumF.Enabled = false;
                    listbox.Enabled = false;
                    FlagBox.Enabled = false;
                    break;
                case SearchTypes.Number:
                    NumF.Enabled = true;
                    txtF.Enabled = false;
                    listbox.Enabled = false;
                    FlagBox.Enabled = false;
                    break;
                case SearchTypes.DateTime:
                    NumF.Enabled = true;
                    txtF.Enabled = false;
                    listbox.Enabled = false;
                    FlagBox.Enabled = false;
                    break;
                case SearchTypes.ListBox:
                    listbox.Enabled = true;
                    listbox.DataSource = sel.DataList;
                    listbox.DisplayMember = sel.ComboDisplayMember;
                    listbox.ValueMember = sel.ComboValueMember;
                    txtF.Enabled = false;
                    NumF.Enabled = false;
                    FlagBox.Enabled = false;
                    break;
                case SearchTypes.Flag:
                    txtF.Enabled = false;
                    NumF.Enabled = false;
                    listbox.Enabled = false;
                    FlagBox.Enabled = true;
                    break;
                default:
                    break; 
            }
        }
        public FilterItems FilterMethod() 
        {
            FilterItems filter = new FilterItems
            {
                Name = holderBox.SelectedValue.ToString(),
                Operators = (Operators)OparatorBox.SelectedValue
            };
            if (txtF.Enabled == true) 
            {
                filter.Value = txtF.Text;
            }
            if (NumF.Enabled == true) 
            {
                filter.Value = NumF.Text;
            }
            if (FlagBox.Enabled == true) 
            {
                filter.Value = FlagBox.Checked;
            }
            if (listbox.Enabled == true) 
            {
                filter.Value = listbox.SelectedValue;
            }
            return filter;
        }
        public void OutputBtn_Click(object sender, EventArgs e)
        {
            FilterItems filter = FilterMethod();
            frmMain.DoFilter(filter);
        }
        private void Check_button_Click(object sender, EventArgs e)
        {
            if (txtF.Enabled == true)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtF.Text, "^[a-zA-Z ]*$")) {OutputBtn.Enabled = true;}
                else {OutputBtn.Enabled = false;}
            }
            if (NumF.Enabled == true)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(NumF.Text, "^[0-9]")) {OutputBtn.Enabled = true;}
                else {OutputBtn.Enabled = false;}
            }
            if (FlagBox.Enabled == true)
            {
                if (FlagBox.Checked == true) { OutputBtn.Enabled = true; }
                else {OutputBtn.Enabled = false;}
            }
            if (listbox.Enabled == true) 
            {OutputBtn.Enabled = true;}
        }
    }
}