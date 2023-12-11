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
    public partial class AddNewSubsecriptionForm : Form
    {
        public AddNewSubsecriptionForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            _FillNamesForMembers();
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


        void _FillNamesForMembers()
        {
            DataTable dt1 = clsMemberInstructor.GitAllMemberNames();
            foreach (DataRow Row in dt1.Rows)
            {
                ComboForMembers.Items.Add(Row[0].ToString());
            }
            Form New = new FormForRithThing("You Must Pay Before Subsecription", "Add Payment");
            New.ShowDialog();

            Form AddPayment = new AddNewPaymentForm();
            AddPayment.ShowDialog();

            Form Ruslt = new FormForRithThing("You Payed Successfully");
            Ruslt.ShowDialog();
        }


        private void btnSaveForADD_Click(object sender, EventArgs e)
        {
         
            clsSubscriptions Period= new clsSubscriptions();

            Period.StartDate = DateStartDate.Value;
            Period.EndDate=DateEndDate.Value;

            clsMembers Member = clsMembers.Find(ComboForMembers.SelectedItem.ToString());

            Period.MemberID = Member.MemberID;

            Period.Fees = (double)NumberOfFees.Value;

            if(RDNo.Checked)
            {
                Period.IsPaid = "No";
            }
            if(RDYes.Checked)
            {
                Period.IsPaid = "Yes";
            }

             DataTable dt=clsPayments.GitLastesPayment();

            foreach(DataRow Row in dt.Rows)
            {
                Period.PaymentID = (int)Row[0];
            }

            if(clsSubscriptions.AddNewSubsecription(Period.MemberID,Period.Fees,Period.IsPaid,Period.StartDate,Period.EndDate,Period.PaymentID)!=0)
            {
                Form addsub = new FormForRithThing("The Subsecription Added Successfully");
                addsub.ShowDialog();
                return;
            }
            else
            {
                Form addsub2 = new FormForWrongWithReasons("The Subsecription Does Not Added Successfully");
                addsub2.ShowDialog();
                return;
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
