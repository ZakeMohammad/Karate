using Karate_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate
{
    public partial class ListInstructorsForm : Form
    {
        public ListInstructorsForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            _ReferchData();
        }

        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                }
            }
            base.WndProc(ref m);
        }



        void _ReferchData()
        {
            DataTable dt = clsInstruchers.GitAllInstruchers();

           DataGridviewAllInstructors.DataSource = dt;

            lbllistinstructor.Text = "Instructor in club [" + dt.Rows.Count.ToString() + "]";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsInstruchers.DeleteInstruchers((int)DataGridviewAllInstructors.CurrentRow.Cells[0].Value))
            {
                return;
            }

        }
    }
}
