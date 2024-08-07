
namespace DWHEditForms
{
    partial class SearchForm
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
            this.components = new System.ComponentModel.Container();
            this.OparatorBox = new System.Windows.Forms.ComboBox();
            this.Op_Label = new System.Windows.Forms.Label();
            this.txtlebel = new System.Windows.Forms.Label();
            this.txtF = new System.Windows.Forms.TextBox();
            this.holderBox = new System.Windows.Forms.ComboBox();
            this.NumbLabel = new System.Windows.Forms.Label();
            this.NumF = new System.Windows.Forms.TextBox();
            this.OutputBtn = new System.Windows.Forms.Button();
            this.listbox = new System.Windows.Forms.ComboBox();
            this.FlagBox = new System.Windows.Forms.CheckBox();
            this.Check_button = new System.Windows.Forms.Button();
            this.dataInputsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataInputsDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OparatorBox
            // 
            this.OparatorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OparatorBox.FormattingEnabled = true;
            this.OparatorBox.Items.AddRange(new object[] {
            "<",
            "<=",
            ">",
            ">=",
            "=",
            "!="});
            this.OparatorBox.Location = new System.Drawing.Point(232, 4);
            this.OparatorBox.Name = "OparatorBox";
            this.OparatorBox.Size = new System.Drawing.Size(121, 24);
            this.OparatorBox.TabIndex = 1;
            // 
            // Op_Label
            // 
            this.Op_Label.AutoSize = true;
            this.Op_Label.Location = new System.Drawing.Point(159, 11);
            this.Op_Label.Name = "Op_Label";
            this.Op_Label.Size = new System.Drawing.Size(67, 17);
            this.Op_Label.TabIndex = 2;
            this.Op_Label.Text = "FindByop";
            // 
            // txtlebel
            // 
            this.txtlebel.AutoSize = true;
            this.txtlebel.Location = new System.Drawing.Point(359, 11);
            this.txtlebel.Name = "txtlebel";
            this.txtlebel.Size = new System.Drawing.Size(65, 17);
            this.txtlebel.TabIndex = 4;
            this.txtlebel.Text = "FindBytxt";
            // 
            // txtF
            // 
            this.txtF.Location = new System.Drawing.Point(430, 6);
            this.txtF.Name = "txtF";
            this.txtF.Size = new System.Drawing.Size(100, 22);
            this.txtF.TabIndex = 5;
            // 
            // holderBox
            // 
            this.holderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.holderBox.FormattingEnabled = true;
            this.holderBox.Location = new System.Drawing.Point(12, 4);
            this.holderBox.Name = "holderBox";
            this.holderBox.Size = new System.Drawing.Size(121, 24);
            this.holderBox.TabIndex = 6;
            this.holderBox.SelectedIndexChanged += new System.EventHandler(this.HolderBox_SelectedIndexChanged);
            // 
            // NumbLabel
            // 
            this.NumbLabel.AutoSize = true;
            this.NumbLabel.Location = new System.Drawing.Point(334, 52);
            this.NumbLabel.Name = "NumbLabel";
            this.NumbLabel.Size = new System.Drawing.Size(87, 17);
            this.NumbLabel.TabIndex = 7;
            this.NumbLabel.Text = "FindbyNumb";
            // 
            // NumF
            // 
            this.NumF.Location = new System.Drawing.Point(430, 51);
            this.NumF.Name = "NumF";
            this.NumF.Size = new System.Drawing.Size(100, 22);
            this.NumF.TabIndex = 8;
            // 
            // OutputBtn
            // 
            this.OutputBtn.Location = new System.Drawing.Point(536, 75);
            this.OutputBtn.Name = "OutputBtn";
            this.OutputBtn.Size = new System.Drawing.Size(92, 68);
            this.OutputBtn.TabIndex = 13;
            this.OutputBtn.Text = "Output";
            this.OutputBtn.UseVisualStyleBackColor = true;
            this.OutputBtn.Click += new System.EventHandler(this.OutputBtn_Click);
            // 
            // listbox
            // 
            this.listbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listbox.FormattingEnabled = true;
            this.listbox.Location = new System.Drawing.Point(430, 93);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(100, 24);
            this.listbox.TabIndex = 14;
            // 
            // FlagBox
            // 
            this.FlagBox.AutoSize = true;
            this.FlagBox.Location = new System.Drawing.Point(430, 134);
            this.FlagBox.Name = "FlagBox";
            this.FlagBox.Size = new System.Drawing.Size(80, 21);
            this.FlagBox.TabIndex = 15;
            this.FlagBox.Text = "FlagBox";
            this.FlagBox.UseVisualStyleBackColor = true;
            // 
            // Check_button
            // 
            this.Check_button.Location = new System.Drawing.Point(536, 4);
            this.Check_button.Name = "Check_button";
            this.Check_button.Size = new System.Drawing.Size(92, 65);
            this.Check_button.TabIndex = 18;
            this.Check_button.Text = "Check";
            this.Check_button.UseVisualStyleBackColor = true;
            this.Check_button.Click += new System.EventHandler(this.Check_button_Click);
            // 
            // dataInputsDataSet
            // 
            // 
            // dataInputsDataSetBindingSource
            // 
            this.dataInputsDataSetBindingSource.Position = 0;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Check_button);
            this.Controls.Add(this.FlagBox);
            this.Controls.Add(this.listbox);
            this.Controls.Add(this.OutputBtn);
            this.Controls.Add(this.NumF);
            this.Controls.Add(this.NumbLabel);
            this.Controls.Add(this.holderBox);
            this.Controls.Add(this.txtF);
            this.Controls.Add(this.txtlebel);
            this.Controls.Add(this.Op_Label);
            this.Controls.Add(this.OparatorBox);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataInputsDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource dataInputsDataSetBindingSource;
        private System.Windows.Forms.ComboBox OparatorBox;
        private System.Windows.Forms.Label Op_Label;
        private System.Windows.Forms.Label txtlebel;
        private System.Windows.Forms.TextBox txtF;
        private System.Windows.Forms.ComboBox holderBox;
        private System.Windows.Forms.Label NumbLabel;
        private System.Windows.Forms.TextBox NumF;
        private System.Windows.Forms.ComboBox listbox;
        private System.Windows.Forms.CheckBox FlagBox;
        public System.Windows.Forms.Button OutputBtn;
        private System.Windows.Forms.Button Check_button;
    }
}