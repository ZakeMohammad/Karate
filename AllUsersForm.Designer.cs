namespace Karate
{
    partial class AllUsersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelToop = new Guna.UI2.WinForms.Guna2Panel();
            this.lbllistUsers = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.DataGridviewALlUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.PanelToop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridviewALlUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelToop
            // 
            this.PanelToop.BackColor = System.Drawing.Color.LightGreen;
            this.PanelToop.Controls.Add(this.lbllistUsers);
            this.PanelToop.Controls.Add(this.guna2Button1);
            this.PanelToop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelToop.Location = new System.Drawing.Point(0, 0);
            this.PanelToop.Name = "PanelToop";
            this.PanelToop.Size = new System.Drawing.Size(973, 73);
            this.PanelToop.TabIndex = 2;
            // 
            // lbllistUsers
            // 
            this.lbllistUsers.AutoSize = false;
            this.lbllistUsers.AutoSizeHeightOnly = true;
            this.lbllistUsers.BackColor = System.Drawing.Color.Transparent;
            this.lbllistUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistUsers.Location = new System.Drawing.Point(324, 21);
            this.lbllistUsers.Name = "lbllistUsers";
            this.lbllistUsers.Size = new System.Drawing.Size(496, 39);
            this.lbllistUsers.TabIndex = 1;
            this.lbllistUsers.Text = "Users in club ";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::Karate.Properties.Resources.false1;
            this.guna2Button1.Location = new System.Drawing.Point(923, 0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(50, 33);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // DataGridviewALlUsers
            // 
            this.DataGridviewALlUsers.AllowUserToAddRows = false;
            this.DataGridviewALlUsers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(223)))), ((int)(((byte)(219)))));
            this.DataGridviewALlUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridviewALlUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridviewALlUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridviewALlUsers.ColumnHeadersHeight = 20;
            this.DataGridviewALlUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(233)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridviewALlUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridviewALlUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(222)))), ((int)(((byte)(218)))));
            this.DataGridviewALlUsers.Location = new System.Drawing.Point(3, 104);
            this.DataGridviewALlUsers.Name = "DataGridviewALlUsers";
            this.DataGridviewALlUsers.ReadOnly = true;
            this.DataGridviewALlUsers.RowHeadersVisible = false;
            this.DataGridviewALlUsers.RowHeadersWidth = 51;
            this.DataGridviewALlUsers.RowTemplate.Height = 24;
            this.DataGridviewALlUsers.Size = new System.Drawing.Size(967, 456);
            this.DataGridviewALlUsers.TabIndex = 3;
            this.DataGridviewALlUsers.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Teal;
            this.DataGridviewALlUsers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(223)))), ((int)(((byte)(219)))));
            this.DataGridviewALlUsers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridviewALlUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridviewALlUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridviewALlUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridviewALlUsers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridviewALlUsers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(222)))), ((int)(((byte)(218)))));
            this.DataGridviewALlUsers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.DataGridviewALlUsers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridviewALlUsers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridviewALlUsers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridviewALlUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridviewALlUsers.ThemeStyle.HeaderStyle.Height = 20;
            this.DataGridviewALlUsers.ThemeStyle.ReadOnly = true;
            this.DataGridviewALlUsers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(233)))), ((int)(((byte)(231)))));
            this.DataGridviewALlUsers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridviewALlUsers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridviewALlUsers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridviewALlUsers.ThemeStyle.RowsStyle.Height = 24;
            this.DataGridviewALlUsers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(175)))));
            this.DataGridviewALlUsers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.PanelToop;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // AllUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 572);
            this.Controls.Add(this.DataGridviewALlUsers);
            this.Controls.Add(this.PanelToop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AllUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AllUsersForm";
            this.PanelToop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridviewALlUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel PanelToop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbllistUsers;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridviewALlUsers;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}