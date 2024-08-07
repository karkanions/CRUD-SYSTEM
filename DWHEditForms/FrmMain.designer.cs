namespace DWHEditForms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.DataBind = new System.Windows.Forms.Button();
            this.dataGridShow = new System.Windows.Forms.DataGridView();
            this.TableList = new System.Windows.Forms.ComboBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Close_Button = new System.Windows.Forms.Button();
            this.FirstPageButton = new System.Windows.Forms.ToolStripButton();
            this.PreviousButton = new System.Windows.Forms.ToolStripButton();
            this.counter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OfLabel = new System.Windows.Forms.ToolStripLabel();
            this.OfCounter = new System.Windows.Forms.ToolStripLabel();
            this.NextButton = new System.Windows.Forms.ToolStripButton();
            this.LastPageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Search_btn = new System.Windows.Forms.Button();
            this.ExcelImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShow)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataBind
            // 
            this.DataBind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataBind.Location = new System.Drawing.Point(831, 12);
            this.DataBind.Name = "DataBind";
            this.DataBind.Size = new System.Drawing.Size(120, 54);
            this.DataBind.TabIndex = 0;
            this.DataBind.Text = "BringData";
            this.DataBind.UseVisualStyleBackColor = true;
            this.DataBind.Click += new System.EventHandler(this.DataBind_Click);
            // 
            // dataGridShow
            // 
            this.dataGridShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridShow.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridShow.ColumnHeadersHeight = 29;
            this.dataGridShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridShow.Location = new System.Drawing.Point(12, 33);
            this.dataGridShow.Name = "dataGridShow";
            this.dataGridShow.RowHeadersWidth = 51;
            this.dataGridShow.RowTemplate.Height = 24;
            this.dataGridShow.Size = new System.Drawing.Size(813, 423);
            this.dataGridShow.TabIndex = 1;
            this.dataGridShow.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridShow_CellValueChanged);
            // 
            // TableList
            // 
            this.TableList.DisplayMember = "Name";
            this.TableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableList.FormattingEnabled = true;
            this.TableList.Location = new System.Drawing.Point(12, 3);
            this.TableList.Name = "TableList";
            this.TableList.Size = new System.Drawing.Size(462, 24);
            this.TableList.TabIndex = 2;
            this.TableList.SelectedIndexChanged += new System.EventHandler(this.TableList_SelectedIndexChanged);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.Location = new System.Drawing.Point(831, 134);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(120, 53);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAdd.Location = new System.Drawing.Point(831, 72);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(120, 56);
            this.ButtonAdd.TabIndex = 4;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(831, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "Wizzard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Wizzard_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_Button.Location = new System.Drawing.Point(831, 412);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(120, 44);
            this.Close_Button.TabIndex = 6;
            this.Close_Button.Text = "Close";
            this.Close_Button.UseVisualStyleBackColor = true;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // FirstPageButton
            // 
            this.FirstPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FirstPageButton.Image = ((System.Drawing.Image)(resources.GetObject("FirstPageButton.Image")));
            this.FirstPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FirstPageButton.Name = "FirstPageButton";
            this.FirstPageButton.Size = new System.Drawing.Size(29, 36);
            this.FirstPageButton.Text = "toolStripButton1";
            this.FirstPageButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FirstPageButton_MouseDown);
            // 
            // PreviousButton
            // 
            this.PreviousButton.CheckOnClick = true;
            this.PreviousButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviousButton.Image")));
            this.PreviousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(29, 24);
            this.PreviousButton.Text = "PreviousButton";
            this.PreviousButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.PreviousButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Previous_Button_MouseDown);
            // 
            // counter
            // 
            this.counter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(20, 27);
            this.counter.TextChanged += new System.EventHandler(this.Counter_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // OfLabel
            // 
            this.OfLabel.Name = "OfLabel";
            this.OfLabel.Size = new System.Drawing.Size(0, 24);
            // 
            // OfCounter
            // 
            this.OfCounter.Name = "OfCounter";
            this.OfCounter.Size = new System.Drawing.Size(0, 24);
            this.OfCounter.TextChanged += new System.EventHandler(this.OfCounter_TextChanged);
            // 
            // NextButton
            // 
            this.NextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NextButton.Image = ((System.Drawing.Image)(resources.GetObject("NextButton.Image")));
            this.NextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(29, 24);
            this.NextButton.Text = "toolStripButton2";
            this.NextButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NextButton_MouseDown);
            // 
            // LastPageButton
            // 
            this.LastPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LastPageButton.Image = ((System.Drawing.Image)(resources.GetObject("LastPageButton.Image")));
            this.LastPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LastPageButton.Name = "LastPageButton";
            this.LastPageButton.Size = new System.Drawing.Size(29, 24);
            this.LastPageButton.Text = "toolStripButton2";
            this.LastPageButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LastPageButton_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstPageButton,
            this.PreviousButton,
            this.counter,
            this.OfLabel,
            this.OfCounter,
            this.toolStripSeparator1,
            this.NextButton,
            this.LastPageButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 574);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1204, 39);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(480, 3);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(185, 24);
            this.Search_btn.TabIndex = 10;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // ExcelImport
            // 
            this.ExcelImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExcelImport.Location = new System.Drawing.Point(831, 193);
            this.ExcelImport.Name = "ExcelImport";
            this.ExcelImport.Size = new System.Drawing.Size(120, 50);
            this.ExcelImport.TabIndex = 11;
            this.ExcelImport.Text = "Excel";
            this.ExcelImport.UseVisualStyleBackColor = true;
            this.ExcelImport.Click += new System.EventHandler(this.ExcelImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(963, 490);
            this.Controls.Add(this.ExcelImport);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.TableList);
            this.Controls.Add(this.dataGridShow);
            this.Controls.Add(this.DataBind);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShow)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridShow;
        private System.Windows.Forms.ComboBox TableList;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.ToolStripButton FirstPageButton;
        private System.Windows.Forms.ToolStripButton PreviousButton;
        private System.Windows.Forms.ToolStripTextBox counter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel OfLabel;
        private System.Windows.Forms.ToolStripLabel OfCounter;
        private System.Windows.Forms.ToolStripButton NextButton;
        private System.Windows.Forms.ToolStripButton LastPageButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Button ExcelImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button DataBind;
    }
}

