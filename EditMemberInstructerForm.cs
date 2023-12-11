using Karate.Properties;
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
using System.Xml.Linq;

namespace Karate
{
    public partial class EditMemberInstructerForm : Form
    {
        public EditMemberInstructerForm()
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

        clsMemberInstructor _MemberInstructor;

        DataTable dt1 = clsMemberInstructor.GitAllMemberNames();
        DataTable dt2= clsMemberInstructor.GitAllInstructrsNames();

        void FillMemberInstructerDataToForm(clsMemberInstructor MemberInstructer)
        {

            TxtMemberInstructor.Text = MemberInstructer.MemberInstructerID.ToString();

            datamakerformemberinstructer.Value = MemberInstructer.AssignDate;

            foreach(DataRow Row in dt1.Rows)
            {
                ComboMember.Items.Add(Row[0].ToString());
            }
            foreach (DataRow Row in dt2.Rows)
            {
                ComboInstructers.Items.Add(Row[0].ToString());
            }
            ComboMember.SelectedItem = MemberInstructer.MemberName;
            ComboInstructers.SelectedItem = MemberInstructer.InstructerName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillDataToNewMemberInstructer();
            int Ruslt = clsMemberInstructor.UpdateMemberInstructer(_MemberInstructor.MemberInstructerID, _MemberInstructor.MemberName, _MemberInstructor.InstructerName, _MemberInstructor.AssignDate);
            if ( Ruslt==1)
            {
                Form New = new FormForRithThing("The MemberInstructer Updated");
                New.ShowDialog();
            }
            else if(Ruslt==0)
            {
                Form New = new FormForWrongWithReasons("The MemberInstructer Does Not Updated");
                New.ShowDialog();
            }
            if(Ruslt==2)
            {
                Form New = new FormForWrongWithReasons("The MemberInstructer Does Not Updated , Because The Member Is Already in MemberInstructer");
                New.ShowDialog();
            }
        }
        void FillDataToNewMemberInstructer()
        {
            _MemberInstructor.AssignDate = datamakerformemberinstructer.Value;
            _MemberInstructor.MemberInstructerID=Convert.ToInt32( TxtMemberInstructor.Text);
            _MemberInstructor.MemberName=ComboMember.SelectedItem.ToString();
            _MemberInstructor.InstructerName=ComboInstructers.SelectedItem.ToString();
        }
        private void btnSearchForMemberInstructor_Click(object sender, EventArgs e)
        {
            if (TxtSearchByMemberInstructor.Text == string.Empty)
            {
                Form New = new FormForWrongNotExist("Plese Enter  ID To Search");
                New.ShowDialog();
                return;
            }

            clsMemberInstructor MemberInstructer = clsMemberInstructor.Find(Convert.ToInt32(TxtSearchByMemberInstructor.Text));

            if (MemberInstructer != null)
            {
                FillMemberInstructerDataToForm(MemberInstructer);

                _MemberInstructor = MemberInstructer;
            }
            else
            {
                Form New = new FormForWrongWithReasons("The MemberInstructer Does Not Exist");
                New.ShowDialog();
            }
        }
    }
}