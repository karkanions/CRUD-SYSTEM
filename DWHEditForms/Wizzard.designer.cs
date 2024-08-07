
namespace DWHEditForms
{
    partial class Wizzard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizzard));
            this.advancedWizard1 = new AdvancedWizardControl.Wizard.AdvancedWizard();
            this.advancedWizardStartedPage = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.advancedWizardPageCampaignGet = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CampaignBox = new System.Windows.Forms.ComboBox();
            this.advancedWizardPWaveBox_get = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.WaveBox = new System.Windows.Forms.ComboBox();
            this.advancedWizardPageRowsGet = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.Data_Button = new System.Windows.Forms.Button();
            this.Final_Grid_View = new System.Windows.Forms.DataGridView();
            this.advancedWizardFinishPage = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.advancedWizard1.SuspendLayout();
            this.advancedWizardStartedPage.SuspendLayout();
            this.advancedWizardPageCampaignGet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.advancedWizardPWaveBox_get.SuspendLayout();
            this.advancedWizardPageRowsGet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Final_Grid_View)).BeginInit();
            this.advancedWizardFinishPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // advancedWizard1
            // 
            this.advancedWizard1.BackButtonEnabled = false;
            this.advancedWizard1.BackButtonText = "< Back";
            this.advancedWizard1.ButtonLayout = AdvancedWizardControl.Enums.ButtonLayoutKind.Office97;
            this.advancedWizard1.ButtonsVisible = true;
            this.advancedWizard1.CancelButtonText = "&Cancel";
            this.advancedWizard1.Controls.Add(this.advancedWizardStartedPage);
            this.advancedWizard1.Controls.Add(this.advancedWizardPageCampaignGet);
            this.advancedWizard1.Controls.Add(this.advancedWizardPWaveBox_get);
            this.advancedWizard1.Controls.Add(this.advancedWizardPageRowsGet);
            this.advancedWizard1.Controls.Add(this.advancedWizardFinishPage);
            this.advancedWizard1.CurrentPageIsFinishPage = false;
            this.advancedWizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedWizard1.FinishButton = true;
            this.advancedWizard1.FinishButtonEnabled = true;
            this.advancedWizard1.FinishButtonText = "&Finish";
            this.advancedWizard1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.advancedWizard1.HelpButton = false;
            this.advancedWizard1.HelpButtonText = "&Help";
            this.advancedWizard1.Location = new System.Drawing.Point(0, 0);
            this.advancedWizard1.Name = "advancedWizard1";
            this.advancedWizard1.NextButtonEnabled = true;
            this.advancedWizard1.NextButtonText = "Next >";
            this.advancedWizard1.ProcessKeys = false;
            this.advancedWizard1.Size = new System.Drawing.Size(825, 450);
            this.advancedWizard1.TabIndex = 0;
            this.advancedWizard1.TouchScreen = false;
            this.advancedWizard1.WizardPages.Add(this.advancedWizardStartedPage);
            this.advancedWizard1.WizardPages.Add(this.advancedWizardPageCampaignGet);
            this.advancedWizard1.WizardPages.Add(this.advancedWizardPWaveBox_get);
            this.advancedWizard1.WizardPages.Add(this.advancedWizardPageRowsGet);
            this.advancedWizard1.WizardPages.Add(this.advancedWizardFinishPage);
            this.advancedWizard1.Cancel += new System.EventHandler(this.Button_Cancel);
            this.advancedWizard1.Next += new System.EventHandler<AdvancedWizardControl.EventArguments.WizardEventArgs>(this.Button_Next);
            this.advancedWizard1.Finish += new System.EventHandler(this.Button_Finish);
            // 
            // advancedWizardStartedPage
            // 
            this.advancedWizardStartedPage.Controls.Add(this.richTextBox1);
            this.advancedWizardStartedPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedWizardStartedPage.Header = true;
            this.advancedWizardStartedPage.HeaderBackgroundColor = System.Drawing.Color.White;
            this.advancedWizardStartedPage.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.advancedWizardStartedPage.HeaderImage = ((System.Drawing.Image)(resources.GetObject("advancedWizardStartedPage.HeaderImage")));
            this.advancedWizardStartedPage.HeaderImageVisible = true;
            this.advancedWizardStartedPage.HeaderTitle = "//Some Text// (Start)";
            this.advancedWizardStartedPage.Location = new System.Drawing.Point(0, 0);
            this.advancedWizardStartedPage.Name = "advancedWizardStartedPage";
            this.advancedWizardStartedPage.PreviousPage = 0;
            this.advancedWizardStartedPage.Size = new System.Drawing.Size(825, 410);
            this.advancedWizardStartedPage.SubTitle = "";
            this.advancedWizardStartedPage.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.advancedWizardStartedPage.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(30, 121);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(746, 238);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "//Some Text//";
            // 
            // advancedWizardPageCampaignGet
            // 
            this.advancedWizardPageCampaignGet.Controls.Add(this.panel1);
            this.advancedWizardPageCampaignGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedWizardPageCampaignGet.Header = true;
            this.advancedWizardPageCampaignGet.HeaderBackgroundColor = System.Drawing.Color.White;
            this.advancedWizardPageCampaignGet.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.advancedWizardPageCampaignGet.HeaderImage = ((System.Drawing.Image)(resources.GetObject("advancedWizardPageCampaignGet.HeaderImage")));
            this.advancedWizardPageCampaignGet.HeaderImageVisible = true;
            this.advancedWizardPageCampaignGet.HeaderTitle = "//Some Text//";
            this.advancedWizardPageCampaignGet.Location = new System.Drawing.Point(0, 0);
            this.advancedWizardPageCampaignGet.Name = "advancedWizardPageCampaignGet";
            this.advancedWizardPageCampaignGet.PreviousPage = 0;
            this.advancedWizardPageCampaignGet.Size = new System.Drawing.Size(825, 410);
            this.advancedWizardPageCampaignGet.SubTitle = "";
            this.advancedWizardPageCampaignGet.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.advancedWizardPageCampaignGet.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CampaignBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 410);
            this.panel1.TabIndex = 4;
            this.panel1.Enter += new System.EventHandler(this.Campaing_Enter);
            // 
            // CampaignBox
            // 
            this.CampaignBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CampaignBox.FormattingEnabled = true;
            this.CampaignBox.Location = new System.Drawing.Point(12, 141);
            this.CampaignBox.Name = "CampaignBox";
            this.CampaignBox.Size = new System.Drawing.Size(520, 24);
            this.CampaignBox.TabIndex = 0;
            // 
            // advancedWizardPWaveBox_get
            // 
            this.advancedWizardPWaveBox_get.Controls.Add(this.WaveBox);
            this.advancedWizardPWaveBox_get.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedWizardPWaveBox_get.Header = true;
            this.advancedWizardPWaveBox_get.HeaderBackgroundColor = System.Drawing.Color.White;
            this.advancedWizardPWaveBox_get.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.advancedWizardPWaveBox_get.HeaderImage = ((System.Drawing.Image)(resources.GetObject("advancedWizardPWaveBox_get.HeaderImage")));
            this.advancedWizardPWaveBox_get.HeaderImageVisible = true;
            this.advancedWizardPWaveBox_get.HeaderTitle = "//Some Text//";
            this.advancedWizardPWaveBox_get.Location = new System.Drawing.Point(0, 0);
            this.advancedWizardPWaveBox_get.Name = "advancedWizardPWaveBox_get";
            this.advancedWizardPWaveBox_get.PreviousPage = 1;
            this.advancedWizardPWaveBox_get.Size = new System.Drawing.Size(825, 410);
            this.advancedWizardPWaveBox_get.SubTitle = "";
            this.advancedWizardPWaveBox_get.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.advancedWizardPWaveBox_get.TabIndex = 6;
            this.advancedWizardPWaveBox_get.Enter += new System.EventHandler(this.Wave_Enter);
            // 
            // WaveBox
            // 
            this.WaveBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WaveBox.FormattingEnabled = true;
            this.WaveBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.WaveBox.Location = new System.Drawing.Point(12, 141);
            this.WaveBox.Name = "WaveBox";
            this.WaveBox.Size = new System.Drawing.Size(520, 24);
            this.WaveBox.TabIndex = 3;
            // 
            // advancedWizardPageRowsGet
            // 
            this.advancedWizardPageRowsGet.Controls.Add(this.Data_Button);
            this.advancedWizardPageRowsGet.Controls.Add(this.Final_Grid_View);
            this.advancedWizardPageRowsGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedWizardPageRowsGet.Header = true;
            this.advancedWizardPageRowsGet.HeaderBackgroundColor = System.Drawing.Color.White;
            this.advancedWizardPageRowsGet.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.advancedWizardPageRowsGet.HeaderImage = ((System.Drawing.Image)(resources.GetObject("advancedWizardPageRowsGet.HeaderImage")));
            this.advancedWizardPageRowsGet.HeaderImageVisible = true;
            this.advancedWizardPageRowsGet.HeaderTitle = "//Some Text///";
            this.advancedWizardPageRowsGet.Location = new System.Drawing.Point(0, 0);
            this.advancedWizardPageRowsGet.Name = "advancedWizardPageRowsGet";
            this.advancedWizardPageRowsGet.PreviousPage = 2;
            this.advancedWizardPageRowsGet.Size = new System.Drawing.Size(825, 410);
            this.advancedWizardPageRowsGet.SubTitle = "";
            this.advancedWizardPageRowsGet.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.advancedWizardPageRowsGet.TabIndex = 5;
            // 
            // Data_Button
            // 
            this.Data_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Data_Button.Location = new System.Drawing.Point(12, 78);
            this.Data_Button.Name = "Data_Button";
            this.Data_Button.Size = new System.Drawing.Size(801, 67);
            this.Data_Button.TabIndex = 6;
            this.Data_Button.Text = "Data";
            this.Data_Button.UseVisualStyleBackColor = true;
            this.Data_Button.Click += new System.EventHandler(this.Data_Button_Click);
            // 
            // Final_Grid_View
            // 
            this.Final_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Final_Grid_View.Location = new System.Drawing.Point(12, 151);
            this.Final_Grid_View.Name = "Final_Grid_View";
            this.Final_Grid_View.RowHeadersWidth = 51;
            this.Final_Grid_View.RowTemplate.Height = 24;
            this.Final_Grid_View.Size = new System.Drawing.Size(801, 256);
            this.Final_Grid_View.TabIndex = 1;
            // 
            // advancedWizardFinishPage
            // 
            this.advancedWizardFinishPage.Controls.Add(this.label7);
            this.advancedWizardFinishPage.Controls.Add(this.label6);
            this.advancedWizardFinishPage.Controls.Add(this.label5);
            this.advancedWizardFinishPage.Controls.Add(this.label4);
            this.advancedWizardFinishPage.Controls.Add(this.label3);
            this.advancedWizardFinishPage.Controls.Add(this.label2);
            this.advancedWizardFinishPage.Controls.Add(this.label1);
            this.advancedWizardFinishPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedWizardFinishPage.Header = true;
            this.advancedWizardFinishPage.HeaderBackgroundColor = System.Drawing.Color.White;
            this.advancedWizardFinishPage.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.advancedWizardFinishPage.HeaderImage = ((System.Drawing.Image)(resources.GetObject("advancedWizardFinishPage.HeaderImage")));
            this.advancedWizardFinishPage.HeaderImageVisible = true;
            this.advancedWizardFinishPage.HeaderTitle = "//Some Text// (Final)";
            this.advancedWizardFinishPage.Location = new System.Drawing.Point(0, 0);
            this.advancedWizardFinishPage.Name = "advancedWizardFinishPage";
            this.advancedWizardFinishPage.PreviousPage = 3;
            this.advancedWizardFinishPage.Size = new System.Drawing.Size(825, 410);
            this.advancedWizardFinishPage.SubTitle = "";
            this.advancedWizardFinishPage.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.advancedWizardFinishPage.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Οι εγγραφες ειναι :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tα στοιχεια ειναι :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Τα στοιχεια ειναι :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-411, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Wizzard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 450);
            this.Controls.Add(this.advancedWizard1);
            this.Name = "Wizzard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wizzard";
            this.advancedWizard1.ResumeLayout(false);
            this.advancedWizardStartedPage.ResumeLayout(false);
            this.advancedWizardPageCampaignGet.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.advancedWizardPWaveBox_get.ResumeLayout(false);
            this.advancedWizardPageRowsGet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Final_Grid_View)).EndInit();
            this.advancedWizardFinishPage.ResumeLayout(false);
            this.advancedWizardFinishPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AdvancedWizardControl.Wizard.AdvancedWizard advancedWizard1;
        private AdvancedWizardControl.WizardPages.AdvancedWizardPage advancedWizardStartedPage;
        private AdvancedWizardControl.WizardPages.AdvancedWizardPage advancedWizardPageCampaignGet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CampaignBox;
        private AdvancedWizardControl.WizardPages.AdvancedWizardPage advancedWizardFinishPage;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private AdvancedWizardControl.WizardPages.AdvancedWizardPage advancedWizardPageRowsGet;
        private System.Windows.Forms.DataGridView Final_Grid_View;
        private System.Windows.Forms.Button Data_Button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private AdvancedWizardControl.WizardPages.AdvancedWizardPage advancedWizardPWaveBox_get;
        private System.Windows.Forms.ComboBox WaveBox;
    }
}