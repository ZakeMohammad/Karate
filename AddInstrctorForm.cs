using Karate_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate
{
    public partial class AddInstrctorForm : Form
    {
        public AddInstrctorForm(int personid)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            PersonID= personid;
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

        int PersonID;

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if(clsInstruchers.AddNewInstruchers(PersonID)!=0)
            {
                Form New = new FormForRithThing("The Instructor Added");
                New.ShowDialog();
                this.Close();
                return;
            }
            else
            {
                Form New = new FormForWrongNotExist("The Instructor Does Not Added");
                New.ShowDialog();
                this.Close();
                return;
            }

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
