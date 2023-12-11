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
    public partial class AddTestForm : Form
    {
        public AddTestForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            _FillComboBoxes();
        }

        
        void _FillComboBoxes()
        {
            DataTable dt1 = clsMemberInstructor.GitAllMemberNames();
            foreach (DataRow Row in dt1.Rows)
            {
                ComboMember.Items.Add(Row[0].ToString());
            }

            DataTable dt2=clsMemberInstructor.GitAllInstructrsNames();

            foreach (DataRow Row in dt2.Rows)
            {
                ComboInstercter.Items.Add(Row[0].ToString());
            }
            DataTable dt3 = clsMemberInstructor.GitAllBeltsNames();

            foreach (DataRow Row in dt3.Rows)
            {
                ComboBelts.Items.Add(Row[0].ToString());
            }

            Form New = new FormForRithThing("You Must Pay Before Inrol in Test", "Add Payment");
            New.ShowDialog();

            Form AddPayment = new AddNewPaymentForm();
            AddPayment.ShowDialog();

            Form Ruslt = new FormForRithThing("You Payed Successfully");
            Ruslt.ShowDialog();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTests Test= new clsTests();


            clsMembers Member = clsMembers.Find(ComboMember.SelectedItem.ToString());

            Test.MemberID = Member.MemberID;
        
            clsInstruchers Instrcter=clsInstruchers.Find(ComboInstercter.SelectedItem.ToString());

            Test.InstructerID = Instrcter.InstruchersID;

            clsBeltRanks Belt = clsBeltRanks.Find(ComboBelts.SelectedItem.ToString());

            Test.RankID = Belt.BeltID;
            



            Test.TestDate = Date.Value;

            if(RdFalid.Checked)
            {
                Test.Result = "Falid";
            }
            if(RDPassid.Checked)
            {
                Test.Result = "Passid";
            }
            DataTable dt = clsPayments.GitLastesPayment();

            foreach (DataRow Row in dt.Rows)
            {
                Test.PaymentID = (int)Row[0];
            }

            if (clsTests.AddTest(Test.MemberID,Test.RankID,Test.Result,Test.TestDate,Test.InstructerID,Test.PaymentID) != 0)
            {
                Form addsub = new FormForRithThing("The Test Added Successfully");
                addsub.ShowDialog();
                return;
            }
            else
            {
                Form addsub2 = new FormForWrongWithReasons("The Test Does Not Added Successfully");
                addsub2.ShowDialog();
                return;
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
