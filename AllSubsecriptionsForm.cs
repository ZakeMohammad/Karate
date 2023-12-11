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
    public partial class AllSubsecriptionsForm : Form
    {
        public AllSubsecriptionsForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            DataGridVeiwAllSubscreptions.DataSource = clsSubscriptions.GitallSubsecriptions();
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsSubscriptions.DeleteSubsecription((int)DataGridVeiwAllSubscreptions.CurrentRow.Cells[0].Value))
            {
                if(clsPayments.DeletePayment((int)DataGridVeiwAllSubscreptions.CurrentRow.Cells[6].Value)!=0)
                {
                    Form New = new FormForRithThing("The Sebsecription Deleted Successfully");
                    New.ShowDialog();
                    return;
                }

          

            }
            else
            {

                Form New = new FormForWrongNotExist("The Sebsecription Does Not Deleted Successfully");
                New.ShowDialog();
                return;
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
