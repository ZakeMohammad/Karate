namespace Karate
{
    partial class FormForBeltRanks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.DataGridViewForBelts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ComboFilterBelts = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.TxtFillterSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnEditBelt = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddNewBelt = new Guna.UI2.WinForms.Guna2Button();
            this.btnListBelts = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewForBelts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Karate.Properties.Resources.search1;
            this.btnSearch.ImageRotate = 0F;
            this.btnSearch.Location = new System.Drawing.Point(790, 328);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSearch.Size = new System.Drawing.Size(45, 32);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSearch.TabIndex = 18;
            this.btnSearch.TabStop = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // DataGridViewForBelts
            // 
            this.DataGridViewForBelts.AllowUserToAddRows = false;
            this.DataGridViewForBelts.AllowUserToDeleteRows = false;
            this.DataGridViewForBelts.AllowUserToOrderColumns = true;
            this.DataGridViewForBelts.AllowUserToResizeColumns = false;
            this.DataGridViewForBelts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(216)))), ((int)(((byte)(189)))));
            this.DataGridViewForBelts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewForBelts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewForBelts.ColumnHeadersHeight = 25;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(229)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(169)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewForBelts.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewForBelts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(209)))), ((int)(((byte)(177)))));
            this.DataGridViewForBelts.Location = new System.Drawing.Point(327, 412);
            this.DataGridViewForBelts.Name = "DataGridViewForBelts";
            this.DataGridViewForBelts.ReadOnly = true;
            this.DataGridViewForBelts.RowHeadersVisible = false;
            this.DataGridViewForBelts.RowHeadersWidth = 51;
            this.DataGridViewForBelts.RowTemplate.Height = 24;
            this.DataGridViewForBelts.Size = new System.Drawing.Size(738, 257);
            this.DataGridViewForBelts.TabIndex = 17;
            this.DataGridViewForBelts.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Carrot;
            this.DataGridViewForBelts.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(216)))), ((int)(((byte)(189)))));
            this.DataGridViewForBelts.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridViewForBelts.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridViewForBelts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridViewForBelts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridViewForBelts.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewForBelts.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(209)))), ((int)(((byte)(177)))));
            this.DataGridViewForBelts.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.DataGridViewForBelts.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridViewForBelts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewForBelts.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridViewForBelts.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewForBelts.ThemeStyle.HeaderStyle.Height = 25;
            this.DataGridViewForBelts.ThemeStyle.ReadOnly = true;
            this.DataGridViewForBelts.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(229)))), ((int)(((byte)(211)))));
            this.DataGridViewForBelts.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridViewForBelts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewForBelts.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewForBelts.ThemeStyle.RowsStyle.Height = 24;
            this.DataGridViewForBelts.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(169)))), ((int)(((byte)(107)))));
            this.DataGridViewForBelts.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // ComboFilterBelts
            // 
            this.ComboFilterBelts.BackColor = System.Drawing.Color.Transparent;
            this.ComboFilterBelts.BorderRadius = 12;
            this.ComboFilterBelts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboFilterBelts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFilterBelts.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboFilterBelts.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboFilterBelts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboFilterBelts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboFilterBelts.ItemHeight = 25;
            this.ComboFilterBelts.Items.AddRange(new object[] {
            "Belt ID",
            "Name",
            "Tests Fees"});
            this.ComboFilterBelts.Location = new System.Drawing.Point(608, 229);
            this.ComboFilterBelts.Name = "ComboFilterBelts";
            this.ComboFilterBelts.Size = new System.Drawing.Size(165, 31);
            this.ComboFilterBelts.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.ComboFilterBelts.TabIndex = 16;
            this.ComboFilterBelts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.AutoSizeHeightOnly = true;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(479, 234);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(168, 26);
            this.guna2HtmlLabel1.TabIndex = 15;
            this.guna2HtmlLabel1.Text = "Search By:";
            // 
            // TxtFillterSearch
            // 
            this.TxtFillterSearch.BorderRadius = 5;
            this.TxtFillterSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFillterSearch.DefaultText = "";
            this.TxtFillterSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtFillterSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtFillterSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFillterSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFillterSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.TxtFillterSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFillterSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFillterSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFillterSearch.IconRightSize = new System.Drawing.Size(30, 30);
            this.TxtFillterSearch.Location = new System.Drawing.Point(530, 328);
            this.TxtFillterSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtFillterSearch.Name = "TxtFillterSearch";
            this.TxtFillterSearch.PasswordChar = '\0';
            this.TxtFillterSearch.PlaceholderText = "";
            this.TxtFillterSearch.SelectedText = "";
            this.TxtFillterSearch.Size = new System.Drawing.Size(254, 32);
            this.TxtFillterSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.TxtFillterSearch.TabIndex = 14;
            this.TxtFillterSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtFillterSearch.TextChanged += new System.EventHandler(this.TxtFillterSearch_TextChanged);
            // 
            // btnEditBelt
            // 
            this.btnEditBelt.BorderRadius = 10;
            this.btnEditBelt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditBelt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditBelt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditBelt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditBelt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEditBelt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditBelt.ForeColor = System.Drawing.Color.White;
            this.btnEditBelt.Image = global::Karate.Properties.Resources.team_work;
            this.btnEditBelt.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEditBelt.Location = new System.Drawing.Point(702, 101);
            this.btnEditBelt.Name = "btnEditBelt";
            this.btnEditBelt.Size = new System.Drawing.Size(213, 56);
            this.btnEditBelt.TabIndex = 13;
            this.btnEditBelt.Text = "Edit Belt";
            this.btnEditBelt.Click += new System.EventHandler(this.btnEditBelt_Click);
            // 
            // btnAddNewBelt
            // 
            this.btnAddNewBelt.BorderRadius = 10;
            this.btnAddNewBelt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewBelt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewBelt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewBelt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewBelt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddNewBelt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewBelt.ForeColor = System.Drawing.Color.White;
            this.btnAddNewBelt.Image = global::Karate.Properties.Resources.user__1_;
            this.btnAddNewBelt.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewBelt.Location = new System.Drawing.Point(447, 101);
            this.btnAddNewBelt.Name = "btnAddNewBelt";
            this.btnAddNewBelt.Size = new System.Drawing.Size(213, 56);
            this.btnAddNewBelt.TabIndex = 12;
            this.btnAddNewBelt.Text = "Add Belt";
            this.btnAddNewBelt.Click += new System.EventHandler(this.btnAddNewBelt_Click);
            // 
            // btnListBelts
            // 
            this.btnListBelts.BorderRadius = 10;
            this.btnListBelts.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnListBelts.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnListBelts.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnListBelts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnListBelts.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnListBelts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnListBelts.ForeColor = System.Drawing.Color.White;
            this.btnListBelts.Image = global::Karate.Properties.Resources.group__1_;
            this.btnListBelts.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnListBelts.Location = new System.Drawing.Point(179, 101);
            this.btnListBelts.Name = "btnListBelts";
            this.btnListBelts.Size = new System.Drawing.Size(213, 56);
            this.btnListBelts.TabIndex = 11;
            this.btnListBelts.Text = "List Belt";
            this.btnListBelts.Click += new System.EventHandler(this.btnListBelts_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::Karate.Properties.Resources.team_work;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Location = new System.Drawing.Point(956, 101);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(213, 56);
            this.guna2Button1.TabIndex = 19;
            this.guna2Button1.Text = "Find Belt";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // FormForBeltRanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1521, 721);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.DataGridViewForBelts);
            this.Controls.Add(this.ComboFilterBelts);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.TxtFillterSearch);
            this.Controls.Add(this.btnEditBelt);
            this.Controls.Add(this.btnAddNewBelt);
            this.Controls.Add(this.btnListBelts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormForBeltRanks";
            this.Text = "FormForBeltRanks";
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewForBelts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox btnSearch;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridViewForBelts;
        private Guna.UI2.WinForms.Guna2ComboBox ComboFilterBelts;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox TxtFillterSearch;
        private Guna.UI2.WinForms.Guna2Button btnEditBelt;
        private Guna.UI2.WinForms.Guna2Button btnAddNewBelt;
        private Guna.UI2.WinForms.Guna2Button btnListBelts;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}