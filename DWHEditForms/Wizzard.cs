using Bussiness.Helper;
using Bussiness.Parameters;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Bussiness.BussinesEntities;
using ExcelDataReader;
using System.IO;
using DataTable = System.Data.DataTable;
using Bussinesss.Excel;
using DataAccess.Helper;

namespace DWHEditForms
{
    public partial class Wizzard : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
       
        public Bussiness.Parameters.TablesDto wavesDto;
        public Bussiness.Parameters.TablesDto campaignsDto;
        public Bussiness.Excel.ExcelValidation ex;
        private readonly System.Data.DataTable rowsToInsert;
        public DataGridView DataGridView;
        public FilterItems filter;
        private readonly FrmMain frmMain;
        private readonly TablesDto tablesDto;

        public Wizzard()
        {
            InitializeComponent();
            //frmMain.
        }
        private void Campaing_Enter(object sender, EventArgs e)
        {
            Bussiness.Settings.BussinessSettings bs = new Bussiness.Settings.BussinessSettings(logger, campaignsDto, filter);
            CampaignBox.DataSource = bs.DisplayList;
            CampaignBox.DisplayMember = "CampaignName";
            CampaignBox.ValueMember = "ID";
            
        }
        private void Wave_Enter(object sender, EventArgs e)
        {
            Bussiness.Settings.BussinessSettings ss = new Bussiness.Settings.BussinessSettings(logger, wavesDto, filter);
            List<Object> FilterList = ss.DisplayList.Where(x => x.GetPropValue<int>("CampaignId").ToString() == CampaignBox.SelectedValue.ToString()).ToList();
            WaveBox.DataSource = FilterList;
            WaveBox.DisplayMember = "WaveName";
            WaveBox.ValueMember = "ID";
        }
        private void Button_Next(object sender, AdvancedWizardControl.EventArguments.WizardEventArgs e)
        {
            label1.Text = CampaignBox.Text.ToString();
            label2.Text = WaveBox.Text.ToString();
            if (e.CurrentPageIndex == 1 && CampaignBox.ValueMember != "ID")
            {
                MessageBox.Show(CampaignBox.SelectedValue?.ToString());
                //Bussiness.Helper.HelpingMethod.campaignID = (int)CampaignBox.SelectedValue;
                e.AllowPageChange = false;
            }
            if (e.CurrentPageIndex == 2 && WaveBox.ValueMember != "ID")
            {
                MessageBox.Show("Wrong Wave",WaveBox.SelectedValue?.ToString());
                //Bussiness.Helper.HelpingMethod.waveID = (int)WaveBox.SelectedValue;
                e.AllowPageChange = false;
            }
            if (e.CurrentPageIndex == 3 && (rowsToInsert == null || rowsToInsert.Rows.Count == 0))
            {
                MessageBox.Show("Wrong Excel",rowsToInsert?.Rows?.Count.ToString());
                e.AllowPageChange = true;
            }
        }
        private void Data_Button_Click(object sender, EventArgs e)
        {
            Bussiness.Excel.ExcelValidation ll = new Bussiness.Excel.ExcelValidation();
            List<ExcelParameters> validates = new List<ExcelParameters>() {
                new ExcelParameters(ExcelEnu.ColumnNumber, 3),
                new ExcelParameters(ExcelEnu.ColumnNameFromList, "Name")
            };
            ExcelReadResponse resp = ll.ExcelOpen(tablesDto,validates);
            Final_Grid_View.DataSource = resp.dataTable;
            var r = resp.dataTable.Rows.Count;
            label6.Text = r.ToString();

            //if (resp.isValid)
            //{
            //    var r = resp.dataTable.Rows.Count;
            //    label6.Text = r.ToString();
            //    rowsToInsert = r.; 
            //}
        }
        private void Button_Cancel(object sender, EventArgs e)
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
        private void Button_Finish(object sender, EventArgs e)
        {
            List <CampaignPoolDto> campaignPoolList = Bussiness.Mapping.AutoMapperExtension.ReadData<CampaignPoolDto>(rowsToInsert);
            campaignPoolList
                .ForEach(x => 
                    {
                        x.CampaignId = (int)CampaignBox.SelectedValue;
                        x.WaveId = (int)WaveBox.SelectedValue;
                    }
                );
        }  
    }
}
