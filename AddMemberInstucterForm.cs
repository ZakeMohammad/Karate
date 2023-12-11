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
    public partial class AddMemberInstucterForm : Form
    {
        public AddMemberInstucterForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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

        private void AddMemberInstucterForm_Load(object sender, EventArgs e)
        {
            DataTable dt = clsMemberInstructor.GitAllMemberNames();
            DataTable dt2 = clsMemberInstructor.GitAllInstructrsNames();

            foreach (DataRow row in dt.Rows)
            {
                string name = row[0].ToString();
                ComboMember.Items.Add(name);
  
            }

            foreach(DataRow row in dt2.Rows)
            {
                string name = row[0].ToString();
                ComboInstructers.Items.Add(name);
         
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Ruslt = clsMemberInstructor.AddMemberInstercter(ComboMember.SelectedItem.ToString(), ComboInstructers.SelectedItem.ToString(), datamakerformemberinstructer.Value);

            if (Ruslt==1)
            {
                Form New = new FormForRithThing("The MemberInstrcter Added");
                New.ShowDialog();
                this.Close();
                return;
            }
            else if(Ruslt==0)
            {
                Form New = new FormForWrongNotExist("The MemberInstrcter Does Not Added");
                New.ShowDialog();
                this.Close(); return;
            }
            if(Ruslt==2)
            {
                Form New = new FormForWrongWithReasons("The MemberInstrcter Does Not Added , Because The Member Already in MemberInstructer");
                New.ShowDialog();
                this.Close(); return;
            } 

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
